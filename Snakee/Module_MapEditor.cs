using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;
using System;
using CustomPictureBox;
using System.Collections.Generic;
using System.IO;
using Snakee.Properties;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snakee
{
    public partial class frmMapEditor
    {
        MapEditor m_meMap = new MapEditor();

        List<List<SnakeBox>> m_sbMap = new List<List<SnakeBox>>();

        List<SnakeBodyInfo> m_sbiSnake = new List<SnakeBodyInfo>();

        List<Point> m_pWallLoc = new List<Point>();

        List<string> m_lstrBatchImp = new List<string>() { "snakee_body_down_right.png", "snakee_body_fat_down_right.png", "snakee_head_right.png", "snakee_head_eat_right.png", "snakee_tail_right.png", "snakee_turn_up_right.png", "snakee_turn_fat_up_right.png", "snakee_food.png", "snakee_wall.png" };

        ToolStripButton[] m_tsbExDrawing;

        enum DrawAction
        {
            DrawRectangle, FillRectangle, Block,
            Line
        }

        DrawAction m_daDraw = DrawAction.Block;
        bool m_bClicked = false;

        Point m_pStart = new Point();

        List<Point> m_pCurrent = new List<Point>();
        List<Point> m_pLast = new List<Point>();

        struct UndoRedoStruct
        {
            public List<Point> Current; //{ get; set; }  //For undo
            public List<Point> Last; //{ get; set; }   //For redo
            //public UndoRedoStruct(List<Point> current, List<Point> last) :this()
            //{
            //    Current = current;
            //    Last = last;
            //}
        }

        List<UndoRedoStruct> m_lurDo = new List<UndoRedoStruct>();

        List<List<Point>> m_pUndo = new List<List<Point>>();
        List<List<Point>> m_pRedo = new List<List<Point>>();

        Thread m_tMapGen;



        #region AllInit

        void All_Init()
        {
            UIString_Init();
            All_Dock();
            DrawingAct_Init();

        }


        void All_Dock()
        {
            Home_Dock();
            InfoCon_Dock();
            MapEditor_Dock();
        }

        #endregion

        #region HomeScreen

        void Home_Dock()
        {
            pnlHome.Dock = DockStyle.Fill;
        }

        void Home_Visible(bool isShow)
        {
            pnlHome.Visible = isShow;
            Home_Centerize();
        }

        void Home_Centerize()
        {
            btnNewMap.Size = new Size(200, 100);
            btnLoadMap.Size = new Size(200, 100);

            btnNewMap.Top = this.Height / 2 - btnNewMap.Height / 2;
            btnLoadMap.Top = this.Height / 2 - btnLoadMap.Height / 2;

            btnNewMap.Left = this.Width / 2 - 2 - btnNewMap.Width;
            btnLoadMap.Left = btnNewMap.Right + 2;
        }

        #endregion

        #region InfoEditorUI

        #region ShowFunc
        void InfoEditor_NewMap()
        {
            m_meMap = new MapEditor();
            string strFilename = PFunc.SaveFile_Show("Snakee Map File|*.smap", "Custom Map.smap");
            if (strFilename != "")
            {
                Title_SetText(UIString.MapEditorForm.FormTitle  + " [ " + strFilename + " ]");
                m_meMap.FileName = strFilename;
            }
            else
            {
                return;
            }
            LoadMap_AssignValue();
            Home_Visible(false);
            InfoEditor_Visible(true);
        }

        void InfoEditor_LoadMap()
        {
            m_meMap = new MapEditor();
            string strFileName = PFunc.OpenFile_Show("Snakee Map File|*.smap","Custom Map.smap");
            if (strFileName != "")
            {
                Title_SetText(UIString.MapEditorForm.FormTitle +  " [ " + strFileName + " ]");
                m_meMap.FileName = strFileName;
            }
            else
            {
                return;
            }

            m_meMap.Load(strFileName);
            if (Version_Check() == true)
            {
                return;
            }
            LoadMap_AssignValue();
            Home_Visible(false);
            InfoEditor_Visible(true);
        }

        void InfoEditor_Visible(bool isShow)
        {
            ErrorWarning_Clear(plbErrorWarningSkin);
            InfoCon_Visible(isShow);
        }

        #region MapCheck
        bool Version_Check()
        {
            if (m_meMap.Version != GlobalSettings.MapVersion)
            {
                MessageBox.Show(UIString.MapEditorForm.MainMapNotCompatible);
                return true;
            }
            return false;
        }
        #endregion

        #region AssignValueLoadMap

        void LoadMap_AssignValue()
        {
            AssignValue_MapInfo();
            AssignValue_ThemeInfo();
            AssignValue_SkinInfo();
        }

        void AssignValue_MapInfo()
        {
            ctbMapBlockSize.Text = m_meMap.BlockSize.ToString();
            ctbMapHeight.Text = m_meMap.Height.ToString();
            ctbMapName.Text = m_meMap.Name;
            ctbMapSnakeLength.Text = m_meMap.SnakeLength.ToString();
            ctbMapWidth.Text = m_meMap.Width.ToString();
            ctbMapInterval.Text = m_meMap.Interval.ToString();
        }

        void AssignValue_ThemeInfo()
        {
            ThemeInfo_DrawPreview();
        }

        void AssignValue_SkinInfo()
        {
            plbSkinPath.Images[0] = m_meMap.SnakeeSkin.Body_DR;
            plbSkinPath.Images[1] = m_meMap.SnakeeSkin.BodyFat_DR;
            plbSkinPath.Images[2] = m_meMap.SnakeeSkin.Head_R;
            plbSkinPath.Images[3] = m_meMap.SnakeeSkin.HeadEat_R;
            plbSkinPath.Images[4] = m_meMap.SnakeeSkin.Tail_R;
            plbSkinPath.Images[5] = m_meMap.SnakeeSkin.Turn_UR;
            plbSkinPath.Images[6] = m_meMap.SnakeeSkin.TurnFat_UR;
            plbSkinPath.Images[7] = m_meMap.SnakeeSkin.Food;
            plbSkinPath.Images[8] = m_meMap.SnakeeSkin.Wall;

            SkinPreview_Load(epSkinPreviewBody, new List<Image>() { m_meMap.SnakeeSkin.Body_DL, m_meMap.SnakeeSkin.Body_DR, m_meMap.SnakeeSkin.Body_UL, m_meMap.SnakeeSkin.Body_UR });
            SkinPreview_Load(epSkinPreviewFatBody, new List<Image>() { m_meMap.SnakeeSkin.BodyFat_DL, m_meMap.SnakeeSkin.BodyFat_DR, m_meMap.SnakeeSkin.BodyFat_UL, m_meMap.SnakeeSkin.BodyFat_UR });
            SkinPreview_Load(epSkinPreviewEatHead, new List<Image>() { m_meMap.SnakeeSkin.HeadEat_L, m_meMap.SnakeeSkin.HeadEat_R, m_meMap.SnakeeSkin.HeadEat_D, m_meMap.SnakeeSkin.HeadEat_U });
            SkinPreview_Load(epSkinPreviewHead, new List<Image>() { m_meMap.SnakeeSkin.Head_L, m_meMap.SnakeeSkin.Head_R, m_meMap.SnakeeSkin.Head_D, m_meMap.SnakeeSkin.Head_U });
            SkinPreview_Load(epSkinPreviewTail, new List<Image>() { m_meMap.SnakeeSkin.Tail_L, m_meMap.SnakeeSkin.Tail_R, m_meMap.SnakeeSkin.Tail_D, m_meMap.SnakeeSkin.Tail_U });
            SkinPreview_Load(epSkinPreviewTurn, new List<Image>() { m_meMap.SnakeeSkin.Turn_DL, m_meMap.SnakeeSkin.Turn_DR, m_meMap.SnakeeSkin.Turn_UL, m_meMap.SnakeeSkin.Turn_UR });
            SkinPreview_Load(epSkinPreviewTurnFat, new List<Image>() { m_meMap.SnakeeSkin.TurnFat_DL, m_meMap.SnakeeSkin.TurnFat_DR, m_meMap.SnakeeSkin.TurnFat_UL, m_meMap.SnakeeSkin.TurnFat_UR });
            SkinPreview_Load(epSkinPreviewWall, new List<Image>() { m_meMap.SnakeeSkin.Wall }, 1);
            SkinPreview_Load(epSkinPreviewFood, new List<Image>() { m_meMap.SnakeeSkin.Food }, 1);
        }
        #endregion
        #endregion

        #region InfoEditContainer
        void InfoCon_Dock()
        {
            pnlSkinEditorCon.Dock = DockStyle.Fill;
        }

        void InfoCon_Visible(bool isShow)
        {
            pnlSkinEditorCon.Visible = isShow;
        }
        #endregion

        #region SkinPreviewCon
        void SkinPreview_Visible(bool isShow)
        {
            epSkinPreview.Visible = isShow;
        }

        #endregion

        #region UIFunc

        #region ThemeInfo

        void ThemeInfo_DrawPreview()
        {
            picThemePreBox.Image = null;

            Bitmap bPre = new Bitmap(picThemePreBox.Width, picThemePreBox.Height);
            Graphics gPre = Graphics.FromImage(bPre);
            StringFormat sfF = new StringFormat();
            sfF.LineAlignment = StringAlignment.Center;
            sfF.Alignment = StringAlignment.Center;
            gPre.TextRenderingHint = TextRenderingHint.AntiAlias;
            gPre.DrawString("Foreground", new Font("Segoe UI", 20), new SolidBrush(m_meMap.Foreground), picThemePreBox.ClientRectangle, sfF);

            picThemePreBox.BackColor = m_meMap.Background;
            picThemePreBox.Image = bPre;

        }

        #endregion

        #region SkinInfo

        void SkinInfo_BatchImport(string FolderPath)
        {
            //Add "/" before assigning value
            for (int i = 0; i < m_lstrBatchImp.Count; i++)
            {
                if (File.Exists(FolderPath + m_lstrBatchImp[i]) == true)
                {
                    BatchImport_Assign(i, FolderPath + m_lstrBatchImp[i]);
                }
            }
            AssignValue_SkinInfo();
        }

        void BatchImport_Assign(int index, string filename)
        {
            switch (index)
            {
                case 0:
                    m_meMap.BodyRDp = filename;
                    break;

                case 1:
                    m_meMap.BodyFatRDp = filename;
                    break;

                case 2:
                    m_meMap.HeadRp = filename;
                    break;

                case 3:
                    m_meMap.HeadEatRp = filename;
                    break;

                case 4:
                    m_meMap.TailRp = filename;
                    break;

                case 5:
                    m_meMap.TurnURp = filename;
                    break;

                case 6:
                    m_meMap.TurnFatURp = filename;
                    break;

                case 7:
                    m_meMap.Foodp = filename;
                    break;

                case 8:
                    m_meMap.Wallp = filename;
                    break;
            }
        }

        void SkinInfo_LoadPre(int index, string FileName, PictureListBox plb)
        {
            switch (index)
            {
                case 0:
                    m_meMap.BodyRDp = FileName;
                    plb.Images[0] = m_meMap.SnakeeSkin.Body_DR;
                    SkinPreview_Load(epSkinPreviewBody, new List<Image>() { m_meMap.SnakeeSkin.Body_DL, m_meMap.SnakeeSkin.Body_DR, m_meMap.SnakeeSkin.Body_UL, m_meMap.SnakeeSkin.Body_UR });
                    break;
                case 1:
                    m_meMap.BodyFatRDp = FileName;
                    plb.Images[1] = m_meMap.SnakeeSkin.BodyFat_DR;
                    SkinPreview_Load(epSkinPreviewFatBody, new List<Image>() { m_meMap.SnakeeSkin.BodyFat_DL, m_meMap.SnakeeSkin.BodyFat_DR, m_meMap.SnakeeSkin.BodyFat_UL, m_meMap.SnakeeSkin.BodyFat_UR });
                    break;
                case 2:
                    m_meMap.HeadRp = FileName;
                    plb.Images[2] = m_meMap.SnakeeSkin.Head_R;
                    SkinPreview_Load(epSkinPreviewHead, new List<Image>() { m_meMap.SnakeeSkin.Head_L, m_meMap.SnakeeSkin.Head_R, m_meMap.SnakeeSkin.Head_D, m_meMap.SnakeeSkin.Head_U });
                    break;
                case 3:
                    m_meMap.HeadEatRp = FileName;
                    plb.Images[3] = m_meMap.SnakeeSkin.HeadEat_R;
                    SkinPreview_Load(epSkinPreviewEatHead, new List<Image>() { m_meMap.SnakeeSkin.HeadEat_L, m_meMap.SnakeeSkin.HeadEat_R, m_meMap.SnakeeSkin.HeadEat_D, m_meMap.SnakeeSkin.HeadEat_U });
                    break;
                case 4:
                    m_meMap.TailRp = FileName;
                    plb.Images[4] = m_meMap.SnakeeSkin.Tail_R;
                    SkinPreview_Load(epSkinPreviewTail, new List<Image>() { m_meMap.SnakeeSkin.Tail_L, m_meMap.SnakeeSkin.Tail_R, m_meMap.SnakeeSkin.Tail_D, m_meMap.SnakeeSkin.Tail_U });
                    break;
                case 5:
                    m_meMap.TurnURp = FileName;
                    plb.Images[5] = m_meMap.SnakeeSkin.Turn_UR;
                    SkinPreview_Load(epSkinPreviewTurn, new List<Image>() { m_meMap.SnakeeSkin.Turn_DL, m_meMap.SnakeeSkin.Turn_DR, m_meMap.SnakeeSkin.Turn_UL, m_meMap.SnakeeSkin.Turn_UR });
                    break;
                case 6:
                    m_meMap.TurnFatURp = FileName;
                    plb.Images[6] = m_meMap.SnakeeSkin.TurnFat_UR;
                    SkinPreview_Load(epSkinPreviewTurnFat, new List<Image>() { m_meMap.SnakeeSkin.TurnFat_DL, m_meMap.SnakeeSkin.TurnFat_DR, m_meMap.SnakeeSkin.TurnFat_UL, m_meMap.SnakeeSkin.TurnFat_UR });
                    break;
                case 7:
                    m_meMap.Foodp = FileName;
                    plb.Images[7] = m_meMap.SnakeeSkin.Food;
                    SkinPreview_Load(epSkinPreviewFood, new List<Image>() { m_meMap.SnakeeSkin.Food }, 1);
                    break;
                case 8:
                    m_meMap.Wallp = FileName;
                    plb.Images[8] = m_meMap.SnakeeSkin.Wall;
                    SkinPreview_Load(epSkinPreviewWall, new List<Image>() { m_meMap.SnakeeSkin.Wall }, 1);
                    break;
            }
        }

        void SkinPreview_Load(ExpandablePanel Container, List<Image> Images, int No = 4)
        {
            Container.Controls.Clear();

            List<ZoomBox> lstzb = new List<ZoomBox>();

            for (int i = 0; i < No; i++)
            {
                ZoomBox zb = new ZoomBox(Images[i], 8);
                if (i == 0)
                {
                    zb.Location = new Point(15, 15);
                }
                else
                {
                    zb.Left = lstzb[i - 1].Right + 5;
                    zb.Top = lstzb[i - 1].Top;
                }
                lstzb.Add(zb);
                Container.Controls.Add(zb);
            }

            Container.Height = lstzb[0].Height + 30;

        }


        #endregion

        #region ToolbarFunc
        void Default_Load()
        {
            m_meMap.LoadDefault();
            LoadMap_AssignValue();

        }

        void Back_ToHome()
        {
            Title_SetText(UIString.MapEditorForm.FormTitle);
            InfoEditor_Visible(false);
            Home_Visible(true);
        }

        void GenMap_Generate()
        {
            Infos_Save();
            ErrorWarning_Clear(plbErrorWarningSkin);
            bool bErr = Check_Error();
            bool bWar = Check_Warning();
            if (bErr == true)
            {
                MessageBox.Show(UIString.MapEditorForm.SkinCheckError, UIString.MapEditorForm.SkincheckErrorTitle,MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (bWar == true)
                {
                    if (MessageBox.Show(UIString.MapEditorForm.SkinCheckWarning, UIString.MapEditorForm.SkincheckErrorTitle, MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }
            
            InfoEditor_Visible(false);
            MapEditor_Visible(true);
            m_tMapGen = new Thread(Map_Generate);
            m_tMapGen.Start();
        }
        #endregion

        #region ErrorWarning
        bool Check_Warning()
        {
            List<string> str = m_meMap.Warnings;
            if (str.Count == 0)
            {
                return false;
            }
            for (int i = 0; i < str.Count; i++)
            {
                ErrorWarning_AddItemsAndImage(plbErrorWarningSkin, str[i], Resources.button_warning);
            }
            return true;
        }

        bool Check_Error()
        {
            List<string> str = m_meMap.Errors;
            if (str.Count == 0)
            {
                return false;
            }
            for (int i = 0; i < str.Count; i++)
            {
                ErrorWarning_AddItemsAndImage(plbErrorWarningSkin, str[i], Resources.button_error);
            }
            return true;
        }
        #endregion

        #endregion

        #endregion

        #region MapEditorUI

        #region MapGenerating
        void Map_Generate()
        {
            MapBox_Generate();
            Map_LoadLoc();
            Snake_Init();
            Wall_Init();
        }

        void Map_LoadLoc()
        {
            m_pWallLoc = new List<Point>(m_meMap.WallPoint);
            //m_pWallLoc.ForEach(item => Console.WriteLine(item.ToString()));

            SnakeBodyInfo sbi = new SnakeBodyInfo();

            m_meMap.SnakeBodyPoint.ForEach(delegate(Point item)
            {
                sbi.Box = m_sbMap[item.X][item.Y];
                sbi.Coordinate = new Point(item.X,item.Y);
                m_sbiSnake.Add(sbi);
            }
            );
        }


        void MapBox_Generate()
        {
            Skin sSnake = new Skin();
            sSnake = m_meMap.SnakeeSkin;

            sSnake.Background = m_meMap.Background;
            sSnake.Foreground = m_meMap.Foreground;

            //ToolStripProgressBar tsp = new ToolStripProgressBar();


            for (int y = 0; y < m_meMap.Height; y++)
            {
                List<SnakeBox> sbY = new List<SnakeBox>();
                for (int x = 0; x < m_meMap.Width; x++)
                {
                    SnakeBox sbX = new SnakeBox(sSnake);
                    sbX.Size = new Size(m_meMap.BlockSize + 2, m_meMap.BlockSize + 2);
                    sbX.Coordinate = new Point(x, y);
                    sbX.BorderStyle = BorderStyle.FixedSingle;
                    sbX.BackColor = m_meMap.Background;

                    if (x == 0)
                    {
                        if (y == 0)
                        {
                            sbX.Location = new Point(5, 5);
                        }
                        else
                        {
                            sbX.Top = m_sbMap[y - 1][0].Bottom - 1;
                            sbX.Left = m_sbMap[y - 1][0].Left;
                        }
                    }
                    else
                    {
                        sbX.Left = sbY[x - 1].Right - 1;
                        sbX.Top = sbY[x - 1].Top;
                    }
                    pnlMapBoxCon.Invoke((Action)delegate()
                        {
                            pnlMapBoxCon.Controls.Add(sbX);
                        });
                    

                    sbX.MouseDown += (object sender, MouseEventArgs e) =>
                    {
                        m_bClicked = true;
                        m_pStart = ((SnakeBox)sender).Coordinate;
                    };
                    sbX.MouseUp += (object sender, MouseEventArgs e) =>
                    {
                        if (m_bClicked)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                //m_pCurrent.ForEach(item => m_sbMap[item.Y][item.X].IsWall = true);
                                m_pCurrent.ForEach(delegate(Point item)
                                {
                                    m_sbMap[item.Y][item.X].IsWall = true;
                                    m_sbMap[item.Y][item.X].BackColor = m_meMap.Background;
                                    m_pWallLoc.Add(item);

                                }
                                    );
                                if (m_pCurrent.Count != 0)
                                {
                                    m_pUndo.Add(new List<Point>(m_pCurrent));
                                    m_pRedo.Clear();
                                }
                            }
                            else if (e.Button == MouseButtons.Right)
                            {
                                m_pCurrent.ForEach(item => m_sbMap[item.Y][item.X].IsWall = false); //.BackColor = Color.FromKnownColor(KnownColor.Control));
                                m_pWallLoc.RemoveAll(item => m_pCurrent.Contains(item));
                            }

                            //m_pWallLoc.ForEach(item => Console.WriteLine(item.ToString()));
                            
                            //UndoRedoStruct uds = new UndoRedoStruct();
                            //uds.Current = new List<Point>(m_pCurrent);
                            //uds.Last = new List<Point>(m_pLast);

                            //m_lurDo.Add(uds);
                        }
                        Undo_CheckEnable();
                        m_pStart = Point.Empty;
                        m_pCurrent.Clear();
                        m_pLast.Clear();

                        m_bClicked = false;
                    };

                    sbX.MouseMove += (object sender, MouseEventArgs e) =>
                    {
                        Win32API.ReleaseCapture();
                        //((SnakeBox)sender).BackColor = m_bClicked ? Color.Red : Color.Empty;
                        Point pEnd = ((SnakeBox)sender).Coordinate;

                        if (m_bClicked)
                        {
                            if (m_daDraw == DrawAction.Block && !m_sbMap[pEnd.Y][pEnd.X].IsBody && !m_sbMap[pEnd.Y][pEnd.X].IsHead && !m_sbMap[pEnd.Y][pEnd.X].IsTail)
                            {
                                if (e.Button == MouseButtons.Left)
                                {
                                    m_sbMap[pEnd.Y][pEnd.X].IsWall = true;
                                    if (!m_pWallLoc.Contains(pEnd))
                                    {
                                        m_pWallLoc.Add(pEnd);
                                        m_pUndo.Add(new List<Point>() { pEnd });
                                        m_pRedo.Clear();
                                        //Console.WriteLine("---");
                                        //Console.WriteLine("UCount-" + m_pUndo.Count.ToString());
                                        //Console.WriteLine("WCount-" + m_pWallLoc.Count.ToString());
                                        //Console.WriteLine("---");
                                        
                                    }
                                }
                                else if (e.Button == MouseButtons.Right)
                                {
                                    m_sbMap[pEnd.Y][pEnd.X].IsWall = false; //.BackColor = Color.FromKnownColor(KnownColor.Control);
                                    m_pWallLoc.RemoveAll(item => item == pEnd);
                                }
                                Undo_CheckEnable();
                                //UndoRedoStruct uds = new UndoRedoStruct(new List<Point>() { pEnd }, new List<Point>(m_pLast));
                                //m_lurDo.Add(uds);

                            }
                            else if (m_daDraw == DrawAction.DrawRectangle || m_daDraw == DrawAction.FillRectangle || m_daDraw == DrawAction.Line)
                            {
                                if (m_daDraw == DrawAction.Line)
                                {
                                    m_pCurrent = Map_CalLineDraw(m_pStart, pEnd);
                                    m_pCurrent.Reverse();
                                }
                                else
                                {
                                    m_pCurrent = Map_CalRectDraw(m_pStart, pEnd);
                                }

                                List<Point> lpSame = new List<Point>(m_pCurrent);
                                lpSame.Intersect(m_pLast);

                                List<Point> lpClear = new List<Point>(m_pLast);
                                lpClear.Except(lpSame);

                                List<Point> lpDraw = new List<Point>(m_pCurrent);
                                lpDraw.Except(lpSame);

                                lpClear.RemoveAll(item => m_sbMap[item.Y][item.X].IsWall);

                                lpDraw.RemoveAll(item => m_sbMap[item.Y][item.X].IsWall);
                                lpDraw.RemoveAll(item => m_sbiSnake.Select(snake => snake.Coordinate).ToList().Contains(new Point(item.Y, item.X)));

                                lpClear.ForEach(item => m_sbMap[item.Y][item.X].IsWall = false);//.BackColor = Color.FromKnownColor(KnownColor.Control));

                                Color cC = Color.Lime;
                                if (e.Button == MouseButtons.Right)
                                {
                                    cC = Color.Yellow;
                                }
                                lpDraw.ForEach(item => m_sbMap[item.Y][item.X].BackColor = cC);

                                if (m_daDraw == DrawAction.FillRectangle)
                                {
                                    m_pCurrent = Map_CalRectFill(m_pStart, pEnd);
                                }
                                m_pCurrent.RemoveAll(item => m_sbiSnake.Select(snake => snake.Coordinate).ToList().Contains(new Point(item.Y, item.X)));
                                m_pLast = m_pCurrent;
                            }
                        }

                    };

                    sbY.Add(sbX);
                }
                m_sbMap.Add(sbY);
            }


            //Map_CalLineDraw(new Point(10,8), new Point(1,0)).ForEach(item => m_sbMap[item.Y][item.X].BackColor = Color.PowderBlue);
            //Map_CalRectFill(new Point(5,4), new Point(3,2));
            //Map_CalRectDraw(new Point(5,4), new Point(3,2));
        }

        void Map_CheckMouse(Rectangle rect, Point cursor)
        {
            if (!rect.Contains(cursor))
            {
                Map_DrawingClear();
            }
        }

        void Snake_Init()
        {
            if (m_sbiSnake.Count == 0)
            {
                int iCenter = (m_meMap.Width - 1) / 2 - (m_meMap.SnakeLength) / 2;
                for (int i = 0; i < m_meMap.SnakeLength; i++)
                {
                    Point pSnake = new Point((m_meMap.Height - 1) / 2, iCenter + i);
                    SnakeBodyInfo sbi = new SnakeBodyInfo();
                    sbi.Box = m_sbMap[pSnake.X][pSnake.Y];
                    sbi.Coordinate = pSnake;

                    if (i > 0 && i < m_meMap.SnakeLength - 1)
                    {
                        sbi.Box.BodyDirection = new List<SnakeDirection>() { SnakeDirection.Right, SnakeDirection.Right, SnakeDirection.Right };
                        sbi.Box.Invoke((Action)delegate()
                        {
                        sbi.Box.IsBody = true;
                        });
                    }
                    m_sbiSnake.Add(sbi);
                }
                m_sbiSnake[0].Box.Invoke((Action)delegate()
                {
                m_sbiSnake[m_sbiSnake.Count - 1].Box.IsHead = true;
                m_sbiSnake[0].Box.TailDirection = SnakeDirection.Right;
                m_sbiSnake[0].Box.IsTail = true;
                });
            }
            else if (m_sbiSnake.Count > 0)
            {
                m_sbiSnake[0].Box.Invoke((Action)delegate()
                {
                m_sbiSnake[0].Box.TailDirection = SnakeDirection.Right;
                m_sbiSnake[0].Box.IsTail = true;
                m_sbiSnake[m_sbiSnake.Count - 1].Box.IsHead = true;
                });

                for (int i = 1; i < m_sbiSnake.Count-1; i++)
                {
                    m_sbiSnake[i].Box.BodyDirection = new List<SnakeDirection>() { SnakeDirection.Right, SnakeDirection.Right, SnakeDirection.Right };
                    m_sbiSnake[i].Box.Invoke((Action)delegate()
                    {
                    m_sbiSnake[i].Box.IsBody = true;

                    });
                }
            }
        }

        void Wall_Init()
        {
            if (m_pWallLoc.Count > 0)
            {

                m_pWallLoc.ForEach(delegate(Point item)
                {
                    m_sbMap[item.Y][item.X].Invoke((Action)delegate()
                    {
                        m_sbMap[item.Y][item.X].IsWall = true;
                    });
                });
            }
            
        }


        #region MapDrawFunc
        List<Point> Map_CalRectFill(Point start, Point end)
        {
            int x1 = (end.X - start.X) < 0 ? end.X : start.X;
            int y1 = (end.Y - start.Y) < 0 ? end.Y : start.Y;

            int x2 = (end.X - start.X) < 0 ? start.X : end.X;
            int y2 = (end.Y - start.Y) < 0 ? start.Y : end.Y;

            List<Point> pList = new List<Point>();
            //X and Y is reversed

            for (int y = y1; y <= y2; y++)
            {
                for (int x = x1; x <= x2; x++)
                {
                    pList.Add(new Point(x, y));
                }
            }

            return pList;
        }

        List<Point> Map_CalRectDraw(Point start, Point end)
        {

            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;

            //2,5   3,1
            //2,1  3,5
            //2   2
            if (start.X <= end.X)
            {
                if (start.Y <= end.Y)
                {
                    x1 = start.X;
                    y1 = start.Y;
                    x2 = end.X;
                    y2 = end.Y;
                }
                else if (start.Y > end.Y)
                {
                    x1 = start.X;
                    y1 = end.Y;
                    x2 = end.X;
                    y2 = start.Y;
                }
            }
            //5,2   3,4
            //3,2  5,4

                //5,4   3,2
            //3,2 5,4
            else if (start.X > end.X)
            {
                if (start.Y <= end.Y)
                {
                    x1 = end.X;
                    y1 = start.Y;
                    x2 = start.X;
                    y2 = end.Y;
                }
                else if (start.Y > end.Y)
                {
                    x1 = end.X;
                    y1 = end.Y;
                    x2 = start.X;
                    y2 = start.Y;
                }

            }

            List<Point> pList = new List<Point>();

            for (int y = y1; y <= y2; y++)
            {
                for (int x = x1; x <= x2; x++)
                {
                    if (x == x1)
                    {
                        pList.Add(new Point(x, y));
                    }
                    else if (x == x2)
                    {
                        pList.Add(new Point(x, y));
                    }
                    else if (x > x1 && x < x2)
                    {
                        if (y == y1)
                        {
                            pList.Add(new Point(x, y));
                        }
                        else if (y == y2)
                        {
                            pList.Add(new Point(x, y));
                        }
                    }
                }
            }

            //pList.ForEach(item => Console.WriteLine(item.X.ToString() + "  " + item.Y.ToString()));

            return pList;
        }

        List<Point> Map_CalLineDraw(Point start, Point end)
        {

            if (start == end)
            {
                return new List<Point>() { start };
            }

            //6,5 9,1

            int x1 = start.X;//< end.X ? start.X : end.X;
            int y1 = start.Y;//< end.Y ? start.Y : end.Y;
            int x2 = end.X;//< start.X ? start.X : end.X;
            int y2 = end.Y;//< start.Y ? start.Y : end.Y;

            double m = 0.00;
            if ((x2 - x1) != 0) //y?
            {
                m = (double)(y2 - y1) / (double)(x2 - x1);
            }
            else if ((x2 - x1) == 0)
            {
                m = 0.00;
            }

            double c = y1 - m * x1;

            //y=mx+c

            double y = 0.00;
            double diff = 0.00;

            double d = 0.00;

            int fl = 0;

            List<Point> lp = new List<Point>();

            bool bx = (x1 <= x2);

            if (x1 != x2)
            {
                for (int x = x1; bx ? x <= x2 : x >= x2; x = bx ? x + 1 : x - 1)
                {
                    y = m * x + c;

                    if (y >= 0)
                    {
                        fl = (int)Math.Floor(y);
                        diff = y - fl;

                        if (diff != 0)
                        {
                            //Console.WriteLine((x - 1).ToString() + "," + fl.ToString() + " " + x.ToString() + "," + fl.ToString());

                            if (!lp.Contains(new Point(x - 1, fl)) && (x - 1) >= 0)
                            {
                                lp.Add(new Point(x - 1, fl));
                            }
                            if (!lp.Contains(new Point(x, fl)))
                            {
                                lp.Add(new Point(x, fl));
                            }


                        }
                        else if (diff == 0)
                        {
                            //Console.WriteLine(x.ToString() + "," + y.ToString());
                            if (!lp.Contains(new Point(x, (int)y)))
                            {
                                lp.Add(new Point(x, (int)y));
                            }
                        }
                    }
                }
            }

            if (y1 != y2)
            {
                bool by = (y1 <= y2);


                if (m != 0)
                {
                    for (int dx = y1; by ? dx <= y2 : dx >= y2; dx = by ? dx + 1 : dx - 1)
                    {
                        d = (double)(dx - c) / m;
                        if (d >= 0)
                        {
                            fl = (int)Math.Floor(d);
                            diff = d - fl;
                            if (diff != 0)
                            {
                                //Console.WriteLine(fl.ToString() + "," + (dx - 1).ToString() + " " + fl.ToString() + "," + dx.ToString());
                                if (!lp.Contains(new Point(fl, dx - 1)) && (dx - 1) >= 0)
                                {
                                    lp.Add(new Point(fl, dx - 1));
                                }
                                if (!lp.Contains(new Point(fl, dx)))
                                {
                                    lp.Add(new Point(fl, dx));
                                }
                            }


                            else if (diff == 0)
                            {
                                //Console.WriteLine(fl.ToString() + "," + dx.ToString());
                                if (!lp.Contains(new Point(fl, dx)))
                                {
                                    lp.Add(new Point(fl, dx));
                                }
                            }
                        }
                    }
                }
                else if (m == 0 && x1 == x2)
                {
                    for (int dy = y1; by ? dy <= y2 : dy >= y2; dy = by ? dy + 1 : dy - 1)
                    {
                        if (!lp.Contains(new Point(x1, dy)))
                        {
                            lp.Add(new Point(x1, dy));
                        }
                    }
                }


            }


            //lp.ForEach(item =>m_sbMap[item.Y][item.X].BackColor = Color.PowderBlue);
            //lp.ForEach(item => Console.WriteLine(item.ToString()));
            return lp;

        }

        void Map_DrawingClear()
        {
            //m_pCurrent.ForEach(item => m_sbMap[item.Y][item.X].BackColor = Color.FromKnownColor(KnownColor.Control));
            m_pStart = Point.Empty;
            m_pLast.Clear();
            m_bClicked = false;
        }

        #endregion

        #endregion

        #region MapEditorCon
        void MapEditor_Dock()
        {
            pnlMapEditorCon.Dock = DockStyle.Fill;
        }

        void MapEditor_Visible(bool isShow)
        {
            pnlMapEditorCon.Visible = isShow;
        }

        #endregion

        #region ToolBarFunc
        void Back_ToSkin()
        {
            if (m_tMapGen.ThreadState != ThreadState.Aborted)
            {
                m_tMapGen.Abort();
            }

            m_daDraw = DrawAction.Block;
            m_bClicked = false;


            m_sbMap.Clear();
            pnlMapBoxCon.Controls.Clear();

            m_sbiSnake.Clear();
            m_pWallLoc.Clear();



            m_pUndo.Clear();
            m_pCurrent.Clear();
            m_pStart = new Point();
            m_pRedo.Clear();
            m_pLast.Clear();

            MapEditor_Visible(false);
            InfoEditor_Visible(true);
        }

        void DrawingAct_Init()
        {
            m_tsbExDrawing = new ToolStripButton[]
            {
            tsbtnBlock,
            tsbtnRectDraw,
            tsbtnRectFill,
            tsbtnLine
            };
        }

        void DrawingAct_Exclusive(object sender)
        {
            foreach (ToolStripButton tsb in m_tsbExDrawing)
            {
                tsb.Checked = (tsb == (ToolStripButton)sender);
            }
        }

        
        void Map_Undo()
        {
            ////Console.WriteLine(m_lurDo.Count.ToString());
            //m_lurDo[m_lurDo.Count - 1].Current.ForEach(item => m_sbMap[item.Y][item.X].IsWall = false); //.BackColor = Color.FromKnownColor(KnownColor.Control));
            //m_pWallLoc.RemoveAll(item => m_lurDo[m_lurDo.Count - 1].Current.Contains(item));

            //UndoRedoStruct uds = new UndoRedoStruct();
            //uds.Last = m_lurDo[m_lurDo.Count - 1].Current;
            //if (m_lurDo.Count >= 2)
            //{
            //    uds.Current = m_lurDo[m_lurDo.Count - 2].Current;
            //    m_lurDo[m_lurDo.Count - 2] = uds;
            //}
            //m_lurDo.RemoveAt(m_lurDo.Count - 1);


            m_pUndo[m_pUndo.Count - 1].ForEach(item => m_sbMap[item.Y][item.X].IsWall = false);
            m_pWallLoc.RemoveAll(item => m_pUndo[m_pUndo.Count - 1].Contains(item));

            //Console.WriteLine("---");
            //m_pUndo.SelectMany(item=>item).ToList().ForEach(item => Console.WriteLine("U-" + item.ToString()));
            //m_pWallLoc.ForEach(item => Console.WriteLine("W-" + item.ToString()));
            //Console.WriteLine("---");

            m_pRedo.Add(m_pUndo[m_pUndo.Count-1]);

            m_pUndo.RemoveAt(m_pUndo.Count - 1);
            Undo_CheckEnable();
        }

        void Undo_CheckEnable()
        {

            if (m_pUndo.Count >0)
            {
                tsbtnUndo.Enabled = true;
            }
            else
            {
                tsbtnUndo.Enabled = false;
            }

            Redo_CheckEnable();

            //if (m_lurDo.Count > 0)
            //{
            //    tsbtnUndo.Enabled = true;
            //}
            //else
            //{
            //    tsbtnUndo.Enabled = false;
            //}
        }

        void Map_Redo()
        {
            m_pRedo[m_pRedo.Count - 1].ForEach( delegate(Point item)
            {
                m_sbMap[item.Y][item.X].IsWall = true;
                if (!m_pWallLoc.Contains(item))
                {
                    m_pWallLoc.Add(item);
                }
            }
            );


            m_pUndo.Add(m_pRedo[m_pRedo.Count - 1]);
            m_pRedo.RemoveAt(m_pRedo.Count - 1);
            Redo_CheckEnable();
        }

        void Redo_CheckEnable()
        {
            if (m_pRedo.Count > 0)
            {
                tsbtnRedo.Enabled = true;
            }
            else
            {
                tsbtnRedo.Enabled = false;
            }
        }


        void Map_Save()
        {
            m_meMap.SnakeBodyPoint = m_sbiSnake.Select(item => item.Coordinate).ToList();
            m_meMap.WallPoint = new List<Point>(m_pWallLoc);

            //

            m_meMap.Save();
            
        }
        #endregion

        #endregion

        #region Main
        #region MainUI
        void Title_SetText(string text)
        {
            this.Text = text;
        }


        void UIString_Init()
        {
            this.Text = UIString.MapEditorForm.FormTitle;

            lblCaption.Text = UIString.MapEditorForm.MainScreenTitle;
            btnNewMap.Text = UIString.MapEditorForm.MainScreenNewBtn;
            btnLoadMap.Text = UIString.MapEditorForm.MainScreenLoadBtn;

            epnlMapInfo.Caption = UIString.MapEditorForm.SideMapInfoTitle;
            ctbMapName.Caption = UIString.MapEditorForm.SideMapInfoName;
            ctbMapWidth.Caption = UIString.MapEditorForm.SideMapInfoWidth;
            ctbMapHeight.Caption = UIString.MapEditorForm.SideMapInfoHeight;
            ctbMapBlockSize.Caption = UIString.MapEditorForm.SideMapInfoBlockSize;
            ctbMapSnakeLength.Caption = UIString.MapEditorForm.SideMapInfoSnakeInitLength;
            ctbMapInterval.Caption = UIString.MapEditorForm.SideMapInfoInterval;

            epnlThemeInfo.Caption = UIString.MapEditorForm.SideThemeInfoTitle;
            btnThemeBack.Text = UIString.MapEditorForm.SideThemeInfoBackColor;
            btnThemeFore.Text = UIString.MapEditorForm.SideThemeInfoForeColor;

            tsbtnBackToHome.Text = UIString.MapEditorForm.SkinToolBarBackToHome;
            tsbtnDefault.Text = UIString.MapEditorForm.SkinToolBarReloadDefault;
            tsbtnGenMap.Text = UIString.MapEditorForm.SkinToolBarGenNewMap;

            epnlSkinInfo.Caption = UIString.MapEditorForm.SkinInfoTitle;
            lblSkinHelp.Text = UIString.MapEditorForm.SkinInfoHelp;
            btnImportSkin.Text = UIString.MapEditorForm.SkinInfoBatchImport;

            epSkinPreviewBody.Caption  = UIString.MapEditorForm.SkinPreviewBody;
            epSkinPreviewEatHead  .Caption  = UIString.MapEditorForm.SkinPreviewEatHead;
            epSkinPreviewFatBody  .Caption  = UIString.MapEditorForm.SkinPreviewFatBody;
            epSkinPreviewFood.Caption = UIString.MapEditorForm.SkinPreviewFood;
            epSkinPreviewHead.Caption = UIString.MapEditorForm.SkinPreviewHead;
            epSkinPreviewTail.Caption = UIString.MapEditorForm.SkinPreviewTail;
            epSkinPreviewTurn.Caption = UIString.MapEditorForm.SkinPreviewTurnBody;
            epSkinPreviewTurnFat.Caption = UIString.MapEditorForm.SkinPreviewFatTurnBody;
            epSkinPreviewWall.Caption = UIString.MapEditorForm.SkinPreviewWall;

            tsbtnBackToSkin.Text = UIString.MapEditorForm.MapToolBarBackToSkin;
            tsbtnMapSave.Text = UIString.MapEditorForm.MapToolBarSave;

        }
        #endregion

        #region MainFunc
        #region Saving

        void Infos_Save()
        {
            Save_MapInfo();
            //Other will save when user edit
        }

        void Save_MapInfo()
        {
            int i;
            Int32.TryParse(ctbMapBlockSize.Text, out i);
            m_meMap.BlockSize = i;

            Int32.TryParse(ctbMapHeight.Text, out i);
            m_meMap.Height = i;

            Int32.TryParse(ctbMapSnakeLength.Text, out i);
            m_meMap.SnakeLength = i;

            Int32.TryParse(ctbMapWidth.Text, out i);
            m_meMap.Width = i;

            Int32.TryParse(ctbMapInterval.Text, out i);
            m_meMap.Interval = i;

            m_meMap.Name = ctbMapName.Text;
        }
        #endregion

        #region ErrorWarningList
        void ErrorWarning_Resize(Control Container, PictureListBox plb)
        {
            plb.Location = new Point(3, 15);
            plb.Width = Container.Width - 6;
        }

        void ErrorWarning_Clear(PictureListBox plb)
        {
            plb.Items.Clear();
            plb.Images.Clear();
        }

        void ErrorWarning_InitImage(PictureListBox plb)
        {
            for (int i = 0; i < plb.Items.Count; i++)
            {
                plb.Images.Add(new Object());
            }
        }

        void ErrorWarning_AddItemsAndImage(PictureListBox plb, string text, Image img)
        {
            plb.Items.Add(text);
            plb.Images.Add(img);
        }
        #endregion

        #endregion

        #endregion
    }
}

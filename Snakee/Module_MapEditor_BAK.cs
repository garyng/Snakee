using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using CustomPictureBox;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Globalization;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace Snakee
{
    public partial class frmMapEditor_Bak
    {
        class SnakeeSkinDefault
        {
            public static string Tail = "iVBORw0KGgoAAAANSUhEUgAAAAgAAAAICAYAAADED76LAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAADJJREFUKFNj/P//PwNeAFKAAwOFIZIwAFOIJITQjSKIzEE2HqsibPZjtQKnQlw+gIsDAJWJxTxHMSdFAAAAAElFTkSuQmCC";
            public static string Head = "iVBORw0KGgoAAAANSUhEUgAAAAgAAAAICAYAAADED76LAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAADJJREFUKFNj/P//PwMQgAksgJEBqAADgDRAAYKFTSHYdBwSZJoAdSzIwWBMtBX43MEAAMpnzDYbwvtDAAAAAElFTkSuQmCC";
            public static string HeadEat = "iVBORw0KGgoAAAANSUhEUgAAAAgAAAAICAYAAADED76LAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAADpJREFUKFNj/P//PwMQgAk0wAjmAxWgACQhkBymAiTVZCqAugdkEKYJMEmoO1AVIEuiK8DwCdShYBMA0AO2TJj/ElYAAAAASUVORK5CYII=";
            public static string Body = "iVBORw0KGgoAAAANSUhEUgAAAAgAAAAICAYAAADED76LAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAADRJREFUKFNj/P//PwNeAFQABkBFMCYKDRcFKcCmCEUbNkUY5qKbglUBsiKsLkNXAFKEEwMAMsK/QlIMeJcAAAAASUVORK5CYII=";
            public static string Turn = "iVBORw0KGgoAAAANSUhEUgAAAAgAAAAICAYAAADED76LAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAADlJREFUKFNj/M8ABP/BJCZgZATJQZUAGdgAWAFIAmwOFgBXgEsRigJsijAUoCvCqgBZEQNO10FVAQC0I8Q/GC++8wAAAABJRU5ErkJggg==";
            public static string TurnFat = "iVBORw0KGgoAAAANSUhEUgAAAAgAAAAICAYAAADED76LAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAADNJREFUKFNj/A8EDLgAIyMjA1QBiMIKwArwKYIrwKUIRQE2RRgK0BVhVYCsCKQApyKQ/wFcqs03vJVzWgAAAABJRU5ErkJggg==";
            public static string BodyFat = "iVBORw0KGgoAAAANSUhEUgAAAAgAAAAICAYAAADED76LAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAADhJREFUKFNj/P//PwMQgAksgJEBqAAMQIqwARQF2BShaINahWIQhrnopmBVgKwIq8vQFWB3PtRzAIxfxjw4FjH8AAAAAElFTkSuQmCC";
            public static string Food = "iVBORw0KGgoAAAANSUhEUgAAAAgAAAAICAYAAADED76LAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAADhJREFUKFNj+P//PwOD2v8SIP6PhkvAcjgkYYpLQApgnFIgGxlDxNEUICsmTwHMinK4yQQdScibAHjqgZft/u8GAAAAAElFTkSuQmCC";
            public static string Wall = "iVBORw0KGgoAAAANSUhEUgAAAAgAAAAICAYAAADED76LAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAC9JREFUKFNj/M/AAER4AEgBGANJFAwVB2mHSCIrQhLDlEBTSIICvFYQdCTMJ1hoANu5iXhRDp+SAAAAAElFTkSuQmCC";
        }
        //Use Default Skin


        List<List<SnakeBox>> m_lstMap = new List<List<SnakeBox>>();

        List<PictureBox> m_picPreBody = new List<PictureBox>();
        List<PictureBox> m_picPreBodyFat = new List<PictureBox>();
        List<PictureBox> m_picPreHead = new List<PictureBox>();
        List<PictureBox> m_picPreHeadEat = new List<PictureBox>();
        List<PictureBox> m_picPreTail = new List<PictureBox>();
        List<PictureBox> m_picPreTurning = new List<PictureBox>();
        List<PictureBox> m_picPreTurningFat = new List<PictureBox>();
        PictureBox m_picFood = new PictureBox();
        PictureBox m_picWall = new PictureBox();

        struct EMapInfo
        {
            public int Width;
            public int Height;
            public int PixelPerUnit;

            public string Name;
            public int Interval;
            public int SnakeLength;

        }

        EMapInfo m_emiMap = new EMapInfo();

        struct ESnakeeSkin
        {
            public string BodyDRp;
            public string BodyFatDRp;
            public string HeadRp;
            public string HeadEatRp;
            public string TailRp;
            public string TurnURp;
            public string TurnFatURp;
            public string Foodp;
            public string Wallp;

            public Color Background;
            public Color Foreground;

        }

        ESnakeeSkin m_essSkin = new ESnakeeSkin();
        Skin m_sbsSkin = new Skin();

        frmBlank m_fmbMap = new frmBlank();
        frmBlank m_fmbZoom = new frmBlank();
        frmBlank m_fmbTools = new frmBlank();
        frmBlank m_fmbSave = new frmBlank();

        int m_iMainLeft = 0;


        enum PaintAction
        {
            Wall, Body, Tail, Head
        }

        PaintAction m_paPaint = PaintAction.Wall;

        bool m_bPaintClickedPic = false;
        bool m_bPaintClickedEraser = false;

        List<SnakeBodyInfo> m_sbiSnake = new List<SnakeBodyInfo>();
        List<Point> m_pWallLoc = new List<Point>();

        string m_strSavePath = "";

        void All_Init()
        {
            m_iMainLeft = this.Left;
            Theme_Reload(m_essSkin.Background, m_essSkin.Foreground);
            MapInfo_Load();
        }

        void MapInfo_Load()
        {
            m_emiMap.Height = Convert.ToInt32(ctbMapHeight.Text);
            m_emiMap.Width = Convert.ToInt32(ctbMapWidth.Text);
            m_emiMap.PixelPerUnit = Convert.ToInt32(ctbMapPixelSize.Text);
            m_emiMap.Name = ctbMapName.Text;
            m_emiMap.Interval = Convert.ToInt32(ctbSnakeInterval.Text);
            m_emiMap.SnakeLength = Convert.ToInt32(ctbSnakeLength.Text);
        }

        //void Skin_Init()
        //{
        //    Skin_LoadImage();
        //    Skin_RotateImage();
        //    m_sbsSkin.Foreground = m_essSkin.Foreground;
        //    m_sbsSkin.Background = m_essSkin.Background;
        //}

        void Skin_LoadDefault()
        {
            m_sbsSkin.Tail_R = Image_ConvertFromB64(SnakeeSkinDefault.Tail);
            m_sbsSkin.Head_R = Image_ConvertFromB64(SnakeeSkinDefault.Head);
            m_sbsSkin.HeadEat_R = Image_ConvertFromB64(SnakeeSkinDefault.HeadEat);
            m_sbsSkin.Body_DR = Image_ConvertFromB64(SnakeeSkinDefault.Body);
            m_sbsSkin.BodyFat_DR = Image_ConvertFromB64(SnakeeSkinDefault.BodyFat);
            m_sbsSkin.Turn_UR = Image_ConvertFromB64(SnakeeSkinDefault.Turn);
            m_sbsSkin.TurnFat_UR = Image_ConvertFromB64(SnakeeSkinDefault.TurnFat);
            m_sbsSkin.Food = Image_ConvertFromB64(SnakeeSkinDefault.Food);
            m_sbsSkin.Wall = Image_ConvertFromB64(SnakeeSkinDefault.Wall);

            Body_Rot();
            BodyFat_Rot();
            Head_Rot();
            HeadEat_Rot();
            Tail_Rot();
            Turn_Rot();
            TurnFat_Rot();

            Preview_Body(true);
            Preview_BodyFat(true);
            Preview_Food(true);
            Preview_Head(true);
            Preview_HeadEat(true);
            Preview_Tail(true);
            Preview_Turn(true);
            Preview_TurnFat(true);
            Preview_Wall(true);
        }

        void Skin_LoadImage()
        {
            LoadImage_Wall();
            LoadImage_Food();
        }

        void LoadImage_Wall()
        {
            m_sbsSkin.Wall = Image_Load(m_essSkin.Wallp);
        }

        void LoadImage_Food()
        {
            m_sbsSkin.Food = Image_Load(m_essSkin.Foodp);

        }

        void Skin_RotateImage()
        {
            RotateImage_Tail();
            RotateIamge_Head();
            RotateImage_HeadEat();
            RotateImage_Body();
            RotateImage_BodyFat();
            RotateImage_Turn();
            RotateImage_TurnFat();
        }

        void RotateImage_Tail()
        {
            m_sbsSkin.Tail_R = Image_Load(m_essSkin.TailRp);
            Tail_Rot();
        }

        void Tail_Rot()
        {
            m_sbsSkin.Tail_L = PFunc.Image_Rotate(m_sbsSkin.Tail_R, RotateFlipType.RotateNoneFlipX);
            m_sbsSkin.Tail_U = PFunc.Image_Rotate(m_sbsSkin.Tail_R, RotateFlipType.Rotate270FlipNone);
            m_sbsSkin.Tail_D = PFunc.Image_Rotate(m_sbsSkin.Tail_R, RotateFlipType.Rotate90FlipNone);
        }

        void RotateIamge_Head()
        {
            m_sbsSkin.Head_R = Image_Load(m_essSkin.HeadRp);
            Head_Rot();
        }

        void Head_Rot()
        {
            m_sbsSkin.Head_L = PFunc.Image_Rotate(m_sbsSkin.Head_R, RotateFlipType.RotateNoneFlipX);
            m_sbsSkin.Head_U = PFunc.Image_Rotate(m_sbsSkin.Head_R, RotateFlipType.Rotate270FlipNone);
            m_sbsSkin.Head_D = PFunc.Image_Rotate(m_sbsSkin.Head_R, RotateFlipType.Rotate90FlipNone);
        }

        void RotateImage_HeadEat()
        {
            m_sbsSkin.HeadEat_R = Image_Load(m_essSkin.HeadEatRp);
            HeadEat_Rot();
        }

        void HeadEat_Rot()
        {
            m_sbsSkin.HeadEat_U = PFunc.Image_Rotate(m_sbsSkin.HeadEat_R, RotateFlipType.Rotate270FlipNone);
            m_sbsSkin.HeadEat_D = PFunc.Image_Rotate(m_sbsSkin.HeadEat_R, RotateFlipType.Rotate90FlipNone);
            m_sbsSkin.HeadEat_L = PFunc.Image_Rotate(m_sbsSkin.HeadEat_R, RotateFlipType.RotateNoneFlipX);
        }

        void RotateImage_Body()
        {
            m_sbsSkin.Body_DR = Image_Load(m_essSkin.BodyDRp);
            Body_Rot();
        }

        void Body_Rot()
        {
            m_sbsSkin.Body_DL = PFunc.Image_Rotate(m_sbsSkin.Body_DR, RotateFlipType.RotateNoneFlipX);
            m_sbsSkin.Body_UR = PFunc.Image_Rotate(m_sbsSkin.Body_DR, RotateFlipType.Rotate90FlipNone);
            m_sbsSkin.Body_UL = PFunc.Image_Rotate(m_sbsSkin.Body_DR, RotateFlipType.Rotate90FlipY);
        }

        void RotateImage_BodyFat()
        {
            m_sbsSkin.BodyFat_DR = Image_Load(m_essSkin.BodyFatDRp);
            BodyFat_Rot();
        }

        void BodyFat_Rot()
        {
            m_sbsSkin.BodyFat_DL = PFunc.Image_Rotate(m_sbsSkin.BodyFat_DR, RotateFlipType.RotateNoneFlipX);
            m_sbsSkin.BodyFat_UR = PFunc.Image_Rotate(m_sbsSkin.BodyFat_DR, RotateFlipType.Rotate90FlipNone);
            m_sbsSkin.BodyFat_UL = PFunc.Image_Rotate(m_sbsSkin.BodyFat_DR, RotateFlipType.Rotate90FlipY);
        }

        void RotateImage_Turn()
        {
            m_sbsSkin.Turn_UR = Image_Load(m_essSkin.TurnURp);
            Turn_Rot();
        }

        void Turn_Rot()
        {
            m_sbsSkin.Turn_DR = PFunc.Image_Rotate(m_sbsSkin.Turn_UR, RotateFlipType.RotateNoneFlipY);
            m_sbsSkin.Turn_DL = PFunc.Image_Rotate(m_sbsSkin.Turn_UR, RotateFlipType.RotateNoneFlipXY);
            m_sbsSkin.Turn_UL = PFunc.Image_Rotate(m_sbsSkin.Turn_UR, RotateFlipType.RotateNoneFlipX);
        }

        void RotateImage_TurnFat()
        {
            m_sbsSkin.TurnFat_UR = Image_Load(m_essSkin.TurnFatURp);
            TurnFat_Rot();
        }

        void TurnFat_Rot()
        {
            m_sbsSkin.TurnFat_DL = PFunc.Image_Rotate(m_sbsSkin.TurnFat_UR, RotateFlipType.RotateNoneFlipXY);
            m_sbsSkin.TurnFat_UL = PFunc.Image_Rotate(m_sbsSkin.TurnFat_UR, RotateFlipType.RotateNoneFlipX);
            m_sbsSkin.TurnFat_DR = PFunc.Image_Rotate(m_sbsSkin.TurnFat_UR, RotateFlipType.RotateNoneFlipY);
        }

        /// <summary>
        /// 1st : Error
        /// 2nd : Warning
        /// </summary>
        /// <returns></returns>
        List<string> Infos_CheckValid()
        {
            string strError = "";
            string strWarning = "";
            if (Skin_CheckAllLoaded() == false)
            {
                strError += "Snakee's Skin Not Loaded" + Environment.NewLine;
                //MessageBox.Show("Can You Please Fill Up The Snakee's Skin?" + Environment.NewLine + "He Felt Cold As He Didn't Wear Anything :D", "Give Me A Shirt", MessageBoxButtons.OK);
            }
            if (Map_CheckWidtHeight() == false)
            {
                strWarning += "Map's Width And Height Too Large" + Environment.NewLine;
            }
            if (Map_CheckPixelPerUnit() == false)
            {
                strWarning += "Map's Pixel Per Unit Too Large" + Environment.NewLine;
            }
            if (Snake_CheckLength() == false)
            {
                strError += "Snake's Length Must Longer Than 3" + Environment.NewLine;
            }
            if (Interval_Check() == false)
            {
                strWarning += "Snake Moving Interval Too Long" + Environment.NewLine;
            }
            return new List<string>() { strError, strWarning };
        }

        bool Map_CheckWidtHeight()
        {
            if (m_emiMap.Width > 60 || m_emiMap.Height > 60)
            {
                return false;
            }
            return true;
        }

        bool Map_CheckPixelPerUnit()
        {
            if (m_emiMap.PixelPerUnit > 32)
            {
                return false;
            }
            return true;
        }

        bool Skin_CheckAllLoaded()
        {
            FieldInfo[] fiSkin = m_sbsSkin.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
            foreach (FieldInfo fi in fiSkin)
            {
                if (fi.GetValue(m_sbsSkin) == null)
                {
                    return false;
                }
            }

            return true;
        }

        bool Snake_CheckLength()
        {
            if (m_emiMap.SnakeLength <= 3)
            {
                return false;
            }
            return true;
        }

        bool Interval_Check()
        {
            if (m_emiMap.Interval > 1000)
            {
                return false;
            }
            return true;
        }

        bool TextBox_CheckNumeric(Keys ToCheck)
        {
            if (ToCheck >= Keys.D0 && ToCheck <= Keys.D9 || ToCheck == Keys.Back)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool Prompt_CheckInfo()
        {
            List<string> str = Infos_CheckValid();
            String strToShow = "";
            if (str[0] != "")
            {
                strToShow = "Errors:" + Environment.NewLine + str[0];
            }
            if (str[1] != "")
            {
                strToShow += "Warnings: " + Environment.NewLine + str[1];
            }

            if (str[0] != "")
            {
                MessageBox.Show(strToShow, "Error(s) Found!", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            else if (str[1] != "" && str[0] == "")
            {
                strToShow += Environment.NewLine + Environment.NewLine + "Continue?";
                if (MessageBox.Show(strToShow, "Warning!", MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }

        }

        void GenerateMap_Init()
        {
            MapInfo_Load();
            m_sbsSkin.Foreground = m_essSkin.Foreground;
            m_sbsSkin.Background = m_essSkin.Background;
            if (Prompt_CheckInfo() == false)
            {
                return;
            }

            Map_CreateNew();
            Snake_Init();
        }

        void Map_Reset()
        {
            m_fmbMap.Dispose();
            m_fmbMap = new frmBlank();
            m_lstMap.Clear();
            m_sbiSnake.Clear();
            m_pWallLoc.Clear();
        }

        void Map_CreateNew()
        {
            Main_Move(true);
            Map_Reset();
            #region Generate Map
            for (int y = 0; y < m_emiMap.Width; y++)
            {
                List<SnakeBox> sbBoX = new List<SnakeBox>();
                for (int x = 0; x < m_emiMap.Height; x++)
                {
                    SnakeBox sbX = new SnakeBox(m_sbsSkin);
                    sbX.Size = new Size(m_emiMap.PixelPerUnit, m_emiMap.PixelPerUnit);
                    sbX.Coordinate = new Point(x, y);
                    //sbX.BorderStyle = BorderStyle.FixedSingle;
                    sbX.BackColor = m_essSkin.Background;
                    sbX.MouseDown += (object sender, MouseEventArgs e) =>
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                m_bPaintClickedPic = true;
                            }
                            else if (e.Button == MouseButtons.Right)
                            {
                                m_bPaintClickedEraser = true;
                            }

                        };

                    sbX.MouseMove += (object sender, MouseEventArgs e) =>
                        {
                            if (m_bPaintClickedPic == true)
                            {
                                Win32API.ReleaseCapture();
                                if (Painting_IsSnake((SnakeBox)sender) == false)
                                {
                                    if (Painting_IsWallExist((SnakeBox)sender) == false)
                                    {
                                        Point pBox = ((SnakeBox)sender).Coordinate;
                                        m_pWallLoc.Add(pBox);
                                    }
                                    ((SnakeBox)sender).IsWall = true;

                                }
                            }
                            else if (m_bPaintClickedEraser == true)
                            {
                                Win32API.ReleaseCapture();
                                if (Painting_IsSnake((SnakeBox)sender) == false)
                                {
                                    Painting_RemoveWall((SnakeBox)sender);
                                    ((SnakeBox)sender).IsWall = false;
                                }
                            }
                            Console.WriteLine(m_pWallLoc.Count.ToString());
                        };

                    sbX.MouseUp += (object sender, MouseEventArgs e) =>
                        {
                            m_bPaintClickedPic = false;
                            m_bPaintClickedEraser = false;
                        };

                    if (x == 0)
                    {
                        if (y == 0)
                        {
                            sbX.Location = new Point(5, 5);
                        }
                        else
                        {
                            sbX.Top = m_lstMap[y - 1][0].Bottom + 1;
                            sbX.Left = m_lstMap[y - 1][0].Left;
                        }
                    }
                    else
                    {
                        sbX.Left = sbBoX[x - 1].Right + 1;
                        sbX.Top = sbBoX[x - 1].Top;
                    }
                    m_fmbMap.Controls.Add(sbX);

                    sbBoX.Add(sbX);
                }
                m_lstMap.Add(sbBoX);
            }
            #endregion


            MapViewer_Show();

            DrawingTools_Show();

            SaveMap_Show();
            Main_Move(false);
        }

        void Main_Move(bool Reverse)
        {
            if (Reverse == false)
            {
                m_iMainLeft = this.Left;
                this.Left = m_fmbMap.Right;
            }
            else
            {
                this.Left = m_iMainLeft;
            }
        }

        void MapViewer_Show()
        {
            m_fmbMap.Width = (m_emiMap.Width + 1) * m_emiMap.PixelPerUnit + (m_fmbMap.Width - m_fmbMap.ClientSize.Width) + m_emiMap.Width;
            m_fmbMap.Height = (m_emiMap.Height + 1) * m_emiMap.PixelPerUnit + (m_fmbMap.Height - m_fmbMap.ClientSize.Height) + m_emiMap.Height;
            m_fmbMap.StartPosition = FormStartPosition.Manual;
            m_fmbMap.Left = this.Left;
            m_fmbMap.Top = this.Top;
            m_fmbMap.MinimumSize = m_fmbMap.Size;
            m_fmbMap.Text = "Snakee - Map Editor : Map Viewer";
            m_fmbMap.BackColor = m_sbsSkin.Foreground;
            m_fmbMap.MouseLeave += (object sender, EventArgs e) =>
            {
                if (m_fmbMap.Bounds.Contains(Cursor.Position) == false)
                {
                    m_bPaintClickedPic = false;
                    m_bPaintClickedEraser = false;
                }
            };
            m_fmbMap.MouseUp += (object sender, MouseEventArgs e) =>
            {
                m_bPaintClickedPic = false;
                m_bPaintClickedEraser = false;

            };
            m_fmbMap.Show();
        }

        void Snake_Init()
        {
            int iCenter = (m_emiMap.Width - 1) / 2 - (m_emiMap.SnakeLength - 1) / 2;
            for (int i = 0; i < m_emiMap.SnakeLength; i++)
            {
                Point pSnake = new Point((m_emiMap.Width - 1) / 2, iCenter + i);
                SnakeBodyInfo sbi = new SnakeBodyInfo();
                sbi.Box = m_lstMap[pSnake.X][pSnake.Y];
                sbi.Coordinate = pSnake;

                if (i > 0 && i < m_emiMap.SnakeLength - 1)
                {
                    sbi.Box.BodyDirection = new List<SnakeDirection>() { SnakeDirection.Right, SnakeDirection.Right, SnakeDirection.Right };
                    sbi.Box.IsBody = true;
                }
                m_sbiSnake.Add(sbi);
            }

            m_sbiSnake[m_sbiSnake.Count - 1].Box.IsHead = true;

            m_sbiSnake[0].Box.TailDirection = SnakeDirection.Right;
            m_sbiSnake[0].Box.IsTail = true;

        }

        bool Painting_IsSnake(SnakeBox ToCheck)
        {
            if (ToCheck.IsTail == true || ToCheck.IsHead == true || ToCheck.IsBody == true)
            {
                return true;
            }
            return false;
        }

        void Painting_RemoveWall(SnakeBox ToRemove)
        {
            m_pWallLoc.RemoveAll(item => item == ToRemove.Coordinate);
        }

        bool Painting_IsWallExist(SnakeBox ToCheck)
        {
            return m_pWallLoc.Any(item => ToCheck.Coordinate == item);
        }

        //bool Skin_CheckAllLoad()
        //{
        //    bool bIsAllLoaded = m_sbsSkin.Background == null || m_sbsSkin.Body_DL == null || m_sbsSkin.Body_DR == null || m_sbsSkin.Body_UL == null || m_sbsSkin.Body_UR == null || m_sbsSkin.BodyFat_DL == null || m_sbsSkin.BodyFat_DR == null || m_sbsSkin.BodyFat_UL == null || m_sbsSkin.BodyFat_UR == null || m_sbsSkin.Food == null || m_sbsSkin.Foreground == null || m_sbsSkin.Head_D == null || m_sbsSkin.Head_L == null || m_sbsSkin.Head_R == null || m_sbsSkin.Head_U == null || m_sbsSkin.HeadEat_D == null || m_sbsSkin.HeadEat_L == null || m_sbsSkin.HeadEat_R == null || m_sbsSkin.HeadEat_U == null || m_sbsSkin.Tail_D == null || m_sbsSkin.Tail_L == null || m_sbsSkin.Tail_R == null || m_sbsSkin.Tail_U == null || m_sbsSkin.Turn_DL == null || m_sbsSkin.Turn_DR == null || m_sbsSkin.Turn_UL == null || m_sbsSkin.Turn_UR == null || m_sbsSkin.TurnFat_DL == null || m_sbsSkin.TurnFat_DR == null || m_sbsSkin.TurnFat_UL == null || m_sbsSkin.TurnFat_UR == null || m_sbsSkin.Wall == null;
        //    return bIsAllLoaded;
        //}

        void Theme_Reload(Color Background, Color Foreground)
        {
            m_essSkin.Background = Background;
            m_essSkin.Foreground = Foreground;

            picBackFore.BackColor = m_essSkin.Background;
            StringFormat sfF = new StringFormat();
            sfF.LineAlignment = StringAlignment.Center;
            sfF.Alignment = StringAlignment.Center;
            String_Draw(picBackFore, "FORE", new Font("Segoe UI", 20), new SolidBrush(m_essSkin.Foreground), sfF);
        }

        void String_Draw(PictureBox PicDes, String Text, Font TextFont, SolidBrush TextColor, StringFormat TextFormat)
        {
            Bitmap bPic = new Bitmap(PicDes.Width, PicDes.Height);
            Graphics gPic = Graphics.FromImage(bPic);
            gPic.TextRenderingHint = TextRenderingHint.AntiAlias;
            gPic.DrawString(Text, TextFont, TextColor, PicDes.ClientRectangle, TextFormat);
            PicDes.Image = bPic;
        }

        void Preview_Body(bool bIsDef = false)
        {
            if (bIsDef == false) RotateImage_Body();

            if (m_picPreBody.Count > 0)
            {
                for (int i = 0; i < m_picPreBody.Count; i++)
                {
                    m_picPreBody[i].Dispose();
                }
            }
            m_picPreBody.Clear();

            for (int i = 0; i < 4; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Top = 5;
                if (i == 0)
                {
                    pic.Left = 5;
                }
                else if (i > 0)
                {
                    pic.Left = m_picPreBody[i - 1].Right + 5;
                }
                pic.Size = new Size(m_emiMap.PixelPerUnit, m_emiMap.PixelPerUnit);
                pic.Click += (object sender, EventArgs e) =>
                {
                    Zoom_Show(pic.Image);
                };
                m_picPreBody.Add(pic);
                pnlPreview.Controls.Add(pic);
            }

            m_picPreBody[0].Image = m_sbsSkin.Body_DR;
            m_picPreBody[1].Image = m_sbsSkin.Body_DL;
            m_picPreBody[2].Image = m_sbsSkin.Body_UR;
            m_picPreBody[3].Image = m_sbsSkin.Body_UL;

        }

        void Preview_BodyFat(bool bIsDef = false)
        {
            if (bIsDef == false) RotateImage_BodyFat();

            if (m_picPreBodyFat.Count > 0)
            {
                for (int i = 0; i < m_picPreBodyFat.Count; i++)
                {
                    m_picPreBodyFat[i].Dispose();
                }
            }
            m_picPreBodyFat.Clear();

            for (int i = 0; i < 4; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Top = 5 * 2 + m_emiMap.PixelPerUnit;
                if (i == 0)
                {
                    pic.Left = 5;
                }
                else if (i > 0)
                {
                    pic.Left = m_picPreBodyFat[i - 1].Right + 5;
                }
                pic.Size = new Size(m_emiMap.PixelPerUnit, m_emiMap.PixelPerUnit);
                pic.Click += (object sender, EventArgs e) =>
                {
                    Zoom_Show(pic.Image);
                };
                m_picPreBodyFat.Add(pic);
                pnlPreview.Controls.Add(pic);
            }

            m_picPreBodyFat[0].Image = m_sbsSkin.BodyFat_DR;
            m_picPreBodyFat[1].Image = m_sbsSkin.BodyFat_DL;
            m_picPreBodyFat[2].Image = m_sbsSkin.BodyFat_UR;
            m_picPreBodyFat[3].Image = m_sbsSkin.BodyFat_UL;

        }

        void Preview_Head(bool bIsDef = false)
        {
            if (bIsDef == false) RotateIamge_Head();

            if (m_picPreHead.Count > 0)
            {
                for (int i = 0; i < m_picPreHead.Count; i++)
                {
                    m_picPreHead[i].Dispose();
                }
            }
            m_picPreHead.Clear();

            for (int i = 0; i < 4; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Top = 5 * 3 + 2 * m_emiMap.PixelPerUnit;
                if (i == 0)
                {
                    pic.Left = 5;
                }
                else if (i > 0)
                {
                    pic.Left = m_picPreHead[i - 1].Right + 5;
                }
                pic.Size = new Size(m_emiMap.PixelPerUnit, m_emiMap.PixelPerUnit);
                pic.Click += (object sender, EventArgs e) =>
                {
                    Zoom_Show(pic.Image);
                };
                m_picPreHead.Add(pic);
                pnlPreview.Controls.Add(pic);
            }

            m_picPreHead[0].Image = m_sbsSkin.Head_D;
            m_picPreHead[1].Image = m_sbsSkin.Head_U;
            m_picPreHead[2].Image = m_sbsSkin.Head_L;
            m_picPreHead[3].Image = m_sbsSkin.Head_R;

        }

        void Preview_HeadEat(bool bIsDef = false)
        {
            if (bIsDef == false) RotateImage_HeadEat();

            if (m_picPreHeadEat.Count > 0)
            {
                for (int i = 0; i < m_picPreHeadEat.Count; i++)
                {
                    m_picPreHeadEat[i].Dispose();
                }
            }
            m_picPreHeadEat.Clear();

            for (int i = 0; i < 4; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Top = 5 * 4 + 3 * m_emiMap.PixelPerUnit;
                if (i == 0)
                {
                    pic.Left = 5;
                }
                else if (i > 0)
                {
                    pic.Left = m_picPreHeadEat[i - 1].Right + 5;
                }
                pic.Size = new Size(m_emiMap.PixelPerUnit, m_emiMap.PixelPerUnit);
                pic.Click += (object sender, EventArgs e) =>
                {
                    Zoom_Show(pic.Image);
                };
                m_picPreHeadEat.Add(pic);
                pnlPreview.Controls.Add(pic);
            }

            m_picPreHeadEat[0].Image = m_sbsSkin.HeadEat_D;
            m_picPreHeadEat[1].Image = m_sbsSkin.HeadEat_U;
            m_picPreHeadEat[2].Image = m_sbsSkin.HeadEat_L;
            m_picPreHeadEat[3].Image = m_sbsSkin.HeadEat_R;

        }

        void Preview_Tail(bool bIsDef = false)
        {
            if (bIsDef == false) RotateImage_Tail();

            if (m_picPreTail.Count > 0)
            {
                for (int i = 0; i < m_picPreTail.Count; i++)
                {
                    m_picPreTail[i].Dispose();
                }
            }
            m_picPreTail.Clear();

            for (int i = 0; i < 4; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Top = 5 * 5 + 4 * m_emiMap.PixelPerUnit;
                if (i == 0)
                {
                    pic.Left = 5;
                }
                else if (i > 0)
                {
                    pic.Left = m_picPreTail[i - 1].Right + 5;
                }
                pic.Size = new Size(m_emiMap.PixelPerUnit, m_emiMap.PixelPerUnit);
                pic.Click += (object sender, EventArgs e) =>
                {
                    Zoom_Show(pic.Image);
                };
                m_picPreTail.Add(pic);
                pnlPreview.Controls.Add(pic);
            }

            m_picPreTail[0].Image = m_sbsSkin.Tail_D;
            m_picPreTail[1].Image = m_sbsSkin.Tail_U;
            m_picPreTail[2].Image = m_sbsSkin.Tail_L;
            m_picPreTail[3].Image = m_sbsSkin.Tail_R;

        }

        void Preview_Turn(bool bIsDef = false)
        {
            if (bIsDef == false) RotateImage_Turn();

            if (m_picPreTurning.Count > 0)
            {
                for (int i = 0; i < m_picPreTurning.Count; i++)
                {
                    m_picPreTurning[i].Dispose();
                }
            }
            m_picPreTurning.Clear();

            for (int i = 0; i < 4; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Top = 5 * 6 + m_emiMap.PixelPerUnit * 5;
                if (i == 0)
                {
                    pic.Left = 5;
                }
                else if (i > 0)
                {
                    pic.Left = m_picPreTurning[i - 1].Right + 5;
                }
                pic.Size = new Size(m_emiMap.PixelPerUnit, m_emiMap.PixelPerUnit);
                pic.Click += (object sender, EventArgs e) =>
                {
                    Zoom_Show(pic.Image);
                };
                m_picPreTurning.Add(pic);
                pnlPreview.Controls.Add(pic);
            }


            m_picPreTurning[0].Image = m_sbsSkin.Turn_DR;
            m_picPreTurning[1].Image = m_sbsSkin.Turn_DL;
            m_picPreTurning[2].Image = m_sbsSkin.Turn_UR;
            m_picPreTurning[3].Image = m_sbsSkin.Turn_UL;

        }

        void Preview_TurnFat(bool bIsDef = false)
        {
            if (bIsDef == false) RotateImage_TurnFat();

            if (m_picPreTurningFat.Count > 0)
            {
                for (int i = 0; i < m_picPreTurningFat.Count; i++)
                {
                    m_picPreTurningFat[i].Dispose();
                }
            }
            m_picPreTurningFat.Clear();

            for (int i = 0; i < 4; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Top = 5 * 7 + m_emiMap.PixelPerUnit * 6;
                if (i == 0)
                {
                    pic.Left = 5;
                }
                else if (i > 0)
                {
                    pic.Left = m_picPreTurningFat[i - 1].Right + 5;
                }
                pic.Size = new Size(m_emiMap.PixelPerUnit, m_emiMap.PixelPerUnit);
                pic.Click += (object sender, EventArgs e) =>
                {
                    Zoom_Show(pic.Image);
                };
                m_picPreTurningFat.Add(pic);
                pnlPreview.Controls.Add(pic);
            }

            m_picPreTurningFat[0].Image = m_sbsSkin.TurnFat_DR;
            m_picPreTurningFat[1].Image = m_sbsSkin.TurnFat_DL;
            m_picPreTurningFat[2].Image = m_sbsSkin.TurnFat_UR;
            m_picPreTurningFat[3].Image = m_sbsSkin.TurnFat_UL;

        }

        void Preview_Food(bool bIsDef = false)
        {
            m_picFood.Dispose();
            if (bIsDef == false) LoadImage_Food();
            m_picFood = new PictureBox();
            m_picFood.Top = 5 * 8 + m_emiMap.PixelPerUnit * 7;
            m_picFood.Left = 5;
            m_picFood.Size = new Size(m_emiMap.PixelPerUnit, m_emiMap.PixelPerUnit);
            m_picFood.Image = m_sbsSkin.Food;
            m_picFood.Click += (object sender, EventArgs e) =>
            {
                Zoom_Show(m_sbsSkin.Food);
            };
            pnlPreview.Controls.Add(m_picFood);
        }

        void Preview_Wall(bool bIsDef = false)
        {
            m_picWall.Dispose();
            if (bIsDef == false) LoadImage_Wall();
            m_picWall = new PictureBox();

            m_picWall.Top = 5 * 9 + m_emiMap.PixelPerUnit * 8;
            m_picWall.Left = 5;
            m_picWall.Image = m_sbsSkin.Wall;
            m_picWall.Size = new Size(m_emiMap.PixelPerUnit, m_emiMap.PixelPerUnit);
            m_picWall.Click += (object sender, EventArgs e) =>
                {
                    Zoom_Show(m_sbsSkin.Wall);
                };
            pnlPreview.Controls.Add(m_picWall);
        }

        void Zoom_Show(Image image)
        {
            if (m_fmbZoom.Visible == true)
            {
                m_fmbZoom.Dispose();
            }
            if (image == null)
            {
                return;
            }
            m_fmbZoom = new frmBlank();
            ZoomBox zbZoom = new ZoomBox(image, 16);
            zbZoom.Location = Point.Empty;
            m_fmbZoom.Text = "Snakee - Map Editor : Zoom";
            m_fmbZoom.Controls.Add(zbZoom);
            m_fmbZoom.ClientSize = zbZoom.Size;
            m_fmbZoom.MinimumSize = m_fmbZoom.Size;
            m_fmbZoom.MaximumSize = m_fmbZoom.Size;
            m_fmbZoom.StartPosition = FormStartPosition.Manual;
            m_fmbZoom.Left = this.Right;
            m_fmbZoom.Top = this.Top;
            m_fmbZoom.ControlBox = true;
            m_fmbZoom.Show();

        }

        void DrawingTools_Show()
        {
            if (m_fmbTools.Visible == true)
            {
                gbMapPaint.Visible = false;
                gbMapPaint.Parent = this;
                this.Controls.Add(gbMapPaint);
                m_fmbTools.Dispose();
                m_fmbTools = new frmBlank();
            }
            gbMapPaint.Parent = m_fmbTools;
            gbMapPaint.Visible = true;
            gbMapPaint.Location = Point.Empty;
            m_fmbTools.ClientSize = gbMapPaint.Size;
            m_fmbTools.MinimumSize = m_fmbTools.Size;
            m_fmbTools.MaximumSize = m_fmbTools.Size;
            m_fmbTools.StartPosition = FormStartPosition.Manual;
            m_fmbTools.Left = m_fmbSave.Right + 30;
            m_fmbTools.Top = this.Bottom;
            m_fmbTools.Text = "Snakee - Map Editor : Painting Tools";
            m_fmbTools.Show();
        }

        void SaveMap_Show()
        {
            if (m_fmbSave.Visible == true)
            {
                gbSave.Visible = false;
                gbSave.Parent = this;
                m_fmbSave.Dispose();
                m_fmbSave = new frmBlank();
            }
            gbSave.Parent = m_fmbSave;
            gbSave.Visible = true;
            gbSave.Location = Point.Empty;
            m_fmbSave.ClientSize = gbSave.Size;
            m_fmbSave.MinimumSize = m_fmbSave.Size;
            m_fmbSave.MaximumSize = m_fmbSave.Size;
            m_fmbSave.StartPosition = FormStartPosition.Manual;
            m_fmbSave.Left = this.Left;
            m_fmbSave.Top = this.Bottom;
            m_fmbSave.Text = "Snakee - Map Editor : Save/Save As...";
            m_fmbSave.Show();


        }

        void Map_Save()
        {
            if (m_strSavePath == "")
            {
                m_strSavePath = SaveFile_Show("Snakee Map File|*.smap", "Map_" + m_emiMap.Name);
            }
            Save_Write();
        }

        void Map_SaveAs()
        {
            m_strSavePath = SaveFile_Show("Snakee Map File|*.smap", Path.GetFileName(m_strSavePath));
            Save_Write();
        }

        void Save_Write()
        {
            if (m_strSavePath == "")
            {
                return;
            }
            XmlTextWriter xtwS = new XmlTextWriter(m_strSavePath, Encoding.UTF8);
            xtwS.Formatting = Formatting.Indented;
            xtwS.WriteStartElement("Map");

            Save_MapInfo(xtwS);
            Save_ThemeInfo(xtwS);
            Save_SkinInfo(xtwS);
            Save_SnakeLoc(xtwS);
            Save_WallLoc(xtwS);

            xtwS.WriteEndElement();
            xtwS.Close();
        }

        void Save_MapInfo(XmlTextWriter xtw)
        {
            xtw.WriteStartElement("MapInfo");

            PFunc.XML_WriteElement(xtw, "Name", m_emiMap.Name);
            PFunc.XML_WriteElement(xtw, "Interval", m_emiMap.Interval.ToString());
            PFunc.XML_WriteElement(xtw, "Width", m_emiMap.Width.ToString());
            PFunc.XML_WriteElement(xtw, "Height", m_emiMap.Height.ToString());
            PFunc.XML_WriteElement(xtw, "SizePerUnit", m_emiMap.PixelPerUnit.ToString());
            PFunc.XML_WriteElement(xtw, "Snake Length", m_emiMap.SnakeLength.ToString());

            xtw.WriteEndElement();
        }

        void Save_ThemeInfo(XmlTextWriter xtw)
        {
            xtw.WriteStartElement("ThemeInfo");

            PFunc.XML_WriteElement(xtw, "Foreground", PFunc.Color_ToHexString(m_sbsSkin.Foreground));
            PFunc.XML_WriteElement(xtw, "Background", PFunc.Color_ToHexString(m_sbsSkin.Background));
                       
            xtw.WriteEndElement();
        }

        void Save_SkinInfo(XmlTextWriter xtw)
        {
            FieldInfo[] fiSkin = m_sbsSkin.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);

            xtw.WriteStartElement("SkinInfo");
            PFunc.XML_WriteElement(xtw,"ImageFormat","PNG");
            foreach (FieldInfo fi in fiSkin)
            {
                if (fi.FieldType == typeof(Image))
                {
                    Image img = (Image)fi.GetValue(m_sbsSkin);
                    string b64 = PFunc.Image_ToBase64(img, ImageFormat.Png);
                    PFunc.XML_WriteElement(xtw,fi.Name,b64);
                }
            }
            xtw.WriteEndElement();
        }

        void Save_SnakeLoc(XmlTextWriter xtw)
        {
            xtw.WriteStartElement("SnakeInfo");

            string str = string.Join(";",m_sbiSnake.Select(item=>item.Coordinate.ToString()).ToArray());
            PFunc.XML_WriteElement(xtw,"Loc",str);

            xtw.WriteEndElement();

        }

        void Save_WallLoc(XmlTextWriter xtw)
        {
            xtw.WriteStartElement("WallInfo");
            string str = string.Join(";",m_pWallLoc.ToArray());
            PFunc.XML_WriteElement(xtw, "Loc", str);
            xtw.WriteEndElement();

        }

        string SaveFile_Show(string Filter, string Filename)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.OverwritePrompt = true;
            sfd.Filter = Filter;
            sfd.FileName = Filename;
            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName != "")
            {
                return sfd.FileName;
            }
            else
            {
                return "";
            }
        }

        String OpenFile_Show(string Filter)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = Filter;
            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName != "")
            {
                return ofd.FileName;
            }
            else
            {
                return "";
            }
        }

        Image Image_Load(string Path)
        {
            if (Path != "")
            {
                Image i = Image.FromFile(Path);
                return i;
            }
            return null;
        }

        Image Image_ConvertFromB64(string Base64)
        {
            byte[] bImage = Convert.FromBase64String(Base64);
            MemoryStream ms = new MemoryStream(bImage, 0, bImage.Length);
            ms.Write(bImage, 0, bImage.Length);
            return Image.FromStream(ms, true);
        }
    }

}

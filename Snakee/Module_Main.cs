using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Text;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using CustomPictureBox;
using System.Threading.Tasks;


namespace Snakee
{

    public partial class frmMain
    {
        //int m_iColorThemeIndex = 1; //0 = Normal 1=Dark

        bool m_bNoBorder = true;   //Border

        //public static Color m_cPicBack = DefaultSkin.PicBackground; //Color.FromKnownColor(KnownColor.Control); //SnakeBox's Background Color=> Control, Black
        //public static SolidBrush m_sbStringBack = new SolidBrush(DefaultSkin.PicForeground);   //InfoBox's Background Color=> Black,White


        ///// <summary>
        ///// Map Width
        ///// </summary>
        //public static int m_iMapWidth = 41;
        //public static int m_iMapHeight = 20;


        ///// <summary>
        ///// Map Box Size, Snake Size
        ///// </summary>
        //public static int m_iMapBlockSize = 8;
        //public static int m_iSnakeInitLength = 30; //Snake Initial Length

        //public static int m_iInterval = 500;  //Snake Speed, Higher>Slower


        int m_iInfoBigFontSize = 20;
        int m_iInfoSmallFontSize = 12;

        bool m_bGod = false;

        enum ClickedAction
        {
            Resume, Pause, Start, Stop, None, Highscore, MapEditor,MapLoader,GodMode
        }
        ClickedAction m_caAct = ClickedAction.Start;

        enum PlayState
        {
            Started, Paused, Stopped, GameOver
        }
        /// <summary>
        /// Current Playing State
        /// </summary>
        PlayState m_psCurrent = PlayState.Stopped;



        /// <summary>
        /// Snake Current Moving Direction
        /// </summary>
        public static SnakeDirection m_sdCurrent = SnakeDirection.Right;
        public static SnakeDirection m_sdLast = SnakeDirection.Right;

        List<SnakeDirection> m_sdTurnLast = new List<SnakeDirection>() { SnakeDirection.Right, SnakeDirection.Right, SnakeDirection.Right };

        int m_iScore = 0;   //Score

        /// <summary>
        /// Snake's House
        /// </summary>
        List<List<SnakeBox>> m_sbMapBox = new List<List<SnakeBox>>();
        HashSet<SnakeBox> m_hsFoodMap = new HashSet<SnakeBox>();


        public static List<HighScoreInfo> m_hsiHighScore = new List<HighScoreInfo>();

        struct PlayerInfo
        {
            public string Name;
            public string Map;
            public string MapFileName;
        }
        PlayerInfo m_piPlayer = new PlayerInfo();

        XmlDocument m_xdXML = new XmlDocument();


        List<SnakeBodyInfo> m_sbiSnake = new List<SnakeBodyInfo>();
        List<SnakeBodyInfo> m_sbiTurningBody = new List<SnakeBodyInfo>();
        List<SnakeBodyInfo> m_sbiTurningFatBody = new List<SnakeBodyInfo>();
        List<SnakeBodyInfo> m_sbiFatBody = new List<SnakeBodyInfo>();
        List<SnakeBodyInfo> m_sbiWall = new List<SnakeBodyInfo>();

        Skin m_ssSkin = new Skin();
        MapInfo m_miMapInfo = new MapInfo();




        delegate void NoParams();
        Thread m_tMoving;
        Thread m_tMapInit;
        Thread m_tTipsShow;

        frmSplash m_fsSplash = new frmSplash();

        public static MapEditor m_meMap = new MapEditor();


        void All_Init()
        {
            //Show splash screen
            Splash_View(false);

            //DefaultSkin.Image_Init(); //Must be the first!
            //Skin_Init();

            XML_Init();
            HighScore_Init();


            //Reload when select map
            PlayerInfo_Init();

            Map_Load();



            StartScreen_Resize();
            m_tMoving = new Thread(Thread_SnakeMoving);
            InfoBox_Resize(true);
            StartScreen_Draw();
            m_caAct = ClickedAction.Start;

            Splash_View(true);

        }

        void Splash_View(bool Hide)
        {
            if (Hide == false)
            {
                this.Visible = false;
                m_fsSplash.Dispose();
                m_fsSplash = new frmSplash();
                m_fsSplash.Show();
            }
            else
            {
                m_fsSplash.Dispose();
                this.Visible = true;
            }
        }

        void StartScreen_Draw()
        {
            String_Draw(picInfoCon, UIString.MainForm.Start, m_iInfoBigFontSize, new List<String>() { "< " + UIString.MainForm.Name + PFunc.String_Limit(m_piPlayer.Name, 10) + "   " + UIString.MainForm.Map + PFunc.String_Limit(m_piPlayer.Map, 10) + " >", UIString.MainForm.HighScore, UIString.MainForm.MapEditor ,UIString.MainForm.MapLoader}, m_iInfoSmallFontSize, new SolidBrush(m_meMap.Foreground));
        }

        void StartScreen_Resize()
        {
            picInfoCon.Location = new Point(5, 5);

            //picSnakeCon.Size = new Size(m_miMapInfo.Width * m_miMapInfo.BlockSize + 15, m_miMapInfo.Height * m_miMapInfo.BlockSize + 15);

            picSnakeCon.Top = picInfoCon.Bottom + 5;
            picSnakeCon.Left = picInfoCon.Left;

            picInfoCon.Width = picSnakeCon.Width;

            this.ClientSize = new Size(picSnakeCon.Width + 10, picSnakeCon.Height + picInfoCon.Height + 20);

        }
        #region Init

        #region Map

        #region MapLoad

        void Map_Load()
        {
           Map_LoadFile();
           Map_LoadSkin();
           Map_LoadInfo();
        }

        void Map_LoadFile()
        {
            if (!File.Exists(m_piPlayer.MapFileName))
            {
                Map_Create();
            }
            m_meMap.Load(m_piPlayer.MapFileName);
        }

        void Map_Create()
        {
            MapEditor me = new MapEditor();
            me.LoadDefault();
            me.Name = "Default Map";
            me.SnakeBodyPoint = PFunc.Snakee_CalPoint(me.Width, me.Height, me.SnakeLength);
            me.Save("Default.smap");
        }

        void Map_LoadSkin()
        {
            m_ssSkin = m_meMap.SnakeeSkin;
            Theme_Apply();
        }

        void Map_LoadInfo()
        {
            m_miMapInfo = m_meMap.MapInfo;
        }


        #endregion


        void Map_Init()
        {

            for (int y = 0; y < m_miMapInfo.Height; y++)
            {
                List<SnakeBox> sbBoX = new List<SnakeBox>();
                for (int x = 0; x < m_miMapInfo.Width; x++)
                {
                    SnakeBox sbX = new SnakeBox(m_ssSkin);
                    sbX.Size = new Size(m_miMapInfo.BlockSize, m_miMapInfo.BlockSize);

                    //sbX.BorderStyle = BorderStyle.FixedSingle;
                    sbX.BackColor = m_meMap.Background;

                    if (x == 0)
                    {
                        if (y == 0)
                        {
                            sbX.Location = new Point(5, 5);
                        }
                        else
                        {
                            sbX.Top = m_sbMapBox[y - 1][0].Bottom;
                            sbX.Left = m_sbMapBox[y - 1][0].Left;
                        }
                    }
                    else
                    {
                        sbX.Left = sbBoX[x - 1].Right;
                        sbX.Top = sbBoX[x - 1].Top;
                    }


                    //if (Map_IsWall(x, y) == true && m_bNoBorder == false)
                    //{
                    //    sbX.IsWall = true;
                    //    SnakeBodyInfo sbi = new SnakeBodyInfo();
                    //    sbi.Box = sbX;
                    //    sbi.Coordinate = new Point(x,y);
                    //    m_sbiWall.Add(sbi);
                    //}

                    picSnakeCon.Invoke((Action)delegate()
                    {
                    picSnakeCon.Controls.Add(sbX);

                    });
                    sbBoX.Add(sbX);

                }
                m_sbMapBox.Add(sbBoX);
            }

            picInfoCon.Invoke((Action)delegate()
            {
                picInfoCon.Location = new Point(5, 5);

                picSnakeCon.Size = new Size(m_miMapInfo.Width * m_miMapInfo.BlockSize + 15, m_miMapInfo.Height * m_miMapInfo.BlockSize + 15);

                picSnakeCon.Top = picInfoCon.Bottom + 5;
                picSnakeCon.Left = picInfoCon.Left;

                picInfoCon.Width = picSnakeCon.Width;

            }
                );
            this.Invoke((Action)delegate()
            { 
                this.ClientSize = new Size(picSnakeCon.Width + 10, picSnakeCon.Height + picInfoCon.Height + 20);
            });

        }

        bool Map_IsWall(int iX, int iY)
        {
            if (iX == 0 || iX == m_miMapInfo.Width - 1)
            {
                if (iY > 0 && iY < m_miMapInfo.Height - 1)
                {
                    return true;
                }
            }
            if (iY == 0 || iY == m_miMapInfo.Height - 1)
            {
                return true;
            }
            return false;

        }

        void Map_DrawWall()
        {
            SnakeBodyInfo sbi = new SnakeBodyInfo();

            m_meMap.WallPoint.ForEach(delegate(Point item)
                {
                    sbi.Box = m_sbMapBox[item.Y][item.X];
                    sbi.Coordinate = new Point(item.Y, item.X);
                    m_sbiWall.Add(sbi);
                    m_sbMapBox[item.Y][item.X].Invoke((Action)delegate()
                    {
                        m_sbMapBox[item.Y][item.X].IsWall = true;

                    }
                    );
                }
                );
            
        }

        #endregion

        #region Skin
       
        void Skin_Init()
        {
            m_ssSkin.Background = DefaultSkin.PicBackground;
            m_ssSkin.Foreground = DefaultSkin.PicForeground;
            m_ssSkin.Body_DL = DefaultSkin.Body_DL;
            m_ssSkin.Body_DR = DefaultSkin.Body_DR;
            m_ssSkin.Body_UL = DefaultSkin.Body_UL;
            m_ssSkin.Body_UR = DefaultSkin.Body_UR;
            m_ssSkin.BodyFat_DL = DefaultSkin.BodyFat_DL;
            m_ssSkin.BodyFat_DR = DefaultSkin.BodyFat_DR;
            m_ssSkin.BodyFat_UL = DefaultSkin.BodyFat_UL;
            m_ssSkin.BodyFat_UR = DefaultSkin.BodyFat_UR;
            m_ssSkin.Food = DefaultSkin.Food;
            m_ssSkin.Head_D = DefaultSkin.Head_D;
            m_ssSkin.Head_L = DefaultSkin.Head_L;
            m_ssSkin.Head_R = DefaultSkin.Head_R;
            m_ssSkin.Head_U = DefaultSkin.Head_U;
            m_ssSkin.HeadEat_D = DefaultSkin.HeadEat_D;
            m_ssSkin.HeadEat_L = DefaultSkin.HeadEat_L;
            m_ssSkin.HeadEat_R = DefaultSkin.HeadEat_R;
            m_ssSkin.HeadEat_U = DefaultSkin.HeadEat_U;
            m_ssSkin.Tail_D = DefaultSkin.Tail_D;
            m_ssSkin.Tail_L = DefaultSkin.Tail_L;
            m_ssSkin.Tail_R = DefaultSkin.Tail_R;
            m_ssSkin.Tail_U = DefaultSkin.Tail_U;
            m_ssSkin.Turn_DL = DefaultSkin.Turn_DL;
            m_ssSkin.Turn_DR = DefaultSkin.Turn_DR;
            m_ssSkin.Turn_UL = DefaultSkin.Turn_UL;
            m_ssSkin.Turn_UR = DefaultSkin.Turn_UR;
            m_ssSkin.TurnFat_DL = DefaultSkin.TurnFat_DL;
            m_ssSkin.TurnFat_DR = DefaultSkin.TurnFat_DR;
            m_ssSkin.TurnFat_UL = DefaultSkin.TurnFat_UL;
            m_ssSkin.TurnFat_UR = DefaultSkin.TurnFat_UR;
            m_ssSkin.Wall = DefaultSkin.Wall;
            m_ssSkin.Food = DefaultSkin.Food;


        }

        #endregion

        #region Theme

        //void Theme_Init()
        //{
        //    if (m_iColorThemeIndex == 0)
        //    {
        //        m_cPicBack = Color.FromKnownColor(KnownColor.Control);
        //        m_sbStringBack = new SolidBrush(Color.Black);
        //    }
        //    else if (m_iColorThemeIndex == 1)
        //    {
        //        m_cPicBack = Color.Black;
        //        m_sbStringBack = new SolidBrush(Color.White);
        //    }

        //    Theme_Apply();
        //}

        void Theme_Apply()
        {
            picInfoCon.BackColor = m_meMap.Background;
            picSnakeCon.BackColor = m_meMap.Background;
            picStartCountDown.BackColor = m_meMap.Background;
            this.BackColor = m_meMap.Background;
        }

        #endregion

        #region Settings

        void Settings_Create()
        {

            XmlTextWriter xtwSetting = new XmlTextWriter("Settings.xml", Encoding.UTF8);
            xtwSetting.Formatting = Formatting.Indented;

            xtwSetting.WriteStartElement("Settings");


            xtwSetting.WriteStartElement("Highscore");
            {
                for (int i = 1; i < 11; i++)
                {
                    xtwSetting.WriteStartElement("No_" + i.ToString());

                    PFunc.XML_WriteElement(xtwSetting, "Name", "Player_" + i.ToString());
                    PFunc.XML_WriteElement(xtwSetting, "Score", (11 - i).ToString());
                    PFunc.XML_WriteElement(xtwSetting, "Map", "Map_" + i.ToString());
                    PFunc.XML_WriteElement(xtwSetting, "Rank", i.ToString());
                    xtwSetting.WriteEndElement();
                }

                xtwSetting.WriteEndElement();
            }

            xtwSetting.WriteStartElement("Player_Info");
            {
                PFunc.XML_WriteElement(xtwSetting, "Name", "Player");
                PFunc.XML_WriteElement(xtwSetting, "Map", "Default");
                PFunc.XML_WriteElement(xtwSetting, "MapFileName", "Default.smap");
                xtwSetting.WriteEndElement();
            }


            xtwSetting.WriteEndElement();

            xtwSetting.Close();
        }

        #endregion

        #region PlayerInfo

        void PlayerInfo_Init()
        {
            m_piPlayer.Name = PFunc.XML_Read(m_xdXML,"Settings/Player_Info/Name");
            m_piPlayer.Map = PFunc.XML_Read(m_xdXML, "Settings/Player_Info/Map");
            m_piPlayer.MapFileName = PFunc.XML_Read(m_xdXML, "Settings/Player_Info/MapFileName");

        }

        void PlayerInfo_Save()
        {
            PFunc.XML_Edit(m_xdXML, "Settings.xml", "Settings/Player_Info/Name", m_piPlayer.Name);
            PFunc.XML_Edit(m_xdXML, "Settings.xml", "Settings/Player_Info/Map", m_piPlayer.Map);
            PFunc.XML_Edit(m_xdXML, "Settings.xml", "Settings/Player_Info/MapFileName", m_piPlayer.MapFileName);
        }

        #endregion

        #region Highscore

        void HighScore_Init()
        {
            
            if (!File.Exists("Settings.xml"))
            {
                Settings_Create();
            }
            HighScore_Load();

        }

        void HighScore_Load()
        {
            for (int i = 1; i < 11; i++)
            {
                HighScoreInfo hsiInfo = new HighScoreInfo();
                hsiInfo.Name = PFunc.XML_Read(m_xdXML, "Settings/Highscore/No_" + i.ToString() + "/Name");
                hsiInfo.Score = Convert.ToInt32(PFunc.XML_Read(m_xdXML, "Settings/Highscore/No_" + i.ToString() + "/Score"));
                hsiInfo.Map = PFunc.XML_Read(m_xdXML, "Settings/Highscore/No_" + i.ToString() + "/Map");
                hsiInfo.Rank = Convert.ToInt32(PFunc.XML_Read(m_xdXML, "Settings/Highscore/No_" + i.ToString() + "/Rank"));
                m_hsiHighScore.Add(hsiInfo);
            }

        }

        #endregion

        #endregion

        #region Snake

        #region Load

        //void Snake_Init()
        //{
        //    int iCenter = (m_miMapInfo.Width - 1) / 2 - (m_miMapInfo.SnakeLength - 1) / 2;

        //    for (int i = 0; i < m_miMapInfo.SnakeLength; i++)
        //    {
        //        Point pSnake = new Point((m_miMapInfo.Height - 1) / 2, iCenter + i);

        //        //m_sbMapBox[pSnake.X][pSnake.Y].IsSnakeBody = true;

        //        //.
        //        SnakeBodyInfo sbi = new SnakeBodyInfo();
        //        sbi.Box = m_sbMapBox[pSnake.X][pSnake.Y];
        //        sbi.Coordinate = pSnake;

        //        if (i > 0 && i < m_miMapInfo.SnakeLength - 1)
        //        {
        //            sbi.Box.BodyDirection = new List<SnakeDirection>() { m_sdLast, m_sdCurrent };
        //            sbi.Box.IsBody = true;
        //        }
        //        m_sbiSnake.Add(sbi);
        //        //.

        //        //m_pSnakeLoc.Add(pSnake);
        //    }

        //    //.
        //    //Head
        //    m_sbiSnake[m_sbiSnake.Count - 1].Box.IsHead = true;
        //    //Tail
        //    m_sbiSnake[0].Box.TailDirection = m_sdCurrent;
        //    m_sbiSnake[0].Box.IsTail = true;
        //    //.
        //    Snake_GetRandomFood();

        //}

        void Snake_LoadDraw()
        {
            SnakeBodyInfo sbi = new SnakeBodyInfo();

            m_meMap.SnakeBodyPoint.ForEach(delegate(Point item)
            {
                sbi.Box = m_sbMapBox[item.X][item.Y];
                sbi.Coordinate = new Point(item.X,item.Y);
                m_sbiSnake.Add(sbi);
            }
            );

            m_sbiSnake[0].Box.Invoke((Action)delegate()
            {
            m_sbiSnake[m_sbiSnake.Count - 1].Box.IsHead = true;
            m_sbiSnake[0].Box.TailDirection = SnakeDirection.Right;
            m_sbiSnake[0].Box.IsTail = true;

            }
            );

            for (int i = 1; i < m_sbiSnake.Count - 1; i++)
            {
                m_sbiSnake[i].Box.BodyDirection = new List<SnakeDirection>() { SnakeDirection.Right, SnakeDirection.Right, SnakeDirection.Right };
                m_sbiSnake[i].Box.Invoke((Action)delegate()
                {
                m_sbiSnake[i].Box.IsBody = true;
                });
            }

            Food_Flatten();
            Snake_GetRandomFood();


        }


        #endregion

        #region SnakeFunc

        #region Checking

        bool Snake_IsWall(Point pToCheck)
        {
            if (m_bGod == true) return false;

            if (m_sbMapBox[pToCheck.X][pToCheck.Y].IsWall == true || m_sbMapBox[pToCheck.X][pToCheck.Y].IsBody == true)
            {
                return true;
            }
            return false;
        }

        bool Snake_IsPreEatFood(Point pToCheck)
        {
            try
            {
                return m_sbMapBox[pToCheck.X][pToCheck.Y].IsFood;
            }
            catch { }
            return false;
        }

        void FatBodyAndTurn_Draw()
        {
            //Remove the body that doesnt contain in the main snake's body list
            HashSet<SnakeBodyInfo> hsMain = new HashSet<SnakeBodyInfo>(m_sbiSnake);       //Increase efficiency alot

            List<SnakeBodyInfo> lstRemovedBody = new List<SnakeBodyInfo>(m_sbiFatBody);     //For the removed Fat body
            List<SnakeBodyInfo> lstRemovedTurn = new List<SnakeBodyInfo>(m_sbiTurningBody);
            List<SnakeBodyInfo> lstRemovedTurnFat = new List<SnakeBodyInfo>(m_sbiTurningFatBody);

            lstRemovedBody.RemoveAll(sbi => hsMain.Contains(sbi));
            lstRemovedTurn.RemoveAll(sbi => hsMain.Contains(sbi));
            lstRemovedTurnFat.RemoveAll(sbi => hsMain.Contains(sbi));

            List<int> lstBiggest = new List<int>() { lstRemovedBody.Count, lstRemovedTurn.Count, lstRemovedTurnFat.Count };   //For the loop
            lstBiggest.Sort();

            for (int i = 0; i < lstBiggest[lstBiggest.Count - 1]; i++)
            {
                if (i < lstRemovedBody.Count)
                {
                    lstRemovedBody[i].Box.IsFatBody = false;
                }
                if (i < lstRemovedTurn.Count)
                {
                    lstRemovedTurn[i].Box.IsTurning = false;
                }
                if (i < lstRemovedTurnFat.Count)
                {
                    lstRemovedTurnFat[i].Box.IsTurningFat = false;
                }
            }

            m_sbiFatBody.RemoveAll(sbi => !hsMain.Contains(sbi));

            m_sbiTurningBody.RemoveAll(sbi => !hsMain.Contains(sbi));
            m_sbiTurningFatBody.RemoveAll(sbi => !hsMain.Contains(sbi));
        }

        SnakeDirection Tail_Direction()
        {
            Point pTail = m_sbiSnake[0].Coordinate;
            Point pLastTail = m_sbiSnake[1].Coordinate;

            int iXDiff = pTail.X - pLastTail.X;
            int iYDiff = pTail.Y - pLastTail.Y;

            if (iYDiff == -1)
            {
                return SnakeDirection.Right;
            }
            else if (iYDiff == 1)
            {
                return SnakeDirection.Left;
            }
            else if (iXDiff == -1)
            {
                return SnakeDirection.Down;
            }
            else
            {
                return SnakeDirection.Up;
            }
        }

        #endregion

        #region Moving

        void Snake_Move()
        {

            List<Point> plNew = new List<Point>();


            //int iLastPoint = m_pSnakeLoc.Count - 1;
            //.
            int iLastPoint = m_sbiSnake.Count - 1;
            //.


            if (m_psCurrent != PlayState.Started)
            {
                return;
            }


            //Prevent Backwarding

            if (m_sdLast == SnakeDirection.Right && m_sdCurrent == SnakeDirection.Left)
            {
                m_sdCurrent = SnakeDirection.Right;
                return;
            }
            else if (m_sdLast == SnakeDirection.Left && m_sdCurrent == SnakeDirection.Right)
            {
                m_sdCurrent = SnakeDirection.Left;
                return;
            }
            else if (m_sdLast == SnakeDirection.Up && m_sdCurrent == SnakeDirection.Down)
            {
                m_sdCurrent = SnakeDirection.Up;
                return;
            }
            else if (m_sdLast == SnakeDirection.Down && m_sdCurrent == SnakeDirection.Up)
            {
                m_sdCurrent = SnakeDirection.Down;
                return;
            }




            if (m_sdCurrent == SnakeDirection.Right)
            {
                //.
                int iY = m_sbiSnake[iLastPoint].Coordinate.Y;
                //if ((iY + 2) > (MapInfo.m_iMapWidth - 1))
                //{
                //    iY = -1;
                //}
                plNew.Add(new Point(m_sbiSnake[iLastPoint].Coordinate.X, (iY + 1) > (m_miMapInfo.Width - 1) ? 0 : iY + 1));
                plNew.Add(new Point(m_sbiSnake[iLastPoint].Coordinate.X, (iY + 2) > (m_miMapInfo.Width - 1) ? 1 : iY + 2));

                plNew.Add(new Point(m_sbiSnake[iLastPoint].Coordinate.X, m_sbiSnake[iLastPoint].Coordinate.Y));
                //.


            }
            else if (m_sdCurrent == SnakeDirection.Up)
            {
                //.
                int iX = m_sbiSnake[iLastPoint].Coordinate.X;
                //if ((iX - 2) < 0)
                //{
                //    iX = MapInfo.m_iMapWidth;
                //}
                plNew.Add(new Point((iX - 1) < 0 ? m_miMapInfo.Height - 1 : iX - 1, m_sbiSnake[iLastPoint].Coordinate.Y));
                plNew.Add(new Point((iX - 2) < 0 ? m_miMapInfo.Height - 2 : iX - 2, m_sbiSnake[iLastPoint].Coordinate.Y));

                plNew.Add(new Point(m_sbiSnake[iLastPoint].Coordinate.X, m_sbiSnake[iLastPoint].Coordinate.Y));

                //.

                
            }
            else if (m_sdCurrent == SnakeDirection.Down)
            {
                //.
                int iX = m_sbiSnake[iLastPoint].Coordinate.X;
                //if ((iX + 2) > (MapInfo.m_iMapWidth - 1))
                //{
                //    iX = -1;
                //}
                plNew.Add(new Point((iX + 1) > (m_miMapInfo.Height - 1) ? 0 : iX + 1, m_sbiSnake[iLastPoint].Coordinate.Y));
                plNew.Add(new Point((iX + 2) > (m_miMapInfo.Height - 1) ? 1 : iX + 2, m_sbiSnake[iLastPoint].Coordinate.Y));

                plNew.Add(new Point(m_sbiSnake[iLastPoint].Coordinate.X, m_sbiSnake[iLastPoint].Coordinate.Y));
                //.
               
            }
            else if (m_sdCurrent == SnakeDirection.Left)
            {
                //.
                int iY = m_sbiSnake[iLastPoint].Coordinate.Y;
                //if ((iY - 2) < 0)
                //{
                //    iY = MapInfo.m_iMapWidth;
                //}
                plNew.Add(new Point(m_sbiSnake[iLastPoint].Coordinate.X, (iY - 1) < 0 ? m_miMapInfo.Width - 1 : iY - 1));
                plNew.Add(new Point(m_sbiSnake[iLastPoint].Coordinate.X, (iY - 2) < 0 ? m_miMapInfo.Width - 2 : iY - 2));
                                                                                                            
                plNew.Add(new Point(m_sbiSnake[iLastPoint].Coordinate.X, m_sbiSnake[iLastPoint].Coordinate.Y));
                //.

            }

            if (Snake_IsWall(plNew[0]) == true)
            {

                m_psCurrent = PlayState.GameOver;
                Action_Stop(true);
            }

            Snake_DrawBody(plNew, Snake_IsFood(plNew[0]));

            m_sdLast = m_sdCurrent;


        }

        #region Forward
        void Thread_SnakeMoving()
        {
            for (; ; )
            {
                if (m_tMoving.ThreadState == ThreadState.SuspendRequested)
                {
                    return;
                }
                Thread.Sleep(m_miMapInfo.Interval);
                this.Invoke(new NoParams(Snake_MovingFoward));
            }
        }

        void Snake_MovingFoward()
        {
            Snake_Move();
            txtKeyInput.Focus();
        }
        #endregion


        #endregion

        #region Drawing
        
        void Snake_DrawBody(List<Point> plNew, bool bIsFood)
        {

            //Untail
            m_sbiSnake[0].Box.IsTail = false;

            //Unbody the body for the tail
            m_sbiSnake[1].Box.IsBody = false;

            //Unhead
            m_sbiSnake[m_sbiSnake.Count - 1].Box.IsHead = false;
            //Last time eat head status
            m_sbiSnake[m_sbiSnake.Count - 1].Box.IsEatHead = false;
            //Rebody
            m_sbiSnake[m_sbiSnake.Count - 1].Box.BodyDirection = m_sdTurnLast;
            m_sbiSnake[m_sbiSnake.Count - 1].Box.IsBody = true;


            //New head
            SnakeBodyInfo sbi = new SnakeBodyInfo();
            sbi.Box = m_sbMapBox[plNew[0].X][plNew[0].Y];
            sbi.Coordinate = plNew[0];


            if (bIsFood == false)
            {
                if (Snake_IsPreEatFood(plNew[1]) == true)
                {
                    sbi.Box.IsEatHead = true;
                }
                else
                {
                    sbi.Box.IsHead = true;
                }
                m_sbiSnake.Add(sbi);
            }
            else if (bIsFood == true)
            {
                m_sdTurnLast = new List<SnakeDirection>() { m_sdLast, m_sdCurrent };
                //Unfood
                m_sbMapBox[plNew[0].X][plNew[0].Y].IsFood = false;

                //The first body
                sbi.Box.BodyDirection = m_sdTurnLast;
                sbi.Box.IsBody = true;
                m_sbiSnake.Add(sbi);

                //The head
                SnakeBodyInfo sbiH = new SnakeBodyInfo();
                sbiH.Box = m_sbMapBox[plNew[1].X][plNew[1].Y];
                sbiH.Coordinate = plNew[1];
                sbiH.Box.IsHead = true;
                m_sbiSnake.Add(sbiH);

                //Get new food & add score
                Snake_GetRandomFood();
                Score_Add(1);

                //add the fat body
                SnakeBodyInfo sbiFat = new SnakeBodyInfo();

                sbiFat.Box = m_sbMapBox[plNew[2].X][plNew[2].Y]; // sbiH.Box;  //share same box with the head,  but cannot draw the background yet
                sbiFat.Coordinate = plNew[2];// sbiH.Coordinate;
                sbiFat.Box.BodyFatDirection = m_sdTurnLast;
                sbiFat.Box.IsFatBody = true;
                m_sbiFatBody.Add(sbiFat);
            }

            //Turning
            if (m_sdCurrent != m_sdLast)
            {
                m_sdTurnLast = new List<SnakeDirection>() { m_sdLast, m_sdCurrent };
                SnakeBodyInfo sbiTurn = new SnakeBodyInfo();
                sbiTurn.Box = m_sbMapBox[plNew[2].X][plNew[2].Y];
                sbiTurn.Coordinate = plNew[2];

                if (bIsFood == false)
                {
                    sbiTurn.Box.TurningDirection = m_sdTurnLast;
                    sbiTurn.Box.IsTurning = true;
                    m_sbiTurningBody.Add(sbiTurn);
                }
                else if (bIsFood == true)
                {
                    sbiTurn.Box.TurningFatDirection = m_sdTurnLast;
                    sbiTurn.Box.IsTurningFat = true;
                    m_sbiTurningFatBody.Add(sbi);
                }
            }
            //Remove tail
            m_sbiSnake.RemoveAt(0);
            //Draw tail, and it need to be after removeat...
            m_sbiSnake[0].Box.TailDirection = Tail_Direction();
            m_sbiSnake[0].Box.IsTail = true;

            FatBodyAndTurn_Draw();
            if (m_sbiTurningBody.Count == 0 && m_sdLast == m_sdCurrent)
            {
                m_sdTurnLast = new List<SnakeDirection>() { m_sdLast, m_sdCurrent };
            }

            if (m_bGod)
            {
                Snake_GetRandomFood();
            }


        }

        #endregion

        #endregion

        #region Food

        #region Init

        void Food_Flatten()
        {
            //Flatten the map
            List<SnakeBox> lstFlat = m_sbMapBox.SelectMany(item => item).ToList();  //Flatten the 2D list to 1D
            m_hsFoodMap = new HashSet<SnakeBox>(lstFlat);
            //Remove the wall
            m_hsFoodMap.RemoveWhere(food =>
                m_sbiWall.Any(wall =>
                wall.Box == food
                )
                );
        }
        
        #endregion

        #region FoodChecking

        bool Snake_IsFood(Point pToCheck)
        {
            return m_sbMapBox[pToCheck.X][pToCheck.Y].IsFood;
        }

        #endregion

        #region FoodFunc
        void Snake_GetRandomFood()
        {
            HashSet<SnakeBox> hsFoodClone = new HashSet<SnakeBox>(m_hsFoodMap);
            hsFoodClone.RemoveWhere(food =>
                m_sbiSnake.Any(body =>
                    body.Box == food
                )
                );
            List<SnakeBox> lstMap = hsFoodClone.ToList();   //Convert to List
            Random rRnd = new Random();
            int iRnd = rRnd.Next(0, hsFoodClone.Count);
            lstMap[iRnd].Invoke((Action)delegate()
            {

                Food_Draw(lstMap[iRnd]);
            }
            );
        }

        void Food_Draw(Point pFood)
        {
            m_sbMapBox[pFood.X][pFood.Y].IsFood = true;
        }

        void Food_Draw(SnakeBox sbFood)
        {
            sbFood.IsFood = true;
        }

        #endregion

        #endregion

        #endregion

        #region XML
        
        void XML_Init()
        {
            try
            {
                m_xdXML = new XmlDocument();
                m_xdXML.Load("Settings.xml");
            }
            catch
            {
                Settings_Create();
                m_xdXML.Load("Settings.xml"); 
            }
        }

        #endregion

        #region InfoBox

        #region UIFunc

        void InfoBox_Resize(bool Maximize)
        {
            if (Maximize == true)
            {
                picInfoCon.Height = picInfoCon.Height + picSnakeCon.Height + 10;
            }
            else
            {
                picInfoCon.Height = 50;
            }

        }

        #endregion

        #region DoAction

        void InfoBox_DoAction()
        {
            if (m_caAct == ClickedAction.Start)
            {
                Action_Start();
            }
            else if (m_caAct == ClickedAction.Pause)
            {
                Action_Pause();
            }
            else if (m_caAct == ClickedAction.Stop)
            {
                Action_Stop(false);
            }
            else if (m_caAct == ClickedAction.Highscore)
            {
                Action_HighScore();
            }
            else if (m_caAct == ClickedAction.MapEditor)
            {
                Action_MapEditor();
            }
            else if (m_caAct == ClickedAction.MapLoader)
            {
                Action_MapLoader();
            }
            else if (m_caAct == ClickedAction.Resume)
            {
                Action_Resume();
            }
            else if (m_caAct == ClickedAction.GodMode)
            {
                Action_GodMode();
            }
        }

        #region Action

        void Action_Restart()
        {


            Splash_View(false);
            InfoBox_Resize(false);

            picSnakeCon.Controls.Clear();

            m_caAct = ClickedAction.Start;
            m_psCurrent = PlayState.Stopped;

            m_sdCurrent = SnakeDirection.Right;
            m_sdLast = SnakeDirection.Right;
            m_sdTurnLast = new List<SnakeDirection>() { SnakeDirection.Right, SnakeDirection.Right, SnakeDirection.Right };
            m_sbMapBox = new List<List<SnakeBox>>();
            m_hsFoodMap = new HashSet<SnakeBox>();

            m_iScore = 0;

            m_hsiHighScore = new List<HighScoreInfo>();

            m_xdXML = new XmlDocument();


            m_sbiSnake = new List<SnakeBodyInfo>();
            m_sbiTurningBody = new List<SnakeBodyInfo>();
            m_sbiTurningFatBody = new List<SnakeBodyInfo>();
            m_sbiFatBody = new List<SnakeBodyInfo>();
            m_sbiWall = new List<SnakeBodyInfo>();

            m_ssSkin = new Skin();
            m_miMapInfo = new MapInfo();


            XML_Init();
            HighScore_Init();
            PlayerInfo_Init();

          
            Map_Load();

           

            m_tMoving = new Thread(Thread_SnakeMoving);
            InfoBox_Resize(true);
            StartScreen_Draw();
            Splash_View(true);

           
        }

        #region Highscore
        
        void Action_HighScore()
        {
            frmHighScore fhs = new frmHighScore();
            fhs.ShowDialog(this);
        }

        bool Highscore_Compare()
        {
            if (m_iScore > m_hsiHighScore[0].Score)
            {
                return true;
            }
            return false;
        }

        void Highscore_Add()
        {
            HighScoreInfo hsiNew = new HighScoreInfo();
            hsiNew.Name = m_piPlayer.Name;
            hsiNew.Map = m_piPlayer.Map;
            hsiNew.Score = m_iScore;

            m_hsiHighScore.Add(hsiNew);
            m_hsiHighScore = m_hsiHighScore.OrderByDescending(hsi => hsi.Score).ToList();
            m_hsiHighScore.RemoveAt(m_hsiHighScore.Count - 1);
        }

        void Highscore_Renew()
        {
            for (int i = 0; i < m_hsiHighScore.Count; i++)
            {
                PFunc.XML_Edit(m_xdXML,"Settings.xml","Settings/Highscore/No_" + (i + 1).ToString() + "/Name", m_hsiHighScore[i].Name);
                PFunc.XML_Edit(m_xdXML, "Settings.xml", "Settings/Highscore/No_" + (i + 1).ToString() + "/Score", m_hsiHighScore[i].Score.ToString());
                PFunc.XML_Edit(m_xdXML, "Settings.xml", "Settings/Highscore/No_" + (i + 1).ToString() + "/Map", m_hsiHighScore[i].Map);
                PFunc.XML_Edit(m_xdXML, "Settings.xml", "Settings/Highscore/No_" + (i + 1).ToString() + "/Rank", m_hsiHighScore[i].Rank.ToString());
            }
        }

        int Highscore_Rank()
        {
            List<HighScoreInfo> hsi = new List<HighScoreInfo>(m_hsiHighScore);
            hsi.RemoveAll(item => item.Rank != 0);
            if (hsi.Count == 0)
            {
                return -1;
            }

            int index = m_hsiHighScore.IndexOf(hsi[0]);
            if (index < 0)
            {
                return -1;
            }
            Highscore_RankRenew();
            return m_hsiHighScore[index].Rank;
        }

        void Highscore_RankRenew()
        {
            HighScoreInfo hsi = new HighScoreInfo();
            for (int i = 0; i < m_hsiHighScore.Count; i++)
            {
                hsi = m_hsiHighScore[i];
                hsi.Rank = i + 1;
                m_hsiHighScore[i] = hsi;

            }
        }


        #endregion

        void Action_MapLoader()
        {
            frmMapLoader fml = new frmMapLoader();
            fml.ShowDialog(this);
            if (fml.SelectedMap == "")
            {
                return;
            }
            
            m_meMap = fml.MapEditor;
            Map_LoadSkin();
            Map_LoadInfo();
            m_piPlayer.Map = m_meMap.Name;
            m_piPlayer.MapFileName = fml.SelectedMap;
            PlayerInfo_Save();
            StartScreen_Draw();
            //RELOAD
            
        }

        void Action_MapEditor()
        {
            frmMapEditor fme = new frmMapEditor();
            fme.ShowDialog(this);

        }

        void Action_Stop(bool isGameOver)
        {
            if (m_tMoving.ThreadState == ThreadState.Suspended)
            {
                m_tMoving.Resume();
            }
            m_tMoving.Abort();

            if (isGameOver)
            {
                GameOver_Shake();
                InfoBox_Resize(true);
                string strHighscore = "";
                if (Highscore_Compare() == true)
                {
                    strHighscore = Environment.NewLine + UIString.MainForm.NewHighscore;
                }
                Highscore_Add();
                int index = Highscore_Rank();
                string strRank = "";
                if (index != -1)
                {
                    strRank = Environment.NewLine + UIString.MainForm.Rank + index.ToString();
                }
                Highscore_Renew();
                String_Draw(picInfoCon, UIString.MainForm.GameOver + Environment.NewLine + UIString.MainForm.YourScore + m_iScore.ToString() + strHighscore + strRank, m_iInfoBigFontSize, new List<String>() { UIString.MainForm.Restart }, m_iInfoSmallFontSize, new SolidBrush(m_meMap.Foreground));
            }
            else
            {
                m_psCurrent = PlayState.Stopped;
                Action_Restart();
            }
            
        }

        void GameOver_Shake()
        {
            for (int i = 0; i < 10; i++)
            {
                this.Left -= 5;
                Thread.Sleep(10);
                this.Top -= 5;
                Thread.Sleep(10);
                this.Left += 5;
                Thread.Sleep(10);
                this.Top += 5;
                Thread.Sleep(10);
            }

        }

        void Action_Pause()
        {
            InfoBox_Resize(true);
            String_Draw(picInfoCon, UIString.MainForm.Paused, m_iInfoBigFontSize, new List<String>() { UIString.MainForm.Start, UIString.MainForm.Exit, UIString.MainForm.HighScore }, m_iInfoSmallFontSize, new SolidBrush(m_meMap.Foreground));
            m_tMoving.Suspend();
            m_psCurrent = PlayState.Paused;
        }
        

        #region ActionStartResume
        #region Start
        void Action_Start()
        {
            InfoBox_Resize(false);

            m_tMapInit = new Thread(delegate()
                {

                    Map_Init();

                    //Snake_Init();
                    Map_DrawWall();

                    Snake_LoadDraw();
                    this.Invoke((Action)delegate()
                        {
                            Score_Add(0);
                            Start_CountDown();

                        }
                        );
                }
                );

            m_tMapInit.Start();

        }

        #endregion

        
        void Action_Resume()
        {
            InfoBox_Resize(false);
            Score_Add(0);
            Start_CountDown();
        }

        void Start_Resume()
        {
            if (m_tMoving.ThreadState == ThreadState.Suspended)
            {
                m_tMoving.Resume();
            }
            else
            {
                m_tMoving.Start();
            }
            picStartCountDown.Visible = false;
            m_psCurrent = PlayState.Started;
        }

        void Start_CountDown()
        {
            picStartCountDown.Image = null;
            picStartCountDown.Visible = true;
            picStartCountDown.Size = new Size(32, 32);
            picStartCountDown.Location = new Point(this.ClientRectangle.Width / 2 - picStartCountDown.Width / 2, this.ClientRectangle.Height / 2 - picStartCountDown.Height / 2);
            Thread tCountDown = new Thread(Thread_CountDown);
            tCountDown.Start();
        }

        void Thread_CountDown()
        {
            try
            {
                for (int n = 1; n < 4; n++)
                {

                    this.Invoke((Action)delegate()
                    {

                        String_Draw(picStartCountDown, n.ToString(), m_iInfoBigFontSize, new List<String>() { "" }, m_iInfoSmallFontSize, new SolidBrush(m_meMap.Foreground));
                        Application.DoEvents();
                    }

                    );

                    Thread.Sleep(500);

                }
                this.Invoke((Action)delegate()
                {
                    Start_Resume();
                }

                );
            }
            catch { }
        }

        void Action_GodMode()
        {
            if (m_bGod != true)
            {
                m_bGod = true;
                Tips_Show(UIString.MainForm.GodMode);
            }
        }

        #region Tips
        
        void Tips_Show(string str)
        {
            picShowTips.Visible = true;

            picShowTips.Width = picSnakeCon.Width-2;

            Graphics g = picSnakeCon.CreateGraphics();
            picShowTips.Height = (int)g.MeasureString(str, new Font("Segoe UI", 10)).Height + 10;

            Bitmap b = new Bitmap(picShowTips.Width, picShowTips.Height);
            g = Graphics.FromImage(b);

            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.DrawString(str, new Font("Segoe UI", 10), Brushes.White, picShowTips.ClientRectangle, sf);

            picShowTips.Image = b;
            picShowTips.Left = picInfoCon.Left+1;
            picShowTips.Top = -picShowTips.Height;
            Tips_Visible();
        }

        void Tips_Visible()
        {
            if (m_tTipsShow != null)
            {
                m_tTipsShow.Abort();
            }
            m_tTipsShow = new Thread(delegate()
                {
                    for (int i = 0; i < picShowTips.Height+6; i++)
                    {
                        picShowTips.Invoke((Action)delegate()
                        {
                            Tips_Move(1);
                        });
                        Thread.Sleep(5);
                    }

                    for (int i = 0; i < picShowTips.Height /2; i++)
                    {
                        picShowTips.Invoke((Action)delegate()
                        {
                            Tips_Move(-1);
                        });
                        Thread.Sleep(5);
                    }

                    for (int i = 0; i < picShowTips.Height / 2; i++)
                    {
                        picShowTips.Invoke((Action)delegate()
                        {
                            Tips_Move(1);
                        });
                        Thread.Sleep(5);
                    }

                    for (int i = 0; i < picShowTips.Height / 4; i++)
                    {
                        picShowTips.Invoke((Action)delegate()
                        {
                            Tips_Move(-1);
                        });
                        Thread.Sleep(5);
                    }

                    for (int i = 0; i < picShowTips.Height / 4; i++)
                    {
                        picShowTips.Invoke((Action)delegate()
                        {
                            Tips_Move(1);
                        });
                        Thread.Sleep(5);
                    }

                    Thread.Sleep(1000);

                    for (int i = 0; i < picShowTips.Height + 6; i++)
                    {
                        picShowTips.Invoke((Action)delegate()
                        {
                            Tips_Move(-1);
                        });
                        Thread.Sleep(5);
                    }
                    picShowTips.Invoke((Action)delegate()
                    {
                        picShowTips.Visible = false;
                    });
                });
            m_tTipsShow.Start();
          
        }

        void Tips_Move(int pixel)
        {
            picShowTips.Top += pixel;
        }

        #endregion
        #endregion
        #endregion

        #endregion

        #endregion

        #region MainUI

        
        void Score_Add(int Score)
        {
            m_iScore += Score;
            String_Draw(picInfoCon, UIString.MainForm.Score + m_iScore.ToString(), 20, new List<String>() { UIString.MainForm.Pause, UIString.MainForm.Exit }, m_iInfoSmallFontSize, new SolidBrush(m_meMap.Foreground));
        }

        void String_Draw(PictureBox PicDes, string Text, int FontSize, List<string> SubText, int SubFontSize, SolidBrush StringColor)
        {
            Bitmap bInfo = new Bitmap(PicDes.Width, PicDes.Height);
            Graphics gInfo = Graphics.FromImage(bInfo);
            StringFormat sfFormat = new StringFormat();

            sfFormat.LineAlignment = StringAlignment.Center;
            sfFormat.Alignment = StringAlignment.Center;
            gInfo.TextRenderingHint = TextRenderingHint.AntiAlias;
            gInfo.DrawString(Text, new Font("Segoe UI", FontSize), StringColor, PicDes.ClientRectangle, sfFormat);

            Graphics gSubInfo = Graphics.FromImage(bInfo);
            gSubInfo.TextRenderingHint = TextRenderingHint.AntiAlias;

            string SubString = "";
            foreach (string sub in SubText)
            {
                SubString += sub + Environment.NewLine;
            }
            gSubInfo.DrawString(SubString, new Font("Segou UI", SubFontSize), StringColor, new PointF(5, 5));

            PicDes.Image = bInfo;
        }
        #endregion

    }
}


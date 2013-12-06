using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace Snakee
{
    class Game
    {
        string m_strSettingsPath = "";

        Settings m_sttSettings;
        Player m_pPlayer;
        Highscores m_hsHighScore;

        MapEditor m_meMap = new MapEditor();
        MapInfo m_miMap = new MapInfo();
        PlayerInfo m_piPlayer = new PlayerInfo();

        Skin m_sMap = new Skin();

        List<List<MapBoxState>> m_mbsMap = new List<List<MapBoxState>>();
        List<Point> m_pSnakeLoc = new List<Point>();
        List<Point> m_pWallLoc = new List<Point>();
        List<Point> m_pFoodSel = new List<Point>();
        Point m_pFoodLoc = new Point();

        int m_iScore = 0;

        SnakeDirection m_sdCurrent = SnakeDirection.Right;
        SnakeDirection m_sdLast = SnakeDirection.Right;
        


        public delegate void FoodHandler(Point foodToDraw);
        public event FoodHandler FoodMade;

        public delegate void ProgressHandler(ProgressState state);
        public event ProgressHandler Progress;
            

        public Game(string settingFilepath)
        {
            //AllocConsole();
            Progress_Report(ProgressState.Initializing);

            if (settingFilepath != "")
            {
                m_strSettingsPath = settingFilepath;
                m_sttSettings = new Settings(m_strSettingsPath);
            }
            else
            {
                return;
            }
            
            //Player
            m_pPlayer = new Player(m_strSettingsPath);
            m_piPlayer = m_pPlayer.playerInfo;
            //Highscore
            m_hsHighScore = new Highscores(m_strSettingsPath, m_pPlayer.playerInfo);

            Map_Load();
            Progress_Report(ProgressState.MapLoaded);

            Map_Gen();
            Progress_Report(ProgressState.MapGenerated);

            Progress_Report(ProgressState.Initialized);


            Snake_Move(SnakeDirection.Right);

            View_List(m_mbsMap);


        }

        #region MapLoading
        void Map_Load()
        {
            if (!File.Exists(m_piPlayer.LastMap))
            {
                MapEditor me = new MapEditor();
                me.LoadDefault();
                me.Name = m_piPlayer.MapName;
                me.SnakeBodyPoint = PFunc.Snakee_CalPoint(me.Width, me.Height, me.SnakeLength);
                me.Save(m_piPlayer.LastMap);
            }
            m_meMap.Load(m_piPlayer.LastMap);
            m_sMap = m_meMap.SnakeeSkin;
            m_miMap = m_meMap.MapInfo;
            
        }
        #region Properties
        public MapEditor mapEditor
        {
            get
            {
                return m_meMap;
            }
        }

        public MapInfo mapInfo
        {
            get
            {
                return m_miMap;
            }
        }

        public  Skin mapSkin
        {
            get
            {
                return m_sMap;
            }
        }

        #endregion

        #endregion

        #region MapGenerating

        void Map_Gen()
        {
            List<List<Point>> pFood = new List<List<Point>>();

            //Map gen
            for (int y = 0; y < m_miMap.Width; y++)
            {
                List<MapBoxState> mbs = new List<MapBoxState>();

                List<Point> food = new List<Point>();

                for (int x = 0; x < m_miMap.Height; x++)
                {
                    mbs.Add(MapBoxState.None);

                    food.Add(new Point(x, y));
                }
                pFood.Add(food);

                m_mbsMap.Add(mbs);
            }

            //Wall Gen
            m_pWallLoc = m_meMap.WallPoint;

            m_pWallLoc.ForEach(item=>
                m_mbsMap[item.Y][item.X] = MapBoxState.Wall
                );

            //Food Init
            m_pFoodSel = pFood.SelectMany(item => item).ToList();
            m_pFoodSel.RemoveAll(item=>
                m_pWallLoc.Any(wall=>
                item == wall
                )
                );

            //Snake Gen
            m_pSnakeLoc = m_meMap.SnakeBodyPoint;

            for (int i = 1; i < m_pSnakeLoc.Count -1; i++)
            {
                m_mbsMap[m_pSnakeLoc[i].X][m_pSnakeLoc[i].Y] = MapBoxState.Body_DR;
            }

            m_mbsMap[m_pSnakeLoc[0].X][m_pSnakeLoc[0].Y] = MapBoxState.Tail_R;
            m_mbsMap[m_pSnakeLoc[m_pSnakeLoc.Count - 1].X][m_pSnakeLoc[m_pSnakeLoc.Count - 1].Y] = MapBoxState.Head_R;

            Food_GetRandom();
        }

        #endregion

        #region Food
        void Food_GetRandom()
        {
            HashSet<Point> foodClone = new HashSet<Point>(m_pFoodSel);
            foodClone.RemoveWhere(item =>
                m_pSnakeLoc.Any(body =>
                    new Point(item.Y,item.X) == body
                )
                );
            List<Point> food = foodClone.ToList();
            Random r = new Random();
            m_pFoodLoc = food[r.Next(0,food.Count-1)];

            m_mbsMap[m_pFoodLoc.X][m_pFoodLoc.Y] = MapBoxState.Food;

            if (FoodMade != null)
            {
                FoodMade(m_pFoodLoc);
            }

            View_Point(new List<Point>() { m_pFoodLoc});
        }
        #endregion

        #region Game

        void Snake_Move(SnakeDirection sd)  //TODO: OR GIVE KEYSCONTROL AS PARAMETER
        {
            //  TODO: CHECK FOR FOOD & PRE EAT FOOD
            //  TODO: CHECK FOR BACKWARDING
            m_sdCurrent = sd;

            List<Point> pAdd = new List<Point>();
            Point pRemove = new Point();

            if (sd == SnakeDirection.Right)
            {
                pRemove = m_pSnakeLoc[0];
                pAdd.Add(new Point(m_pSnakeLoc.Last().X,m_pSnakeLoc.Last().Y+1));
            }
            else if (sd == SnakeDirection.Left)
            {

            }

            Snake_Draw(pAdd, pRemove);
            m_sdLast = m_sdCurrent;

        }
        
        void Snake_Draw(List<Point> add ,Point remove)
        {
            if (!remove.IsEmpty)
            {           
                //Remove (Untail)
                m_mbsMap[remove.X][remove.Y] = MapBoxState.None;
                //Retail
                m_mbsMap[m_pSnakeLoc[1].X][m_pSnakeLoc[1].Y] = Snake_CalTailHead(m_pSnakeLoc[1], remove,false,false);
                //Remove it from snakeloc
                m_pSnakeLoc.Remove(remove);
            }

            //Unhead && Rebody
            m_mbsMap[m_pSnakeLoc.Last().X][m_pSnakeLoc.Last().Y] = Snake_CalBody(m_sdCurrent, m_sdLast);
            add.ForEach(delegate(Point item)
            {
                m_pSnakeLoc.Add(item);
                m_mbsMap[item.X][item.Y] = Snake_CalBody(m_sdCurrent, m_sdLast);
            }
                );
            //Rehead
            m_mbsMap[m_pSnakeLoc.Last().X][m_pSnakeLoc.Last().Y] = Snake_CalTailHead(m_pSnakeLoc.Last(),m_pSnakeLoc[m_pSnakeLoc.Count-2], true, false);


        }


        MapBoxState Snake_CalBody(SnakeDirection current, SnakeDirection last)
        {
            if (last == SnakeDirection.Right)
            {
                if (current == SnakeDirection.Right)
                {
                    return MapBoxState.Body_DR;
                }
                else if (current == SnakeDirection.Up)
                {
                    return MapBoxState.Body_UL;
                }
                else if (current == SnakeDirection.Down)
                {
                    return MapBoxState.Body_UL;
                }
            }
            else if (last == SnakeDirection.Left)
            {
                if (current == SnakeDirection.Left)
                {
                    return MapBoxState.Body_DL;
                }
                else if (current == SnakeDirection.Down)
                {
                    return MapBoxState.Body_UL;
                }
                else if (current == SnakeDirection.Up)
                {
                    return MapBoxState.Body_UL;
                }
            }
            else if (last == SnakeDirection.Up)
            {
                if (current == SnakeDirection.Up)
                {
                    return MapBoxState.Body_UL;
                }
                else if (current == SnakeDirection.Left)
                {
                    return MapBoxState.Body_DR;
                }
                else if (current == SnakeDirection.Right)
                {
                    return MapBoxState.Body_DL;
                }
            }
            else if (last == SnakeDirection.Down)
            {
                if (current == SnakeDirection.Down)
                {
                    return MapBoxState.Body_UL;
                }
                else if (current == SnakeDirection.Left)
                {
                    return MapBoxState.Body_DR;
                }
                else if (current == SnakeDirection.Right)
                {
                    return MapBoxState.Body_DL;
                }
            }
            return MapBoxState.None;
        }

        MapBoxState Snake_CalTailHead(Point current, Point last,bool isHead,bool isHeadEat)
        {
            //X and Y reversed
            int iX = current.X - last.X;
            int iY = current.Y - last.Y;

            if (iY == 1)
            {
                return isHead ? (isHeadEat ? MapBoxState.HeadEat_R : MapBoxState.Head_R) : MapBoxState.Tail_R;
            }
            else if (iY == -1)
            {
                return isHead ? (isHeadEat ? MapBoxState.HeadEat_L : MapBoxState.Head_L) : MapBoxState.Tail_L;
            }
            else if (iX == -1)
            {
                return isHead ? (isHeadEat ? MapBoxState.HeadEat_U : MapBoxState.Head_U) : MapBoxState.Tail_U;
            }
            else
            {
                return isHead ? (isHeadEat ? MapBoxState.HeadEat_D : MapBoxState.Head_D) : MapBoxState.Tail_D;
            }
        }



        #endregion



        void Progress_Report(ProgressState ps)
        {
            if (Progress != null)
            {
                Progress(ps);
            }
        }

        void View_List(List<List<MapBoxState>> view)
        {
            for (int x = 0; x < view.Count; x++)
            {
                Console.Write(x.ToString() + "\t");
                for (int y = 0; y < view[x].Count; y++)
                {
                    if (x == 0 )
                    {
                        if (y == 0)
                        {
                            for (int yy = 0; yy < view[x].Count; yy++)
                            {
                                Console.Write(yy.ToString() + "\t\t");
                            }
                            Console.WriteLine(Environment.NewLine);
                        }
                    }
                    Console.Write(view[x][y].ToString() + "\t");
                }
                Console.WriteLine(Environment.NewLine);
            }
        }

        void View_Point(List<Point> view)
        {
            //Win32API.AllocConsole();

            for (int i = 0; i < view.Count; i++)
            {
                //Console.SetCursorPosition(view[i].X, view[i].Y);
                Console.Write(".");
            }
            Console.WriteLine();
        }


    }




    class Settings
    {
        string m_strFilePath = "";

        XmlDocument m_xd = new XmlDocument();

        public Settings(string FilePath)
        {
            m_strFilePath = FilePath;
            Settings_Load();
        }

        void Settings_Load()
        {
            if (!File.Exists(m_strFilePath))
            {
                Settings_Default();
            }
            //TODO: SETTINGS
        }


        void Settings_Default()
        {
            XmlTextWriter xtw = new XmlTextWriter(m_strFilePath, Encoding.UTF8);
            xtw.Formatting = Formatting.Indented;
            xtw.WriteStartElement("Settings");

            xtw.WriteStartElement("Highscore");
            for (int i = 1; i < 11; i++)
            {
                xtw.WriteStartElement("No_" + i.ToString());

                PFunc.XML_WriteElement(xtw, "Name", "Player_" + i.ToString());
                PFunc.XML_WriteElement(xtw, "Score", (11 - i).ToString());
                PFunc.XML_WriteElement(xtw, "Map", "Map_" + i.ToString());
                PFunc.XML_WriteElement(xtw, "Rank", i.ToString());

                xtw.WriteEndElement();
            }
            xtw.WriteEndElement();

            xtw.WriteStartElement("PlayerInfo");

            PFunc.XML_WriteElement(xtw, "Name", "Player");
            PFunc.XML_WriteElement(xtw, "MapName", "Default Map");
            PFunc.XML_WriteElement(xtw, "LastMap", "Default.smap");

            xtw.WriteEndElement();
            xtw.Close();

        }

    }

    class Player
    {
        //Load Player Info

        PlayerInfo m_piPlayer = new PlayerInfo();
        string m_strFilePath = "";

        XmlDocument m_xd = new XmlDocument();

        public Player(string FilePath)
        {
            m_strFilePath = FilePath;
            m_xd.Load(m_strFilePath);
            Player_Load();
        }

        void Player_Load()
        {
            m_piPlayer.Name = PFunc.XML_Read(m_xd, "Settings/PlayerInfo/Name");
            m_piPlayer.MapName = PFunc.XML_Read(m_xd, "Settings/PlayerInfo/MapName");
            m_piPlayer.LastMap = PFunc.XML_Read(m_xd, "Settings/PlayerInfo/LastMap");
        }

        void Player_Save()
        {
            PFunc.XML_Edit(m_xd, m_strFilePath, "Settings/PlayerInfo/Name", m_piPlayer.Name);
            PFunc.XML_Edit(m_xd, m_strFilePath, "Settings/PlayerInfo/MapName", m_piPlayer.MapName);
            PFunc.XML_Edit(m_xd, m_strFilePath, "Settings/PlayerInfo/LastMap", m_piPlayer.LastMap);
        }

        #region Public
        public void Save()
        {
            Player_Save();
        }

        public void Load()
        {
            Player_Load();
        }

        public PlayerInfo playerInfo
        {
            get
            {
                return m_piPlayer;
            }
            set
            {
                m_piPlayer = value;
            }
        }

        #endregion

    }

    class Highscores
    {
        List<HighScoreInfo> m_lstHsiInfo = new List<HighScoreInfo>();
        PlayerInfo m_piPlayer = new PlayerInfo();

        string m_strFilePath = "";

        XmlDocument m_xd = new XmlDocument();

        bool m_bIsHighscore = false;
        int m_iHighscoreRank = -1;

        public Highscores(string FilePath, PlayerInfo playerInfo = new PlayerInfo())
        {
            m_strFilePath = FilePath;
            m_xd.Load(FilePath);
            Highscore_Load();
            m_piPlayer = playerInfo;
        }

        void Highscore_Load()
        {
            for (int i = 1; i < 11; i++)
            {
                HighScoreInfo hsi = new HighScoreInfo();
                hsi.Name = PFunc.XML_Read(m_xd, "Settings/Highscore/No_" + i.ToString() + "/Name");
                hsi.Score = Convert.ToInt32(PFunc.XML_Read(m_xd, "Settings/Highscore/No_" + i.ToString() + "/Score"));
                hsi.Map = PFunc.XML_Read(m_xd, "Settings/Highscore/No_" + i.ToString() + "/Map");
                hsi.Rank = Convert.ToInt32(PFunc.XML_Read(m_xd, "Settings/Highscore/No_" + i.ToString() + "/Rank"));
                m_lstHsiInfo.Add(hsi);
            }
        }
        
        void Highscore_Save()
        {
            for (int i = 0; i < m_lstHsiInfo.Count; i++)
            {
                PFunc.XML_Edit(m_xd, m_strFilePath, "Settings/Highscore/No_" + (i + 1).ToString() + "/Name", m_lstHsiInfo[i].Name);
                PFunc.XML_Edit(m_xd, m_strFilePath, "Settings/Highscore/No_" + (i + 1).ToString() + "/Score", m_lstHsiInfo[i].Score.ToString());
                PFunc.XML_Edit(m_xd, m_strFilePath, "Settings/Highscore/No_" + (i + 1).ToString() + "/Map", m_lstHsiInfo[i].Map);
                PFunc.XML_Edit(m_xd, m_strFilePath, "Settings/Highscore/No_" + (i + 1).ToString() + "/Rank", m_lstHsiInfo[i].Rank.ToString());
            }
        }


        void Highscore_Check(int Newscore)
        {
            if (m_piPlayer.Name == "" || m_piPlayer.MapName == "" || m_piPlayer.LastMap== "")
            {
                return;
            }

            //Check is new highscore
            if (Newscore > m_lstHsiInfo[0].Score)
            {
                m_bIsHighscore = true;
            }
            else
            {
                m_bIsHighscore = false;
            }


            //Add
            HighScoreInfo hsi = new HighScoreInfo();
            hsi.Name = m_piPlayer.Name;
            hsi.Map = m_piPlayer.MapName;
            hsi.Score = Newscore;

            m_lstHsiInfo.Add(hsi);
            m_lstHsiInfo = m_lstHsiInfo.OrderByDescending(item => item.Score).ToList();
            m_lstHsiInfo.RemoveAt(m_lstHsiInfo.Count - 1);

            //Get rank
            List<HighScoreInfo> chsi = new List<HighScoreInfo>(m_lstHsiInfo);
            chsi.RemoveAll(item => item.Rank != 0);
            int rankindex = -1;
            if (chsi.Count == 0)
            {
                m_iHighscoreRank = -1;
                
            }
            else
            {
                rankindex = m_lstHsiInfo.IndexOf(chsi[0]);
            }
            if (rankindex < 0)
            {
                m_iHighscoreRank = -1;
            }
            else
            {

                m_iHighscoreRank = m_lstHsiInfo[rankindex].Rank;
            }

            //Renew rank
            HighScoreInfo nhsi = new HighScoreInfo();
            for (int i = 0; i < m_lstHsiInfo.Count; i++)
            {
                nhsi = m_lstHsiInfo[i];
                nhsi.Rank = i + 1;
                m_lstHsiInfo[i] = nhsi;
            }


            Highscore_Save();

        }


        #region Public

        public void Renew(int score)
        {
            Highscore_Check(score);
        }

        public int Rank
        {
            get
            {
                return m_iHighscoreRank;
            }
        }

        public bool IsNewHighscore
        {
            get
            {
                return m_bIsHighscore;
            }
        }

        public List<HighScoreInfo> highscoreInfos
        {
            get
            {
                return m_lstHsiInfo;
            }
        }
        
        #endregion
    }
}

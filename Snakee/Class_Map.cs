using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Xml;
using System.Reflection;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.IO;

namespace Snakee
{

    public class MapEditor
    {
        //const int m_iMapVersion = 1; USE MapVersion in Global Settings //TODO: DETERMINE MAP VERSION 


        struct SkinInfoPath
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
        }

        struct ThemeInfo
        {
            // Need to combine with Snakebox's Skin
            public Color Background;
            public Color Foreground;
        }


        MapInfo m_miMap = new MapInfo();
        SkinInfoPath m_sipSkinp = new SkinInfoPath();
        ThemeInfo m_tiTheme = new ThemeInfo();
        Skin m_skSkin = new Skin();

        List<Point> m_pSnakeLoc = new List<Point>();
        List<Point> m_pWallLoc = new List<Point>();

        Bitmap m_bPreview = new Bitmap(1, 1);

        string m_strFileName = "";

        public MapEditor()
        {
            //Init Default Value
            Default_Load();

        }

        #region PrivateFunc

        #region LoadDefault

        void Default_Load()
        {
            MapInfo_Default();
            ThemeInfo_Default();
            SkinImage_Default();
        }

        void SkinImage_Default()
        {
            Head_Rot(true);
            HeadEat_Rot(true);
            Body_Rot(true);
            BodyFat_Rot(true);
            Turn_Rot(true);
            TurnFat_Rot(true);
            Tail_Rot(true);
            Food_Load(true);
            Wall_Load(true);
        }

        void MapInfo_Default()
        {
            m_miMap.Height = 41;
            m_miMap.Width = 41;
            m_miMap.Interval = 300;
            m_miMap.Name = "Custom Map";
            m_miMap.BlockSize = 8;
            m_miMap.SnakeLength = 5;
            m_miMap.Version = GlobalSettings.MapVersion;
        }

        void ThemeInfo_Default()
        {
            m_tiTheme.Background = Color.Black;
            m_tiTheme.Foreground = Color.White;
        }

        #endregion

        #region MapSave

        void Map_Save(string FileName)
        {
            XmlTextWriter xtw = new XmlTextWriter(FileName, Encoding.UTF8);
            xtw.Formatting = Formatting.Indented;
            xtw.WriteStartElement("Map");
            
            Save_MapInfo(xtw);
            Save_ThemeInfo(xtw);
            Save_SkinInfo(xtw);
            Save_SnakeLoc(xtw);
            Save_WallLoc(xtw);
            Save_MapPreview(xtw);

            xtw.WriteEndElement();
            xtw.Close();

        }

        void Save_MapInfo(XmlTextWriter xtw)
        {
            xtw.WriteStartElement("MapInfo");

            PFunc.XML_WriteElement(xtw, "Name", m_miMap.Name);
            PFunc.XML_WriteElement(xtw, "Interval", m_miMap.Interval.ToString());
            PFunc.XML_WriteElement(xtw, "Width", m_miMap.Width.ToString());
            PFunc.XML_WriteElement(xtw, "Height", m_miMap.Height.ToString());
            PFunc.XML_WriteElement(xtw, "BlockSize", m_miMap.BlockSize.ToString());
            PFunc.XML_WriteElement(xtw, "SnakeLength", m_miMap.SnakeLength.ToString());
            PFunc.XML_WriteElement(xtw, "Version", m_miMap.Version.ToString());

            xtw.WriteEndElement();
        }

        void Save_ThemeInfo(XmlTextWriter xtw)
        {
            xtw.WriteStartElement("ThemeInfo");

            PFunc.XML_WriteElement(xtw, "Foreground", PFunc.Color_ToHexString(m_tiTheme.Foreground));
            PFunc.XML_WriteElement(xtw, "Background", PFunc.Color_ToHexString(m_tiTheme.Background));

            xtw.WriteEndElement();
        }

        void Save_SkinInfo(XmlTextWriter xtw)
        {
            FieldInfo[] fiSkin = m_skSkin.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);

            xtw.WriteStartElement("SkinInfo");
            //PFunc.XML_WriteElement(xtw, "ImageFormat", "PNG");
            foreach (FieldInfo fi in fiSkin)
            {
                if (fi.FieldType == typeof( Image))
                {
                    Image img = (Image)fi.GetValue(m_skSkin);
                    string b64 = PFunc.Image_ToBase64(img, ImageFormat.Png);
                    PFunc.XML_WriteElement(xtw, fi.Name, b64);
                }
            }

            xtw.WriteEndElement();

        }

        void Save_SnakeLoc(XmlTextWriter xtw)
        {
            xtw.WriteStartElement("SnakeInfo");

            string str = string.Join(";", m_pSnakeLoc.Select(item => item.ToString()).ToArray());
            PFunc.XML_WriteElement(xtw,"Loc",str);

            xtw.WriteEndElement();
        }

        void Save_WallLoc(XmlTextWriter xtw)
        {
            xtw.WriteStartElement("WallInfo");

            string str = string.Join(";", m_pWallLoc.ToArray());
            PFunc.XML_WriteElement(xtw,"Loc",str);

            xtw.WriteEndElement();
        }

        void Save_MapPreview(XmlTextWriter xtw)
        {
            Preview_Gen();
            xtw.WriteStartElement("PreviewInfo");
            string str = PFunc.Image_ToBase64(m_bPreview, ImageFormat.Png);
            PFunc.XML_WriteElement(xtw,"Preview",str);
            xtw.WriteEndElement();
                
        }


        #region MapPreview

        void Preview_Gen()
        {
            m_bPreview = new Bitmap(m_miMap.Width * m_miMap.BlockSize, m_miMap.Height * m_miMap.BlockSize);
            Graphics g = Graphics.FromImage(m_bPreview);
            g.Clear(m_tiTheme.Background);

            m_pWallLoc.ForEach(item => g.DrawImageUnscaled(m_skSkin.Wall, item.X * m_miMap.BlockSize, item.Y * m_miMap.BlockSize));

            for (int i = 1; i < m_pSnakeLoc.Count - 1; i++)
            {
                g.DrawImageUnscaled(m_skSkin.Body_DR, m_pSnakeLoc[i].Y * m_miMap.BlockSize, m_pSnakeLoc[i].X* m_miMap.BlockSize);
            }
            g.DrawImageUnscaled(m_skSkin.Tail_R, m_pSnakeLoc[0].Y * m_miMap.BlockSize, m_pSnakeLoc[0].X * m_miMap.BlockSize);
            g.DrawImageUnscaled(m_skSkin.Head_R, m_pSnakeLoc[m_pSnakeLoc.Count-1].Y * m_miMap.BlockSize, m_pSnakeLoc[m_pSnakeLoc.Count-1].X * m_miMap.BlockSize);

            #region BITBLT + ALPHABLEND
            //Bitmap b = new Bitmap(m_miMap.Width * m_miMap.BlockSize, m_miMap.Height * m_miMap.BlockSize);
            //Graphics g = Graphics.FromImage(b);
            //g.Clear(m_tiTheme.Background);

            //IntPtr target = g.GetHdc();
            //IntPtr source = Win32API.CreateCompatibleDC(target);
            
            //Bitmap bT = new Bitmap(m_skSkin.Wall);
            //IntPtr hBit = bT.GetHbitmap(Color.Black);

            //IntPtr Ori = Win32API.SelectObject(source, hBit);

            ////Win32API.BitBlt(target, 0, 0, bT.Width, bT.Height, source, 0, 0, Win32API.TernaryRasterOperations.SRCCOPY);

            //Win32API.BLENDFUNCTION bd = new Win32API.BLENDFUNCTION();
            //bd.BlendOp  = Win32API.AC_SRC_OVER;
            //bd.BlendFlags = 0;
            //bd.SourceConstantAlpha = 0xff;
            //bd.AlphaFormat = Win32API.AC_SRC_ALPHA;

            ////Win32API.AlphaBlend(target, 0, 0, bT.Width, bT.Height, source, 0, 0, bT.Width, bT.Height, bd);

            //IntPtr New = Win32API.SelectObject(source, Ori);
            //Win32API.DeleteObject(New);
            //Win32API.DeleteDC(source);


            //g.ReleaseHdc(target);

            //m_bPreview = new Bitmap(b);

            #endregion
   
        }

        #endregion

        #endregion

        #region MapLoad
        void Map_Load(string FileName)
        {
            XmlDocument xd = new XmlDocument();
            
            xd.Load(FileName);
            Load_MapInfo(xd);
            Load_ThemeInfo(xd);
            Load_SkinInfo(xd);
            Load_SnakeLoc(xd);
            Load_WallLoc(xd);
            Load_Version(xd);
        }

        void Load_MapInfo(XmlDocument xd)
        {
            m_miMap.BlockSize = Convert.ToInt32(PFunc.XML_Read(xd, "Map/MapInfo/BlockSize"));
            m_miMap.Height = Convert.ToInt32(PFunc.XML_Read(xd, "Map/MapInfo/Height"));
            m_miMap.Interval = Convert.ToInt32(PFunc.XML_Read(xd, "Map/MapInfo/Interval"));
            m_miMap.Name = PFunc.XML_Read(xd, "Map/MapInfo/Name");
            m_miMap.SnakeLength = Convert.ToInt32(PFunc.XML_Read(xd, "Map/MapInfo/SnakeLength"));
            m_miMap.Version = Convert.ToInt32(PFunc.XML_Read(xd, "Map/MapInfo/Version"));
            m_miMap.Width = Convert.ToInt32(PFunc.XML_Read(xd, "Map/MapInfo/Width"));
        }

        void Load_ThemeInfo(XmlDocument xd)
        {
            m_tiTheme.Background = PFunc.Hex_ToColor(PFunc.XML_Read(xd, "Map/ThemeInfo/Background"));
            m_tiTheme.Foreground = PFunc.Hex_ToColor(PFunc.XML_Read(xd, "Map/ThemeInfo/Foreground"));
        }

        void Load_SkinInfo(XmlDocument xd)
        {
            FieldInfo[] fiSkin = m_skSkin.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);


            foreach (FieldInfo fi in fiSkin)
            {
                if (fi.FieldType == typeof(Image))
                {
                    Image img = PFunc.Base64_ToImage(PFunc.XML_Read(xd, "Map/SkinInfo/" + fi.Name));
                    object obj = (object)m_skSkin;
                    fi.SetValue(obj, img);
                    m_skSkin = (Skin)obj;
                }
            }
        }

        void Load_SnakeLoc(XmlDocument xd)
        {

            string str = PFunc.XML_Read(xd, "Map/SnakeInfo/Loc");

            if (str != "")
            {
                List<string> sp = Regex.Split(str, ";").ToList();
                m_pSnakeLoc = sp.Select(item => PFunc.String_ToPoint(item)).ToList();
            }
        }

        void Load_WallLoc(XmlDocument xd)
        {
            string str = PFunc.XML_Read(xd, "Map/WallInfo/Loc");

            if (str != "")
            {
                List<string> sp = Regex.Split(str, ";").ToList();
                m_pWallLoc = sp.Select(item => PFunc.String_ToPoint(item)).ToList();
            }
        }

        void Load_Version(XmlDocument xd)
        {
            string str = PFunc.XML_Read(xd, "Map/MapInfo/Version");
            if (str != "")
            {
                m_miMap.Version = Convert.ToInt32(str);
            }
        }

        #endregion

        #region CheckWarning

        List<string> Check_Warning()
        {
            List<string> strWarning = new List<string>();
            if (Warning_WidthHeight() == false)
            {
                strWarning.Add("Map's width and height are too large (Default: 41)");
            }
            if (Warning_BlockSize() == false)
            {
                strWarning.Add("Map's block size too large or too small (Default: 8)");
            }
            if (Waning_Interval() == false)
            {
                strWarning.Add("The interval (1000 = 1 second) is too long (Default: 300)");
            }
            return strWarning;
        }

        bool  Warning_WidthHeight()
        {
            if (m_miMap.Width > 60 || m_miMap.Height > 60)
            {
                return false;
            }
            return true;

        }

        bool Warning_BlockSize()
        {
            if (m_miMap.BlockSize >= 32 || m_miMap.BlockSize <=4)
            {
                return false;
            }
            return true;
        }

        bool Waning_Interval()
        {
            if (m_miMap.Interval >= 1000)
            {
                return false;
            }
            return true;
        }

        #endregion

        #region CheckError

        List<string> Check_Error()
        {
            List<string> strError = new List<string>();

            if (Error_Name() == false)
            {
                strError.Add("Map info's 'Name' invalid");
            }
            if (Error_BlockSize() == false)
            {
                strError.Add("Map info's 'Block Size' invalid (Default: 8)");
            }
            if (Error_Height() == false)
            {
                strError.Add("Map info's 'Height' invalid (Default: 41, must >10)");
            }
            if (Error_SnakeInitLength() == false)
            {
                strError.Add("Map info's 'Snake Initial Length' invalid (must >3, <Map width) ");
            }
            if (Error_Width() == false)
            {
                strError.Add("Map info's 'Width' invalid (Default: 41, must >10))");
            }
            return strError;
        }

        bool Error_Name()
        {
            if (m_miMap.Name == "")
            {
                return false;
            }
            return true;
        }

        bool Error_Width()
        {
            if (m_miMap.Width < 10)
            {
                return false;
            }
            return true;
        }

        bool Error_Height()
        {
            if (m_miMap.Height < 10)
            {
                return false;
            }
            return true;
        }

        bool Error_BlockSize()
        {
            if (m_miMap.BlockSize == 0)
            {
                return false;
            }
            return true;
        }

        bool Error_SnakeInitLength()
        {
            if (m_miMap.SnakeLength <= 3 || m_miMap.SnakeLength >= m_miMap.Width)
            {
                return false;
            }
            return true;
        }

        #endregion

        #region SkinLoadRotationSave
        void Head_Rot(bool IsB64)
        {
            m_skSkin.Head_R = IsB64 ? PFunc.Base64_ToImage(DefaultSkin.strHead_R) : PFunc.Image_Load(m_sipSkinp.HeadRp);
            m_skSkin.Head_L = PFunc.Image_Rotate(m_skSkin.Head_R, RotateFlipType.RotateNoneFlipX);
            m_skSkin.Head_U = PFunc.Image_Rotate(m_skSkin.Head_R, RotateFlipType.Rotate270FlipNone);
            m_skSkin.Head_D = PFunc.Image_Rotate(m_skSkin.Head_R, RotateFlipType.Rotate90FlipNone);
        }

        void HeadEat_Rot(bool IsB64)
        {
            m_skSkin.HeadEat_R = IsB64 ? PFunc.Base64_ToImage(DefaultSkin.strHeadEat_R) : PFunc.Image_Load(m_sipSkinp.HeadEatRp);
            m_skSkin.HeadEat_U = PFunc.Image_Rotate(m_skSkin.HeadEat_R, RotateFlipType.Rotate270FlipNone);
            m_skSkin.HeadEat_D = PFunc.Image_Rotate(m_skSkin.HeadEat_R, RotateFlipType.Rotate90FlipNone);
            m_skSkin.HeadEat_L = PFunc.Image_Rotate(m_skSkin.HeadEat_R, RotateFlipType.RotateNoneFlipX);
        }

        void Body_Rot(bool IsB64)
        {
            m_skSkin.Body_DR = IsB64 ? PFunc.Base64_ToImage(DefaultSkin.strBody_DR) : PFunc.Image_Load(m_sipSkinp.BodyDRp);
            m_skSkin.Body_DL = PFunc.Image_Rotate(m_skSkin.Body_DR, RotateFlipType.RotateNoneFlipX);
            m_skSkin.Body_UR = PFunc.Image_Rotate(m_skSkin.Body_DR, RotateFlipType.Rotate90FlipNone);
            m_skSkin.Body_UL = PFunc.Image_Rotate(m_skSkin.Body_DR, RotateFlipType.Rotate90FlipY);
        }

        void BodyFat_Rot(bool IsB64)
        {
            m_skSkin.BodyFat_DR = IsB64 ? PFunc.Base64_ToImage(DefaultSkin.strBodyFat_DR) : PFunc.Image_Load(m_sipSkinp.BodyFatDRp);
            m_skSkin.BodyFat_DL = PFunc.Image_Rotate(m_skSkin.BodyFat_DR, RotateFlipType.RotateNoneFlipX);
            m_skSkin.BodyFat_UR = PFunc.Image_Rotate(m_skSkin.BodyFat_DR, RotateFlipType.Rotate90FlipNone);
            m_skSkin.BodyFat_UL = PFunc.Image_Rotate(m_skSkin.BodyFat_DR, RotateFlipType.Rotate90FlipY);
        }

        void Turn_Rot(bool IsB64)
        {
            m_skSkin.Turn_UR = IsB64 ? PFunc.Base64_ToImage(DefaultSkin.strTurn_UR) : PFunc.Image_Load(m_sipSkinp.TurnURp);
            m_skSkin.Turn_DR = PFunc.Image_Rotate(m_skSkin.Turn_UR, RotateFlipType.RotateNoneFlipY);
            m_skSkin.Turn_DL = PFunc.Image_Rotate(m_skSkin.Turn_UR, RotateFlipType.RotateNoneFlipXY);
            m_skSkin.Turn_UL = PFunc.Image_Rotate(m_skSkin.Turn_UR, RotateFlipType.RotateNoneFlipX);
        }

        void TurnFat_Rot(bool IsB64)
        {
            m_skSkin.TurnFat_UR = IsB64 ? PFunc.Base64_ToImage(DefaultSkin.strTurnFat_UR) : PFunc.Image_Load(m_sipSkinp.TurnFatURp);
            m_skSkin.TurnFat_DL = PFunc.Image_Rotate(m_skSkin.TurnFat_UR, RotateFlipType.RotateNoneFlipXY);
            m_skSkin.TurnFat_UL = PFunc.Image_Rotate(m_skSkin.TurnFat_UR, RotateFlipType.RotateNoneFlipX);
            m_skSkin.TurnFat_DR = PFunc.Image_Rotate(m_skSkin.TurnFat_UR, RotateFlipType.RotateNoneFlipY);
        }

        void Tail_Rot(bool IsB64)
        {
            m_skSkin.Tail_R = IsB64 ? PFunc.Base64_ToImage(DefaultSkin.strTail_R) : PFunc.Image_Load(m_sipSkinp.TailRp);
            m_skSkin.Tail_L = PFunc.Image_Rotate(m_skSkin.Tail_R, RotateFlipType.RotateNoneFlipX);
            m_skSkin.Tail_U = PFunc.Image_Rotate(m_skSkin.Tail_R, RotateFlipType.Rotate270FlipNone);
            m_skSkin.Tail_D = PFunc.Image_Rotate(m_skSkin.Tail_R, RotateFlipType.Rotate90FlipNone);
        }

        void Food_Load(bool IsB64)
        {
            m_skSkin.Food = IsB64 ? PFunc.Base64_ToImage(DefaultSkin.strFood) : PFunc.Image_Load(m_sipSkinp.Foodp);
        }

        void Wall_Load(bool IsB64)
        {
            m_skSkin.Wall = IsB64 ? PFunc.Base64_ToImage(DefaultSkin.strWall) : PFunc.Image_Load(m_sipSkinp.Wallp);
        }

        #endregion

        #endregion

        #region Properties

        #region MapInfo

        public string Name
        {
            get
            {
                return m_miMap.Name;
            }
            set
            {
                m_miMap.Name = value;
            }
        }

        public int Width
        {
            get
            {
                return m_miMap.Width;
            }
            set
            {
                m_miMap.Width = value;
            }
        }

        public int Height
        {
            get
            {
                return m_miMap.Height;
            }
            set
            {
                m_miMap.Height = value;
            }
        }

        public int BlockSize
        {
            get
            {
                return m_miMap.BlockSize;
            }
            set
            {
                m_miMap.BlockSize = value;
            }
        }

        public int Interval
        {
            get
            {
                return m_miMap.Interval;
            }
            set
            {
                m_miMap.Interval = value;
            }
        }

        public int SnakeLength
        {
            get
            {
                return m_miMap.SnakeLength;
            }
            set
            {
                m_miMap.SnakeLength = value;
            }
        }

        public int Version
        {
            get
            {
                return m_miMap.Version;
            }
        }

        #endregion

        #region ThemeInfo

        public MapInfo MapInfo
        {
            get
            {
                return m_miMap;
            }
            set
            {
                m_miMap = value;
            }
        }

        //No transparent
        public Color Background
        {
            get
            {
                return m_tiTheme.Background;

            }
            set
            {
                m_tiTheme.Background = value;
            }
        }

        public Color Foreground
        {
            get
            {
                return m_tiTheme.Foreground;

            }
            set
            {
                m_tiTheme.Foreground = value;
            }
        }


        #endregion

        #region SkinInfoPath

        public string BodyRDp
        {
            get
            {
                return m_sipSkinp.BodyDRp;
            }
            set
            {
                m_sipSkinp.BodyDRp = value;
                Body_Rot(false);
            }
        }

        public string BodyFatRDp
        {
            get
            {
                return m_sipSkinp.BodyFatDRp;
            }
            set
            {
                m_sipSkinp.BodyFatDRp = value;
                BodyFat_Rot(false);
            }
        }

        public string HeadRp
        {
            get
            {
                return m_sipSkinp.HeadRp;
            }
            set
            {
                m_sipSkinp.HeadRp = value;
                Head_Rot(false);
            }
        }

        public string HeadEatRp
        {
            get
            {
                return m_sipSkinp.HeadEatRp;
            }
            set
            {
                m_sipSkinp.HeadEatRp = value;
                HeadEat_Rot(false);
            }
        }

        public string TailRp
        {
            get
            {
                return m_sipSkinp.TailRp;
            }
            set
            {
                m_sipSkinp.TailRp = value;
                Tail_Rot(false);
            }
        }

        public string TurnURp
        {
            get
            {
                return m_sipSkinp.TurnURp;
            }
            set
            {
                m_sipSkinp.TurnURp = value;
                Turn_Rot(false);
            }
        }

        public string TurnFatURp
        {
            get
            {
                return m_sipSkinp.TurnFatURp;
            }
            set
            {
                m_sipSkinp.TurnFatURp = value;
                TurnFat_Rot(false);
            }
        }

        public string Foodp
        {
            get
            {
                return m_sipSkinp.Foodp;
            }
            set
            {
                m_sipSkinp.Foodp = value;
                Food_Load(false);
                
            }
        }

        public string Wallp
        {
            get
            {
                return m_sipSkinp.Wallp;
            }
            set
            {
                m_sipSkinp.Wallp = value;
                Wall_Load(false);
            }
        }

        #endregion

        #region SkinImage
        //Need seperate?

        public Skin SnakeeSkin
        {
            get
            {
                return m_skSkin;
            }
            set
            {
                m_skSkin = value;
            }
        }


        #endregion

        #region SnakeWallLoc

        // Check for error?
        public List<Point> SnakeBodyPoint
        {
            get
            {
                return m_pSnakeLoc;
            }
            set
            {
                m_pSnakeLoc = value;
            }
        }

        public List<Point> WallPoint
        {
            get
            {
                return m_pWallLoc;
            }
            set
            {
                m_pWallLoc = value;
            }
        }

        #endregion

        #region WarningError
        public List<string> Warnings
        {
            get
            {
                return Check_Warning();
            }
        }

        public List<string> Errors
        {
            get
            {
                return Check_Error();
            }
        }
        #endregion

        #region Saving
        public string FileName
        {
            get
            {
                return m_strFileName;
            }
            set
            {
                m_strFileName = value;
            }
        }
        #endregion

        #region Preview
        public Bitmap Preview
        {
            get
            {
                Preview_Gen();
                return m_bPreview;
            }
            set
            {
                m_bPreview = value;
            }
        }
        #endregion

        #endregion

        #region PublicFunc

        public void Save(string FileName)
        {
            if (FileName == "")
            {
                return;
            }
            Map_Save(FileName);
        }
        /// <summary>
        /// Use FileName property to set saving filename
        /// </summary>
        public void Save()
        {
            Save(m_strFileName);
        }

        public void LoadDefault()
        {
            Default_Load();
        }

        public void Load(string FileName)
        {
            if (FileName == "")
            {
                return;
            }
            Map_Load(FileName);
        }

        #endregion
        
    }

}


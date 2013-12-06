using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Drawing.Imaging;
using System.Xml;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Snakee
{
    class PFunc
    {
        public static string Color_ToHexString(Color ToConvert)
        {
            return ToConvert.A.ToString("X2") + ToConvert.R.ToString("X2") + ToConvert.G.ToString("X2") + ToConvert.B.ToString("X2");
        }

        public static Color Hex_ToColor(string Hex)  //without #
        {
            int iArgb = int.Parse(Hex, NumberStyles.HexNumber);
            return Color.FromArgb(iArgb);
        }

        public static string String_Limit(string Text, int Limit)
        {
            if (Text.Length > Limit)
            {
                return Text.Remove(Limit) + "...";
            }
            return Text;
        }

        public static Image Base64_ToImage(string Base64)
        {
            byte[] bImage = Convert.FromBase64String(Base64);
            MemoryStream ms = new MemoryStream(bImage, 0, bImage.Length);
            ms.Write(bImage, 0, bImage.Length);
            return Image.FromStream(ms, true);
        }

        public static string Image_ToBase64(Image image, ImageFormat imagef)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, imagef);
            byte[] bImage = ms.ToArray();
            return Convert.ToBase64String(bImage);
        }

        public static Image Image_Rotate(Image ImageRotate, RotateFlipType RotateFlip)
        {
            if (ImageRotate != null)
            {
                Image i = (Image)ImageRotate.Clone();
                i.RotateFlip(RotateFlip);
                return i;
            }
            else
            {
                return null;
            }
        }

        public static String XML_Read(XmlDocument xd, string Node)
        {
            return xd.SelectSingleNode(Node).InnerText;
        }

        public static void XML_WriteElement(XmlTextWriter xtw, string start, string text)
        {
            xtw.WriteStartElement(start);
            xtw.WriteString(text);
            xtw.WriteEndElement();
        }

        public static Point String_ToPoint(string ToConvert)
        {
            if (ToConvert == "")
                throw new Exception("No string to convert to point");
            string[] str = Regex.Replace(ToConvert, @"[\{\}a-zA-Z=]", "").Split(',');
            Point p = new Point(int.Parse(str[0]), int.Parse(str[1]));
            return p;
        }

        public static Image Image_Load(string Path)
        {
            if (Path != "")
            {
                Image i = Image.FromFile(Path);
                return i;
            }
            return null;
        }

        public static string SaveFile_Show(string Filter, string Filename)
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

        public static String OpenFile_Show(string Filter,string Filename)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = Filter;
            ofd.FileName = Filename;
            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName != "")
            {
                return ofd.FileName;
            }
            else
            {
                return "";
            }
        }

        public static Color ColorDialog_Show()
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                return cd.Color;
            }
            else
            {
                return Color.Empty;
            }
        }

        public static string BrowserFolder_Show(string Descript)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Application.StartupPath;
            fbd.Description = Descript;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                return fbd.SelectedPath;
            }
            else
            {
                return "";
            }
        }

        public static bool TextBox_CheckNumeric(Keys ToCheck)
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

        public static void XML_Edit(XmlDocument xd, string Filename, String Node, String Text)
        {
            xd.SelectSingleNode(Node).InnerText = Text;
            xd.Save(Filename);
        }

        public static List<Point> Snakee_CalPoint(int Width, int Height, int SnakeLength)
        {
            int center = (Width - 1) / 2 - SnakeLength / 2;
            List<Point> pList = new List<Point>();
            for (int i = 0; i < SnakeLength; i++)
            {
                Point p = new Point((Height - 1) / 2, center + i);
                pList.Add(p);
            }
            return pList;
        }

    }


}

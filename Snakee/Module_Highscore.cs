using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Snakee
{
    partial class frmHighScore
    {
        int m_iInfoBigFontSize = 20;
        int m_iInfoSmallFontSize = 12;

        void All_Init()
        {
            Title_Draw();
            Highscore_Draw();
        }
       
        void Title_Draw()
        {
            StringFormat sfFormat = new StringFormat();
            sfFormat.Alignment = StringAlignment.Center;
            sfFormat.LineAlignment = StringAlignment.Center;
            String_Draw(picTitle, UIString.HighScoreForm.HighScoreTitle, m_iInfoBigFontSize, new SolidBrush(frmMain.m_meMap.Foreground), sfFormat);
        }

        void Highscore_Draw()
        {
            string strDraw =UIString.HighScoreForm.NoTitle + "   "+  UIString.HighScoreForm.NameTitle + "\t" + UIString.HighScoreForm.MapTitle + "\t" + UIString.HighScoreForm.ScoreTitle + Environment.NewLine;
            for (int i = 0; i < frmMain.m_hsiHighScore.Count; i++)
            {
                HighScoreInfo hsi = frmMain.m_hsiHighScore[i];
                strDraw += "# " + hsi.Rank.ToString() + "   " + PFunc.String_Limit(hsi.Name, 15) + "\t" + PFunc.String_Limit(hsi.Map, 10) + "\t" + PFunc.String_Limit(hsi.Score.ToString(), 15) + Environment.NewLine;
            }
            StringFormat sfFormat = new StringFormat();
            sfFormat.SetTabStops(0, new float[] { 150,100,150 });
            String_Draw(picScore, strDraw, m_iInfoSmallFontSize, new SolidBrush(frmMain.m_meMap.Foreground), sfFormat);
        }

        void String_Draw(PictureBox PicDes, string Text, int FontSize,SolidBrush TextColor,StringFormat TextFormat)
        {
            Bitmap bPic = new Bitmap(PicDes.Width, PicDes.Height);
            Graphics gPic = Graphics.FromImage(bPic);
            
            gPic.TextRenderingHint = TextRenderingHint.AntiAlias;
            gPic.DrawString(Text, new Font("Segoe UI", FontSize), TextColor, PicDes.ClientRectangle, TextFormat);
            PicDes.Image = bPic;

        }

    }
}

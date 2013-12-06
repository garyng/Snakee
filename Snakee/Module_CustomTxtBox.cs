using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;

namespace CustomTextBox
{
    public partial class CustomTxtBox 
    {
        string m_strCaption = "Custom Text Box";

        [Browsable(true)]
        public override string Text
        {
            get
            {
                return txtText.Text;
            }
            set
            {
                txtText.Text = value;
            }
        }

        public string Caption
        {
            get
            {
                return m_strCaption;
            }
            set
            {
                m_strCaption = value;
                String_Draw(picCaption, m_strCaption);
            }

        }

        public bool ReadOnly
        {
            get
            {
               return txtText.ReadOnly;
            }
            set
            {
                txtText.ReadOnly = value;
            }
        }


        void Control_Resize()
        {
            txtText.Width = this.Width;
            txtText.Location = Point.Empty;
            picCaption.Location = Point.Empty;
            picCaption.Size = txtText.Size;

            this.Size = new Size(txtText.Width, picCaption.Height);

            //txtText.Width = this.Width;
            //picCaption.Width = this.Width;
            //txtText.Location = Point.Empty;
            //picCaption.Location = Point.Empty;

            //this.Height = txtText.Height;
            //picCaption.Location = Point.Empty;
            //txtText.Location = Point.Empty;
            //picCaption.Size = new Size(this.Width, this.Height);
        }

        void String_Draw(PictureBox PicDes, String Text)
        {
            Bitmap bPic = new Bitmap(PicDes.Width, PicDes.Height);
            Graphics gPic = Graphics.FromImage(bPic);
            gPic.TextRenderingHint = TextRenderingHint.AntiAlias;

            StringFormat sfF = new StringFormat();
            sfF.Alignment = StringAlignment.Center;
            sfF.LineAlignment = StringAlignment.Center;

            gPic.DrawString(Text, base.Font, new SolidBrush(base.ForeColor), PicDes.ClientRectangle, sfF);
            PicDes.Image = bPic;

        }
    }
}

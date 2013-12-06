using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Snakee
{
    public partial class CustomTxtButton
    {
        public bool TxtBoxReadOnly
        {
            get
            {
                return ctbText.ReadOnly;
            }
            set
            {
                ctbText.ReadOnly = value;
            }
        }

        public string Caption
        {
            get
            {
                return ctbText.Caption;
            }
            set
            {
                ctbText.Caption = value;
            }
        }

        [Browsable(true)]
        public override string Text
        {
            get
            {
                return ctbText.Text;
            }
            set
            {
                ctbText.Text = value;
            }
        }

        void Control_Resize()
        {
            ctbText.Location = Point.Empty;
            ctbText.Width = this.Width - btnSelect.Width;
            btnSelect.Location = new Point(ctbText.Right, ctbText.Top);

            btnSelect.Height = ctbText.Height;
            btnSelect.Width = 30;

            this.Size = new Size(ctbText.Width + btnSelect.Width, ctbText.Height);

        }
    }

}

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
    [DefaultEvent("TextBoxKeyDown")]
    public partial class CustomTxtBox : UserControl
    {
        public CustomTxtBox()
        {
            InitializeComponent();
            Control_Resize();
            String_Draw(picCaption, m_strCaption);
            txtText.KeyDown += new KeyEventHandler(txtText_KeyDown);

        }
        [Browsable(true)]
        public event KeyEventHandler TextBoxKeyDown;

        private void picCaption_MouseEnter(object sender, EventArgs e)
        {
            picCaption.Visible = false;
            txtText.Focus();
        }

        private void txtText_MouseLeave(object sender, EventArgs e)
        {
            picCaption.Visible = true;
            picCaption.BringToFront();
            lblForFocus.Focus();
        }

        void txtText_KeyDown(object sender, KeyEventArgs e)
        {
            if (TextBoxKeyDown != null)
            {
                TextBoxKeyDown(sender, e);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            Control_Resize();
            String_Draw(picCaption, m_strCaption);
            base.OnSizeChanged(e);
        }

        private void txtText_MouseEnter(object sender, EventArgs e)
        {
            picCaption.Visible = false;
            txtText.Focus();
        }

    }
}

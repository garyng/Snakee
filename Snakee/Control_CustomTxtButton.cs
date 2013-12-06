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
    [DefaultEvent("ButtonClicked")]
    public partial class CustomTxtButton : UserControl
    {
        [Browsable(true)]
        public event EventHandler ButtonClicked;
        public CustomTxtButton()
        {
            InitializeComponent();
            Control_Resize();
            btnSelect.Click += new EventHandler(btnSelect_Click);
        }

        void btnSelect_Click(object sender, EventArgs e)
        {
            if (ButtonClicked != null)
            {
                ButtonClicked(sender, e);
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            Control_Resize();
            base.OnSizeChanged(e);
        }
    }
}

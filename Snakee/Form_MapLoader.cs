using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snakee
{
    public partial class frmMapLoader : Form
    {
        public frmMapLoader()
        {
            InitializeComponent();
        }

        private void frmMapLoader_Load(object sender, EventArgs e)
        {
            Map_SearchFiles();
            Map_Load();
            Map_LoadButton();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                SelectedMap = "";

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

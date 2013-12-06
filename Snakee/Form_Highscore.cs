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
    public partial class frmHighScore : Form
    {
        public frmHighScore()
        {
            InitializeComponent();
        }

        private void HighScoreForm_Load(object sender, EventArgs e)
        {
            this.BackColor = frmMain.m_meMap.Background;
            picScore.BackColor = frmMain.m_meMap.Background;
            picTitle.BackColor = frmMain.m_meMap.Background;
            All_Init();
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

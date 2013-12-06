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
    public partial class frmMapRemake : Form
    {
        public frmMapRemake()
        {
            InitializeComponent();
        }

        private void Form_Map_Remake_Load(object sender, EventArgs e)
        {    

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MapEditor me = new MapEditor();
            me.Save("xxx.xxx");
        }
    }
}

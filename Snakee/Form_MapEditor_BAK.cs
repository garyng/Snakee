using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomTextBox;

namespace Snakee
{
    public partial class frmMapEditor_Bak : Form
    {
        public frmMapEditor_Bak()
        {
            InitializeComponent();
        }
        private void frmMapEditor_Load(object sender, EventArgs e)
        {
            rbBlack_CheckedChanged(rbBlack, new EventArgs());

            ctbMapName.Text = "Custom Map";
            ctbSnakeInterval.Text = "500";
            ctbMapWidth.Text = "41";
            ctbMapHeight.Text = "41";
            ctbMapPixelSize.Text = "8";
            ctbSnakeLength.Text = "5";


            All_Init();

            lblSkinNote.Focus();


        }

        private void ctbMapWidth_TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (TextBox_CheckNumeric(e.KeyCode) == false)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void ctbMapHeight_TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (TextBox_CheckNumeric(e.KeyCode) == false)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateMap_Init();

        }

        private void btnFore_Click(object sender, EventArgs e)
        {
            ColorDialog cdColor = new ColorDialog();
            if (cdColor.ShowDialog() == DialogResult.OK)
            {
                Theme_Reload(m_essSkin.Background, cdColor.Color);
            }
        }

        private void btnBackground_Click(object sender, EventArgs e)
        {
            ColorDialog cdColor = new ColorDialog();
            if (cdColor.ShowDialog() == DialogResult.OK)
            {
                Theme_Reload(cdColor.Color, m_essSkin.Foreground);
            }
        }

        private void rbNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                Theme_Reload(Color.FromKnownColor(KnownColor.Control), Color.Black);
            }
        }

        private void rbBlack_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                Theme_Reload(Color.Black, Color.White);
            }
        }

        private void ctbMapPixelSize_TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (TextBox_CheckNumeric(e.KeyCode) == false)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void ctbSnakeInterval_TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (TextBox_CheckNumeric(e.KeyCode) == false)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void ctbBodyDRPath_ButtonClicked(object sender, EventArgs e)
        {
            m_essSkin.BodyDRp = ctbBodyDRPath.Text = OpenFile_Show("PNG|*.png");
            Preview_Body();
        }

        private void ctbBodyFatDRPath_ButtonClicked(object sender, EventArgs e)
        {
            m_essSkin.BodyFatDRp = ctbBodyFatDRPath.Text = OpenFile_Show("PNG|*.png");
            Preview_BodyFat();
        }

        private void ctbHeadRPath_ButtonClicked(object sender, EventArgs e)
        {
            m_essSkin.HeadRp = ctbHeadRPath.Text = OpenFile_Show("PNG|*.png");
            Preview_Head();
        }

        private void ctbHeadEatRPath_ButtonClicked(object sender, EventArgs e)
        {
            m_essSkin.HeadEatRp = ctbHeadEatRPath.Text = OpenFile_Show("PNG|*.png");
            Preview_HeadEat();

        }

        private void ctbTailRPath_ButtonClicked(object sender, EventArgs e)
        {
            m_essSkin.TailRp = ctbTailRPath.Text = OpenFile_Show("PNG|*.png");
            Preview_Tail();
        }

        private void ctbTurnURPath_ButtonClicked(object sender, EventArgs e)
        {
            m_essSkin.TurnURp = ctbTurnURPath.Text = OpenFile_Show("PNG|*.png");
            Preview_Turn();
        }

        private void ctbTurnFatUR_ButtonClicked(object sender, EventArgs e)
        {
            m_essSkin.TurnFatURp = ctbTurnFatUR.Text = OpenFile_Show("PNG|*.png");
            Preview_TurnFat();
        }

        private void ctbFoodPath_ButtonClicked(object sender, EventArgs e)
        {
            m_essSkin.Foodp = ctbFoodPath.Text = OpenFile_Show("PNG|*.png");
            Preview_Food();
        }

        private void ctbWallPath_ButtonClicked(object sender, EventArgs e)
        {
            m_essSkin.Wallp = ctbWallPath.Text = OpenFile_Show("PNG|*.png");
            Preview_Wall();
        }

        private void btnSkinDefault_Click(object sender, EventArgs e)
        {
            Skin_LoadDefault();
        }

        private void rbPaintWall_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                m_paPaint = PaintAction.Wall;
            }
        }

        private void ctbSnakeLength_TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (TextBox_CheckNumeric(e.KeyCode) == false)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Map_Save();
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            Map_SaveAs();
        }
    }
}

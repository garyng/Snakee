using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Snakee.Properties;
using System.Threading;

namespace Snakee
{
    public partial class frmMapEditor : Form
    {
        Size m_szSize = new Size(700, 600);

        public frmMapEditor()
        {
            InitializeComponent();
        }

        private void frmMapEditor_Load(object sender, EventArgs e)
        {
            this.Size = m_szSize;
            All_Init();
            Home_Visible(true);

            ErrorWarning_InitImage(plbSkinPath);
        }

        private void btnNewMap_Click(object sender, EventArgs e)
        {
            InfoEditor_NewMap(); 
        }

        private void btnLoadMap_Click(object sender, EventArgs e)
        {
            InfoEditor_LoadMap();
        }

        private void btnThemeBack_Click(object sender, EventArgs e)
        {
            Color cRet = PFunc.ColorDialog_Show();
            if (cRet != Color.Empty)
            {
                m_meMap.Background = cRet;
                ThemeInfo_DrawPreview();
            }
        }

        private void btnThemeFore_Click(object sender, EventArgs e)
        {
            Color cRet = PFunc.ColorDialog_Show();
            if (cRet != Color.Empty)
            {
                m_meMap.Foreground = cRet;
                ThemeInfo_DrawPreview();
            }
        }

        private void plbSkinPath_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PictureListBox plb = sender as PictureListBox;
            string strFileName = PFunc.OpenFile_Show("PNG Files|*.PNG","*.PNG");
            if (strFileName != "")
            {
                SkinInfo_LoadPre(plb.SelectedIndex, strFileName, plb);
            }
            else
            {
                return;
            }
        }

        private void tsbtnDefault_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to reload default value?", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Default_Load();

            }
        }

        private void tsbtnBack_Click(object sender, EventArgs e)
        {
            Back_ToHome();
        }

        private void btnImportSkin_Click(object sender, EventArgs e)
        {
            string strFolder = PFunc.BrowserFolder_Show("Select the folder that contains the specific snakee's skin PNG files.");
            if (strFolder != "")
            {
                SkinInfo_BatchImport(strFolder + @"\");
            }
        }

        private void tsbtnGenMap_Click(object sender, EventArgs e)
        {
            GenMap_Generate();

        }

        private void tsbtnBackToSkin_Click(object sender, EventArgs e)
        {
            Back_ToSkin();
        }

        private void pnlMapBoxCon_MouseLeave(object sender, EventArgs e)
        {
            Map_CheckMouse(pnlMapBoxCon.ClientRectangle, Cursor.Position);
        }

        private void pnlMapBoxCon_MouseUp(object sender, MouseEventArgs e)
        {
            Map_DrawingClear();
        }

        private void tsbtnBlock_Click(object sender, EventArgs e)
        {
            m_daDraw = DrawAction.Block;
            DrawingAct_Exclusive(sender);
        }

        private void tsbtnRectFill_Click(object sender, EventArgs e)
        {
            m_daDraw = DrawAction.FillRectangle;
            DrawingAct_Exclusive(sender);
        }

        private void tsbtnRectDraw_Click(object sender, EventArgs e)
        {
            m_daDraw = DrawAction.DrawRectangle;
            DrawingAct_Exclusive(sender);
        }

        private void tsBarMap_MouseEnter(object sender, EventArgs e)
        {
            Map_DrawingClear();
        }

        private void ctbMapWidth_TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (PFunc.TextBox_CheckNumeric(e.KeyCode) == false)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void ctbMapHeight_TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (PFunc.TextBox_CheckNumeric(e.KeyCode) == false)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void ctbMapBlockSize_TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (PFunc.TextBox_CheckNumeric(e.KeyCode) == false)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void ctbMapSnakeLength_TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (PFunc.TextBox_CheckNumeric(e.KeyCode) == false)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void ctbMapInterval_TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (PFunc.TextBox_CheckNumeric(e.KeyCode) == false)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void tsbtnLine_Click(object sender, EventArgs e)
        {
            m_daDraw = DrawAction.Line;
            DrawingAct_Exclusive(sender);
        }

        private void tsbtnUndo_Click(object sender, EventArgs e)
        {
            Map_Undo();
        }

        private void tsbtnMapSave_Click(object sender, EventArgs e)
        {
            Map_Save();
        }

        private void tsbtnRedo_Click(object sender, EventArgs e)
        {
            Map_Redo();
        }

        private void frmMapEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_tMapGen != null && m_tMapGen.ThreadState != ThreadState.Aborted)
            {
                m_tMapGen.Abort();
            }
        }
    }
}

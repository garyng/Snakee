using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Security.Permissions;

namespace Snakee
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private void frmMain_Load(object sender, EventArgs e)
        {

            All_Init();

            txtKeyInput.Multiline = true;
            txtKeyInput.BorderStyle = BorderStyle.None;
            txtKeyInput.Size = new Size(0, 0);
            txtKeyInput.Location = new Point(0, 0);
            txtKeyInput.GotFocus += new EventHandler(txtKeyInput_GotFocus);

            Game g = new Game("BlaBla.Xml");

        }

        void txtKeyInput_GotFocus(object sender, EventArgs e)
        {
            Win32API.HideCaret(txtKeyInput.Handle);
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            bool bDirection = e.KeyCode == KeysControl.Left || e.KeyCode == KeysControl.Right || e.KeyCode == KeysControl.Up || e.KeyCode == KeysControl.Down;

            if (bDirection)
            {

                m_sdCurrent = (SnakeDirection)Enum.Parse(typeof(SnakeDirection), e.KeyCode.ToString().ToLower(), true);
                Snake_Move();
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == KeysControl.Start)
            {
                if (m_psCurrent == PlayState.Stopped || m_psCurrent == PlayState.Paused)
                {
                    if (m_psCurrent == PlayState.Stopped)
                    {
                        m_caAct = ClickedAction.Start;
                    }
                    else
                    {
                        m_caAct = ClickedAction.Resume;
                    }
                    InfoBox_DoAction();
                    e.SuppressKeyPress = true;
                }
            }
            else if (e.KeyCode == KeysControl.Pause)
            {
                if (m_psCurrent == PlayState.Started)
                {
                    m_caAct = ClickedAction.Pause;
                    InfoBox_DoAction();
                    e.SuppressKeyPress = true;
                }
            }
            else if (e.KeyCode == KeysControl.Stop)
            {
                if (m_psCurrent == PlayState.Started || m_psCurrent == PlayState.Paused)
                {
                    m_caAct = ClickedAction.Stop;
                    InfoBox_DoAction();
                    e.SuppressKeyPress = true;
                }
            }
            else if (e.KeyCode == KeysControl.Restart)
            {
                if (m_psCurrent == PlayState.GameOver)
                {
                    m_caAct = ClickedAction.Stop;
                    InfoBox_DoAction();
                    e.SuppressKeyPress = true;
                }
            }
            else if (e.KeyCode == KeysControl.Highscore)
            {
                if (m_psCurrent == PlayState.Stopped || m_psCurrent == PlayState.Paused)
                {
                    m_caAct = ClickedAction.Highscore;
                    InfoBox_DoAction();
                    e.SuppressKeyPress = true;
                }
            }
            else if (e.KeyCode == KeysControl.MapEditor)
            {
                if (m_psCurrent == PlayState.Stopped)
                {
                    m_caAct = ClickedAction.MapEditor;
                    InfoBox_DoAction();
                    e.SuppressKeyPress = true;
                }
            }
            else if (e.KeyCode == KeysControl.MapLoader)
            {
                if (m_psCurrent == PlayState.Stopped)
                {
                    m_caAct = ClickedAction.MapLoader;
                    InfoBox_DoAction();
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void txtKeyInput_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            bool bIpKey = e.KeyCode == KeysControl.Left || e.KeyCode == KeysControl.Right || e.KeyCode == KeysControl.Up || e.KeyCode == KeysControl.Down || e.KeyCode == KeysControl.Start || e.KeyCode == KeysControl.Pause || e.KeyCode == KeysControl.Restart || e.KeyCode == KeysControl.Stop || e.KeyCode == KeysControl.MapEditor || e.KeyCode == KeysControl.Highscore||e.KeyCode == KeysControl.MapLoader;
            if (bIpKey)
            {
                e.IsInputKey = true;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_tMoving.ThreadState == ThreadState.Suspended)
            {
                m_tMoving.Resume();

            }
            if (m_tMoving.ThreadState != ThreadState.Aborted)
            {
                m_tMoving.Abort();
            }

            if (m_tMapInit != null && m_tMapInit.ThreadState != ThreadState.Aborted)
            {
                m_tMapInit.Abort();
            }
            if (m_tTipsShow != null && m_tTipsShow.ThreadState != ThreadState.Aborted)
            {
                m_tTipsShow.Abort();
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Win32API.WM_SYSCOMMAND)
            {
                if ((m.WParam.ToInt32() & 0xfff0) == Win32API.SC_MINIMIZE)
                {
                    if (m_psCurrent != PlayState.Paused && m_psCurrent == PlayState.Started)
                    {
                        m_caAct = ClickedAction.Pause;
                        InfoBox_DoAction();
                    }

                }
            }
            base.WndProc(ref m);
        }

        private void frmMain_Deactivate(object sender, EventArgs e)
        {
            if (m_psCurrent != PlayState.Paused && m_psCurrent == PlayState.Started && this.Disposing != true)
            {
                m_caAct = ClickedAction.Pause;
                InfoBox_DoAction();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == KeysControl.GodMode)
            {
                m_caAct = ClickedAction.GodMode;
                InfoBox_DoAction();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }



}

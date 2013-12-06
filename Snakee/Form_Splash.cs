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
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void InitializeStyles()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            UpdateStyles();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            InitializeStyles();
            base.OnHandleCreated(e);
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            Bitmap bSplash = Properties.Resources.snakee_splash;
            Bitmap_SetBits(bSplash);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cParms = base.CreateParams;
                cParms.ExStyle |= 0x00080000; // WS_EX_LAYERED
                return cParms;
            }
        }


        void Bitmap_SetBits(Bitmap image)
        {
            if (!Bitmap.IsCanonicalPixelFormat(image.PixelFormat) || !Bitmap.IsAlphaPixelFormat(image.PixelFormat))
            {
                return;
            }
            IntPtr ipOld = IntPtr.Zero;
            IntPtr ipScreenDc = Win32API.GetDC(IntPtr.Zero);
            IntPtr ipBitmap = IntPtr.Zero;
            IntPtr ipMemDc = Win32API.CreateCompatibleDC(ipScreenDc);

            try
            {
                Win32API.Point pTop = new Win32API.Point(Left, Top);
                Win32API.Size szImgSize = new Win32API.Size(image.Width, image.Height);
                Win32API.BLENDFUNCTION bfFunc = new Win32API.BLENDFUNCTION();
                Win32API.Point pSrc = new Win32API.Point(0, 0);

                ipBitmap = image.GetHbitmap(Color.FromArgb(0));
                ipOld = Win32API.SelectObject(ipMemDc, ipBitmap);

                bfFunc.BlendOp = Win32API.AC_SRC_OVER;
                bfFunc.SourceConstantAlpha = 255;
                bfFunc.AlphaFormat = Win32API.AC_SRC_ALPHA;
                bfFunc.BlendFlags = 0;

                Win32API.UpdateLayeredWindow(Handle, ipScreenDc, ref pTop, ref szImgSize, ipMemDc, ref pSrc, 0, ref bfFunc, Win32API.ULW_ALPHA);

            }
            finally
            {
                if (ipBitmap != IntPtr.Zero)
                {
                    Win32API.SelectObject(ipMemDc,ipOld);
                    Win32API.DeleteDC(ipBitmap);
                }
                Win32API.ReleaseDC(IntPtr.Zero,ipScreenDc);
                Win32API.DeleteDC(ipMemDc);
            }

        }



        private void frmSplash_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Win32API.ReleaseCapture();
                Win32API.SendMessage(Handle, Win32API.WM_NCLBUTTONDOWN, Win32API.HT_CAPTION, 0);
            }

        }
    }
}

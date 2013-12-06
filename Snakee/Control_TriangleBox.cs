using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Snakee
{
    class TriangleBox:Control
    {
        int m_iOffset = 3;
        int m_iLength = 15;

        public TriangleBox()
        {
            this.DoubleBuffered = true;
        }


        protected override void OnPaint(PaintEventArgs e)
        {


            Bitmap b = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);

            Graphics gb = Graphics.FromImage(b);


            GraphicsState gs = gb.Save();

            Rectangle rctClient = this.ClientRectangle;
            rctClient.Offset(this.Location);
            gb.TranslateTransform(-(float)this.Location.X, -(float)this.Location.Y);

            PaintEventArgs pe = new PaintEventArgs(gb, rctClient);
            this.InvokePaintBackground(this.Parent, pe);
            this.InvokePaint(this.Parent, pe);

            gb.Restore(gs);



            gb.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(0, m_iLength + m_iOffset, m_iLength, Offset);
            gp.AddLine(m_iLength, m_iOffset, m_iLength, m_iLength * 2 + m_iOffset);
            gp.CloseAllFigures();

            gb.FillPath(new SolidBrush(base.BackColor), gp);
            gb.DrawPath(new Pen(base.ForeColor), gp);

            Rectangle rectMain = new Rectangle(m_iLength, 0, this.ClientRectangle.Width - m_iLength - 1, this.ClientRectangle.Height - 1);
            gb.FillRectangle(new SolidBrush(base.BackColor), rectMain);
            gb.DrawRectangle(new Pen(base.ForeColor), rectMain);
            gb.DrawLine(new Pen(base.BackColor), m_iLength, m_iOffset + 1, m_iLength, m_iLength * 2 + m_iOffset - 1);

            e.Graphics.DrawImageUnscaled(b, Point.Empty);        
        }

        //Bitmap b = new Bitmap(m_miMap.Width * m_miMap.BlockSize, m_miMap.Height * m_miMap.BlockSize);
        //Graphics g = Graphics.FromImage(b);
        //g.Clear(m_tiTheme.Background);

        //IntPtr target = g.GetHdc();
        //IntPtr source = Win32API.CreateCompatibleDC(target);

        //Bitmap bT = new Bitmap(m_skSkin.Wall);
        //IntPtr hBit = bT.GetHbitmap(Color.Black);

        //IntPtr Ori = Win32API.SelectObject(source, hBit);

        ////Win32API.BitBlt(target, 0, 0, bT.Width, bT.Height, source, 0, 0, Win32API.TernaryRasterOperations.SRCCOPY);

        //Win32API.BLENDFUNCTION bd = new Win32API.BLENDFUNCTION();
        //bd.BlendOp  = Win32API.AC_SRC_OVER;
        //bd.BlendFlags = 0;
        //bd.SourceConstantAlpha = 0xff;
        //bd.AlphaFormat = Win32API.AC_SRC_ALPHA;

        ////Win32API.AlphaBlend(target, 0, 0, bT.Width, bT.Height, source, 0, 0, bT.Width, bT.Height, bd);

        //IntPtr New = Win32API.SelectObject(source, Ori);
        //Win32API.DeleteObject(New);
        //Win32API.DeleteDC(source);


        //g.ReleaseHdc(target);

        //m_bPreview = new Bitmap(b);
        
        #region Properties

        public int Offset
        {
            get
            {
                return m_iOffset;
            }
            set
            {
                m_iOffset = value;
                this.Invalidate();
            }
        }

        public int Length
        {
            get
            {
                return m_iLength;
            }
            set
            {
                m_iLength = value;
                this.Invalidate();
            }
        }

        #endregion



    }
}

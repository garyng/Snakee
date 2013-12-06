using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Snakee
{
    class ClassicScoller:Control
    {
        static int m_iStep = 10;
        int m_iDist = 0;
        Size m_szSize = new Size(10, 100);

        static int m_iValue = 0;
        static int m_iMinValue = -100;
        static int m_iMaxValue = 100;

        int m_iDrawStep =  (m_iMaxValue - m_iMinValue) / (m_iStep - 1);

        List<Rectangle> m_rctAll = new List<Rectangle>();
        int m_iDrawIndex = -1;

        bool m_bClicked = false;

        public ClassicScoller()
        {
            this.DoubleBuffered = true;
            this.MouseMove += new MouseEventHandler(ClassicScoller_MouseMove);
            this.MouseDown += new MouseEventHandler(ClassicScoller_MouseDown);
            this.MouseUp += new MouseEventHandler(ClassicScoller_MouseUp);

            int h = m_szSize.Height / m_iStep;
            for (int i = 0; i < m_iStep; i++)
            {
                Rectangle rect = new Rectangle(m_iDist * i + m_szSize.Width * i, m_szSize.Height - h * (i + 1), m_szSize.Width, h * (i + 1));
                m_rctAll.Add(rect);
            }
        }

        void ClassicScoller_MouseUp(object sender, MouseEventArgs e)
        {
            m_bClicked = false;
        }

        void ClassicScoller_MouseDown(object sender, MouseEventArgs e)
        {
            m_bClicked = true;
        }

        void ClassicScoller_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_bClicked)
            {
                Rectangle rect = m_rctAll.Find(item => item.Contains(e.Location));
                m_iDrawIndex = m_rctAll.IndexOf(rect);
                m_iValue = m_iMinValue +  (m_iMaxValue - m_iMinValue) / m_iStep * (m_iDrawIndex + 1);
                this.Invalidate();
                //Console.WriteLine(m_iDrawIndex.ToString());
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            Graphics gb = Graphics.FromImage(b);
            m_iDrawStep = (m_iMaxValue - m_iMinValue) / (m_iStep - 1);
            m_iDrawIndex = (int)Math.Floor((m_iValue - m_iMinValue) / (double)m_iDrawStep);
            for (int i = 0; i < m_iStep; i++)
            {
                if (i <= m_iDrawIndex)
                {
                    gb.FillRectangle(Brushes.Blue, m_rctAll[i]);
                }
                gb.DrawRectangle(Pens.Black, m_rctAll[i]);
            }
            base.Text = m_iValue.ToString();
            Draw_Label(gb, new Size(m_szSize.Width * m_iStep + (m_iStep - 1) * m_iDist + 1, m_szSize.Height + 1));
            e.Graphics.DrawImageUnscaled(b, Point.Empty);
        }

        void Draw_Label(Graphics g,Size size)
        {
            Size sz = size;
            int iY = size.Height + 1;
            int iHeight = (int)Math.Ceiling( g.MeasureString(base.Text, base.Font).Height);
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            SizeF szf = g.MeasureString(base.Text,base.Font);
            g.DrawString(base.Text, base.Font, new SolidBrush(base.ForeColor),new Point(0,iY));
            this.Size = new Size(size.Width, size.Height + iHeight + 1);
        }

        public int Value
        {
            get
            {
                return m_iValue;
            }
            set
            {
                m_iValue = value;
                if (m_iValue < m_iMinValue) m_iValue = m_iMinValue;
                if (m_iValue > m_iMaxValue) m_iValue = m_iMaxValue;
                //m_iDrawIndex = (int)Math.Floor((value - m_iMinValue) / (double)m_iDrawStep);
                this.Invalidate();
            }
        }


        public int Max
        {
            get
            {
                return m_iMaxValue;
            }
            set
            {
                m_iMaxValue = value;
                if (m_iValue > m_iMaxValue) m_iValue = m_iMaxValue;
                //m_iDrawIndex = (int)Math.Floor((m_iValue - m_iMinValue) / (double)m_iDrawStep);
                this.Invalidate();
            }
        }

        public int Min
        {
            get
            {
                return m_iMinValue;
            }
            set
            {
                m_iMinValue = value;
                if (m_iValue < m_iMinValue) m_iValue = m_iMinValue;
                this.Invalidate();
                //this.Invalidate();
            }
        }


    }
}


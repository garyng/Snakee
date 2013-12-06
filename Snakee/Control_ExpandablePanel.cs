using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Windows.Forms.VisualStyles;

namespace Snakee
{
    [ToolboxBitmap(typeof(ExpandablePanel))]
    [DefaultEvent("OnToggleClicked")]
    class ExpandablePanel : Panel
    {

        Size m_szToggleSize = new Size(10, 10);  //Odd better

        Rectangle m_rectToggle = new Rectangle();
        Rectangle m_rectDraw = new Rectangle();
        Rectangle m_rectSmallToggle = new Rectangle();
        Rectangle m_rectOriginal = new Rectangle();


        Bitmap m_bTogglePlus;
        Bitmap m_bToggleMinus;

        bool m_bIsExpand = true;
        string m_strCaption = "Expandable Panel";

        public delegate void ToggleClickedHandler(object sender);
        public event ToggleClickedHandler OnToggleClicked;

        public ExpandablePanel()
        {
            //Optional
            base.AutoScroll = true;
            this.DoubleBuffered = true;
            Rect_Init();
            Toggle_Init();
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            Draw_Box(e.Graphics);
            Toggle_Draw(e.Graphics);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (m_rectToggle.Contains(e.Location))
            {
                Toggle_Clicked();
            }
            else
            {
                base.OnMouseUp(e);
            }
        }

        void Rect_Init()
        {
            m_rectToggle = new Rectangle(new Point(this.ClientRectangle.X + m_szToggleSize.Width / 4, this.ClientRectangle.Y), m_szToggleSize);
            m_rectSmallToggle = new Rectangle(new Point(1, 1), new Size(m_szToggleSize.Width - 2, m_szToggleSize.Height - 2));
        }

        void Toggle_Init()
        {
            Toggle_Plus();
            Toggle_Minus();
        }

        void Toggle_Plus()
        {
            m_bTogglePlus = new Bitmap(m_szToggleSize.Width, m_szToggleSize.Height);
            Graphics g = Graphics.FromImage(m_bTogglePlus);

            g.DrawRectangle(Pens.Gray, m_rectSmallToggle);
            g.DrawLine(Pens.Gray, new Point(3, 5), new Point(7, 5));
            g.DrawLine(Pens.Gray, new Point(5, 3), new Point(5, 7));
            g.Dispose();
        }

        void Toggle_Minus()
        {
            m_bToggleMinus = new Bitmap(m_szToggleSize.Width, m_szToggleSize.Height);
            Graphics g = Graphics.FromImage(m_bToggleMinus);
            g.DrawRectangle(Pens.Gray, m_rectSmallToggle);
            g.DrawLine(Pens.Gray, new Point(3, 5), new Point(7, 5));
        }

        void Draw_Box(Graphics g)
        {
            if (m_rectOriginal.IsEmpty)
            {
                m_rectOriginal = this.ClientRectangle;
            }

            m_rectDraw = new Rectangle(new Point(this.ClientRectangle.X, this.ClientRectangle.Y + m_szToggleSize.Height / 2), new Size(this.ClientRectangle.Width, this.ClientRectangle.Height - m_szToggleSize.Height / 2));
            g.SmoothingMode = SmoothingMode.AntiAlias;
            GroupBoxRenderer.DrawGroupBox(g, m_rectDraw, base.Enabled ? GroupBoxState.Normal : GroupBoxState.Disabled);
            Draw_String(g);
        }

        void Draw_String(Graphics g)
        {
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            int iTxtX = m_rectToggle.X + m_rectToggle.Width + 2;
            int iTxtWidth = (int)Math.Ceiling(g.MeasureString(m_strCaption, base.Font).Width);
            iTxtWidth = iTxtWidth < 1 ? 1 : iTxtWidth;
            int iTxtEnd = iTxtX + iTxtWidth + 1;

            g.DrawLine(new Pen(base.BackColor, 1), new Point(iTxtX, m_rectDraw.Y), new Point(iTxtEnd, m_rectDraw.Y));
            g.DrawString(m_strCaption, base.Font, new SolidBrush(base.ForeColor), iTxtX, -3);
        }

        void Toggle_Draw(Graphics g)
        {
            if (m_bIsExpand == true)
            {
                g.DrawImageUnscaled(m_bToggleMinus, new Point(m_rectToggle.X, m_rectToggle.Y));
            }
            else
            {
                g.DrawImageUnscaled(m_bTogglePlus, new Point(m_rectToggle.X, m_rectToggle.Y));
            }
        }

        void Toggle_Clicked()
        {
            IsExpand = !IsExpand;
            if (OnToggleClicked != null)
            {
                OnToggleClicked(this);
            }
        }

        void Box_Resize(bool Expand)
        {
            this.AutoScroll = Expand;
            if (Expand == false)
            {
                this.Height = m_szToggleSize.Height + 3;
            }
            else
            {
                this.Height = m_rectOriginal.Height;
            }
        }

        public bool IsExpand
        {
            get
            {
                return m_bIsExpand;
            }
            set
            {
                m_bIsExpand = value;
                Box_Resize(value);
                this.Invalidate();
            }
        }

        public string Caption
        {
            get
            {
                return m_strCaption;
            }
            set
            {
                m_strCaption = value;
                this.Invalidate();
            }
        }
    }

}

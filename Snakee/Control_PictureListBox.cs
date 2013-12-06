using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Diagnostics;


namespace Snakee
{
    public class PictureListBox : ListBox
    {
        List<object> m_Images = new List<object>();
        Color m_cSelected = Color.FromArgb(194, 224, 255);

        public PictureListBox()
        {
            this.DrawMode = DrawMode.OwnerDrawVariable;
            this.HorizontalScrollbar = true;
            this.DoubleBuffered = true;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= this.Items.Count || e.Index <= -1)
            {
                return;
            }

            object objItem = this.Items[e.Index];
            if (objItem == null)
            {
                return;
            }

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(m_cSelected), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(base.BackColor), e.Bounds);
            }

            string str = (string)objItem;

            Image img = null;
            if (e.Index < m_Images.Count)
            {
                img = m_Images[e.Index] as Image;
            }

            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            SizeF szfStr = e.Graphics.MeasureString(str, base.Font);

            e.Graphics.DrawString(str, base.Font, new SolidBrush(base.ForeColor), new PointF(img == null ? 10 : img.Width + 2, e.Bounds.Y + (e.Bounds.Height - szfStr.Height) / 2));

            if (img != null)
            {
                e.Graphics.DrawImage(img, new Point(1, e.Bounds.Y + (e.Bounds.Height - img.Height) / 2));
            }
            this.HorizontalExtent = Text_CheckLargest() + 11;
        }

        int Text_CheckLargest()
        {
            List<int> width = new List<int>();
            for (int i = 0; i < this.Items.Count; i++)
            {
                Size sz = TextRenderer.MeasureText(this.Items[i].ToString(), base.Font);
                width.Add(sz.Width);
            }

            width.Sort();
            return width[width.Count - 1];
        }


        #region Properties

        public List<object> Images
        {
            get
            {
                return m_Images;
            }
            set
            {
                m_Images = value;
            }
        }

        #endregion
    }
}

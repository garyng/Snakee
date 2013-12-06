using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace PictureBoxArray
{
    class ClsPicBoxArray
    {
        List<List<PictureBox>> m_lstPicArray = new List<List<PictureBox>>();

        Control m_ctlCon = new Control();

        BorderStyle m_bsPic = BorderStyle.FixedSingle;
        Point m_pLoc = new Point(5, 5);
        Size m_szBox = new Size(10, 10);
        Size m_szPic = new Size(32, 32);
        /// <summary>
        /// Generate Picture Box Array
        /// </summary>
        /// <param name="PictureBoxArray">An 2D List Array To Store The PictureBox</param>
        public ClsPicBoxArray(ref List<List<PictureBox>> PictureBoxArray,Control Container)
        {
            m_ctlCon = Container;
        }

        public Size BoxSize
        {
            get
            {
                return m_szBox;   
            }
            set
            {
                m_szBox = value;
            }
        }

        public Size PicBoxSize
        {
            get
            {
                return m_szPic;
            }
            set
            {
                m_szPic = value;
            }
        }

        public BorderStyle PicBorderStyle
        {
            get
            {
                return m_bsPic;
            }
            set
            {
                m_bsPic = value;
            }
        }

        public Point StartingLoc
        {
            get
            {
                return m_pLoc;
            }
            set
            {
                m_pLoc = value;
            }
        }

        public void Pic_Generate()
        {
            for (int y = 0; y < m_szBox.Height; y++)
            {
                List<PictureBox> lstPY = new List<PictureBox>();
                for (int x = 0; x < m_szBox.Width; x++)
                {
                    PictureBox pX = new PictureBox();
                    pX.Size = m_szPic;
                    pX.BorderStyle = m_bsPic;

                    if (x == 0)
                    {
                        if (y == 0)
                        {
                            pX.Location = m_pLoc;
                        }
                        else
                        {
                            pX.Top = m_lstPicArray[y - 1][0].Bottom;
                            pX.Left = m_lstPicArray[y - 1][0].Left;
                        }
                    }
                    else
                    {
                        pX.Left = lstPY[x - 1].Right;
                        pX.Top = lstPY[x - 1].Top;
                    }
                    m_ctlCon.Controls.Add(pX);
                    lstPY.Add(pX);
                }
                m_lstPicArray.Add(lstPY);


            }
        }
    }
}

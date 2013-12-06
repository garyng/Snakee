using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Snakee;
using System.Drawing;
using FastBitmap;

namespace CustomPictureBox
{
    public class SnakeBox : PictureBox
    {
        bool bIsFood = false;
        //bool bIsSnakeBody = false; 
        bool bIsBody = false;
        bool bIsWall = false;

        bool bIsHead = false;
        bool bIsHeadEat = false;
        bool bIsFatBody = false;
        bool bIsTail = false;
        bool bIsTurning = false;
        bool bIsTurningFat = false;

        //Color m_cBody = Color.Black;
        //Color m_cHead = Color.Yellow;
        //Color m_cHeadEat = Color.Orange;
        //Color m_cFatBody = Color.LightGreen;
        //Color m_cTail = Color.Purple;
        //Color m_cTurning = Color.DarkOrange;
        //Color m_cTurningFat = Color.DarkRed;
        //Color m_cFood = Color.Blue;
        //Color m_cWall = Color.Red;

        SnakeDirection m_sdTailDir = new SnakeDirection();

        List<SnakeDirection> m_sdTurnFatDir = new List<SnakeDirection>();
        List<SnakeDirection> m_sdTurnDir = new List<SnakeDirection>();
        List<SnakeDirection> m_sdBodyDir = new List<SnakeDirection>();
        List<SnakeDirection> m_sdBodyFatDir = new List<SnakeDirection>();

        Skin m_sSkin = new Skin();

        public SnakeBox(Skin SSkin)
        {
            m_sSkin =SSkin;
        }

        public Point Coordinate { get; set; }   //For map editor

        /// <summary>
        /// Two snake direction in the list
        /// 1st: The last direction
        /// 2nd: The current direction
        /// </summary>
        public List<SnakeDirection> TurningDirection
        {
            get
            {
                return m_sdTurnDir;
            }
            set
            {
                m_sdTurnDir = value;
            }
        }

        public bool IsTurning
        {
            get
            {
                return bIsTurning;
            }
            set
            {
                if (value == true)
                {
                    this.Image = null;
                    this.BackColor = m_sSkin.Background;
                    this.Image = Turning_CalDirection(m_sdTurnDir, false);
                    //this.BackColor = m_cTurning;
                }
                else
                {
                    this.Image = null;
                    this.BackColor = m_sSkin.Background;
                }
                bIsTurning = value;
            }
        }

        /// <summary>
        /// Two snake direction in the list
        /// 1st: The last direction
        /// 2nd: The current direction
        /// </summary>
        public List<SnakeDirection> TurningFatDirection
        {
            get
            {
                return m_sdTurnFatDir;
            }
            set
            {
                m_sdTurnFatDir = value;
            }

        }

        Image Turning_CalDirection(List<SnakeDirection> ToCheck, bool bIsFat)
        {
            if ((ToCheck[0] == SnakeDirection.Up && ToCheck[1] == SnakeDirection.Right) || (ToCheck[0] == SnakeDirection.Left && ToCheck[1] == SnakeDirection.Down))
            {
                if (bIsFat == true)
                {
                    return m_sSkin.TurnFat_UR;
                }
                else
                {
                    return m_sSkin.Turn_UR;
                }
            }
            else if ((ToCheck[0] == SnakeDirection.Up && ToCheck[1] == SnakeDirection.Left) || (ToCheck[0] == SnakeDirection.Right && ToCheck[1] == SnakeDirection.Down))
            {
                if (bIsFat == true)
                {
                    return m_sSkin.TurnFat_UL;
                }
                else
                {
                    return m_sSkin.Turn_UL;
                }
            }
            else if ((ToCheck[0] == SnakeDirection.Down && ToCheck[1] == SnakeDirection.Right) || (ToCheck[0] == SnakeDirection.Left && ToCheck[1] == SnakeDirection.Up))
            {
                if (bIsFat == true)
                {
                    return m_sSkin.TurnFat_DR;
                }
                else
                {
                    return m_sSkin.Turn_DR;
                }
            }
            else if ((ToCheck[0] == SnakeDirection.Down && ToCheck[1] == SnakeDirection.Left) || (ToCheck[0] == SnakeDirection.Right && ToCheck[1] == SnakeDirection.Up))
            {
                if (bIsFat == true)
                {
                    return m_sSkin.TurnFat_DL;
                }
                else
                {
                    return m_sSkin.Turn_DL;
                }
            }
            return null;
        }

        /// <summary>
        /// Set the direction first!
        /// </summary>
        public bool IsTurningFat
        {
            get
            {
                return bIsTurningFat;
            }
            set
            {
                if (value == true)
                {
                    this.Image = null;
                    this.BackColor = m_sSkin.Background;
                    this.Image = Turning_CalDirection(m_sdTurnFatDir, true);
                    //this.BackColor = m_cTurningFat;
                }
                else
                {
                    this.Image = null;
                    this.BackColor = m_sSkin.Background;
                }
                bIsTurningFat = value;
            }
        }

        /// <summary>
        /// Set the tail direction first!
        /// </summary>
        public bool IsTail
        {
            get
            {
                return bIsTail;
            }
            set
            {
                if (value == true)
                {
                    this.Image = null;
                    this.BackColor = m_sSkin.Background;
                    this.Image = Tail_CalDirection();
                    //this.BackColor = m_cTail;
                }
                else
                {
                    this.Image = null;
                    this.BackColor = m_sSkin.Background;
                }
                bIsTail = value;

            }
        }

        Image Tail_CalDirection()
        {
            if (m_sdTailDir == SnakeDirection.Down)
            {
                return m_sSkin.Tail_D;
            }
            else if (m_sdTailDir == SnakeDirection.Up)
            {
                return m_sSkin.Tail_U;
            }
            else if (m_sdTailDir == SnakeDirection.Left)
            {
                return m_sSkin.Tail_L;
            }
            else if (m_sdTailDir == SnakeDirection.Right)
            {
                return m_sSkin.Tail_R;
            }
            return null;
        }

        public SnakeDirection TailDirection
        {

            get
            {
                return m_sdTailDir;
            }
            set
            {
                m_sdTailDir = value;
            }
        }

        public bool IsEatHead
        {
            get
            {
                return bIsHeadEat;
            }
            set
            {
                if (value == true)
                {
                    this.Image = null;
                    this.BackColor = m_sSkin.Background;
                    this.Image = Head_Direction(1);
                    //this.BackColor = m_cHeadEat;
                }
                else
                {
                    this.Image = null;
                    this.BackColor = m_sSkin.Background;
                }
                bIsHeadEat = value;

            }
        }

        public bool IsHead
        {
            get
            {
                return bIsHead;
            }
            set
            {
                if (value == true)
                {
                    this.Image = null;
                    this.BackColor = m_sSkin.Background;
                    this.Image = Head_Direction(0);
                    //this.BackColor = m_cHead;
                }
                else
                {
                    this.Image = null;
                    this.BackColor = m_sSkin.Background;
                }
                bIsHead = value;
            }
        }

        /// <summary>
        /// Return the image to draw according to the direction
        /// </summary>
        /// <param name="Index"><para>0 = head<para><para>1 = eat head</para></param>
        /// <returns></returns>
        Image Head_Direction(int Index)
        {
            if (frmMain.m_sdCurrent == SnakeDirection.Down)
            {
                if (Index == 0)
                {
                    return m_sSkin.Head_D;

                }
                else
                {
                    return m_sSkin.HeadEat_D;
                }
            }
            else if (frmMain.m_sdCurrent == SnakeDirection.Up)
            {
                if (Index == 0)
                {
                    return m_sSkin.Head_U;

                }
                else
                {
                    return m_sSkin.HeadEat_U;
                }

            }
            else if (frmMain.m_sdCurrent == SnakeDirection.Left)
            {
                if (Index == 0)
                {
                    return m_sSkin.Head_L;
                }
                else
                {
                    return m_sSkin.HeadEat_L;
                }
            }
            else
            {
                if (Index == 0)
                {
                    return m_sSkin.Head_R;
                }
                else
                {
                    return m_sSkin.HeadEat_R;
                }
            }
        }

        public bool IsFood
        {
            get
            {
                return bIsFood;
            }
            set
            {
                if (value == true)
                {
                    //this.Image = frmMain.m_sSkin.Food;
                    this.Image = null;
                    this.BackColor = m_sSkin.Background;
                    this.Image = m_sSkin.Food;
                }
                else
                {
                    this.Image = null;
                    this.BackColor = m_sSkin.Background;
                }
                bIsFood = value;
            }

        }

        /// <summary>
        /// Three snake direction in a list
        /// 1st: Last direction
        /// 2nd: Current direction
        /// 3nd: Last turned direction
        /// </summary>
        public List<SnakeDirection> BodyDirection
        {
            get
            {
                return m_sdBodyDir;
            }
            set
            {
                m_sdBodyDir = value;
            }
        }

        /// <summary>
        /// Three snake direction in a list
        /// 1st: Last direction
        /// 2nd: Current direction
        /// 3nd: Last turned direction
        /// </summary>
        public List<SnakeDirection> BodyFatDirection
        {
            get
            {
                return m_sdBodyFatDir;
            }
            set
            {
                m_sdBodyFatDir = value;
            }
        }

        Image Body_CalDirection(List<SnakeDirection> ToCheck, bool bIsEat)
        {

            if (ToCheck[0] == SnakeDirection.Right)
            {
                if (ToCheck[1] == SnakeDirection.Up)
                {
                    if (bIsEat == true)
                    {
                        return m_sSkin.BodyFat_UL;
                    }
                    else
                    {
                        return m_sSkin.Body_UL;
                    }
                }
                else if (ToCheck[1] == SnakeDirection.Down)
                {
                    if (bIsEat == true)
                    {
                        return m_sSkin.BodyFat_UL;
                    }
                    else
                    {
                        return m_sSkin.Body_UL;
                    }
                }
                else if (ToCheck[1] == SnakeDirection.Right)
                {
                    if (bIsEat == true)
                    {
                        return m_sSkin.BodyFat_DR;
                    }
                    else
                    {
                        return m_sSkin.Body_DR;
                    }
                }
                else
                {
                    return null;
                }
            }
            else if (ToCheck[0] == SnakeDirection.Left)
            {
                if (ToCheck[1] == SnakeDirection.Up)
                {
                    if (bIsEat == true)
                    {
                        return m_sSkin.BodyFat_UL;
                    }
                    else
                    {
                        return m_sSkin.Body_UL;
                    }
                }
                else if (ToCheck[1] == SnakeDirection.Down)
                {
                    if (bIsEat == true)
                    {
                        return m_sSkin.BodyFat_UL;
                    }
                    else
                    {
                        return m_sSkin.Body_UL;
                    }
                }
                else if (ToCheck[1] == SnakeDirection.Left)
                {
                    if (bIsEat == true)
                    {
                        return m_sSkin.BodyFat_DL;
                    }
                    else
                    {
                        return m_sSkin.Body_DL;
                    }
                }
                else
                {
                    return null;
                }
            }
            else if (ToCheck[0] == SnakeDirection.Down)
            {
                if (ToCheck[1] == SnakeDirection.Left)
                {
                    if (bIsEat == true)
                    {
                        return m_sSkin.BodyFat_DL;
                    }
                    else
                    {
                        return m_sSkin.Body_DL;
                    }
                }
                else if (ToCheck[1] == SnakeDirection.Right)
                {
                    if (bIsEat == true)
                    {
                        return m_sSkin.BodyFat_DR;
                    }
                    else
                    {
                        return m_sSkin.Body_DR;
                    }
                }
                else if (ToCheck[1] == SnakeDirection.Down)
                {
                    if (bIsEat == true)
                    {
                        return m_sSkin.BodyFat_UL;
                    }
                    else
                    {
                        return m_sSkin.Body_UL;
                    }
                }
                else
                {
                    return null;
                }
            }
            else if (ToCheck[0] == SnakeDirection.Up)
            {
                if (ToCheck[1] == SnakeDirection.Left)
                {
                    if (bIsEat == true)
                    {
                        return m_sSkin.BodyFat_DL;
                    }
                    else
                    {
                        return m_sSkin.Body_DL;
                    }
                }
                else if (ToCheck[1] == SnakeDirection.Right)
                {
                    if (bIsEat == true)
                    {
                        return m_sSkin.BodyFat_DR;
                    }
                    else
                    {
                        return m_sSkin.Body_DR;
                    }
                }
                else if (ToCheck[1] == SnakeDirection.Up)
                {
                    if (bIsEat == true)
                    {
                        return m_sSkin.BodyFat_UL;
                    }
                    else
                    {
                        return m_sSkin.Body_UL;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }


        }

        public bool IsBody
        {
            get
            {
                return bIsBody;
            }
            set
            {
                if (value == true)
                {
                    this.Image = null;
                    this.BackColor = m_sSkin.Background;
                    this.Image = Body_CalDirection(m_sdBodyDir, false);
                    //this.BackColor = m_cBody;
                }
                else
                {
                    this.Image = null;
                    this.BackColor = m_sSkin.Background;
                }
                bIsBody = value;
            }
        }

        public bool IsFatBody
        {
            get
            {
                return bIsFatBody;
            }
            set
            {
                if (value == true)
                {
                    this.Image = null;
                    this.BackColor = m_sSkin.Background;
                    this.Image = Body_CalDirection(m_sdBodyFatDir, true);

                    //this.BackColor = m_cFatBody;
                }
                else
                {
                    this.Image = null;
                    this.BackColor = m_sSkin.Background;
                }
                bIsFatBody = value;
            }
        }

        public bool IsWall
        {

            get
            {
                return bIsWall;
            }
            set
            {
                if (value == true)
                {
                    this.Image = m_sSkin.Wall;
                    //this.BackColor = m_cWall;
                }
                else
                {
                    this.Image = null;
                    this.BackColor = m_sSkin.Background;
                }
                bIsWall = value;
            }
        }


        protected override void WndProc(ref Message m)
        {
            //msg=0xa1 (WM_NCLBUTTONDOWN) hwnd=0x912832 wparam=0x12 lparam=0xa901e1 result=0x0
            //msg=0xa2 (WM_NCLBUTTONUP) hwnd=0x912832 wparam=0x12 lparam=0xa901e1 result=0x0
            //msg=0xa4 (WM_NCRBUTTONDOWN) hwnd=0x961822 wparam=0x12 lparam=0x9200f8 result=0x0
            //msg=0xa5 (WM_NCRBUTTONUP) hwnd=0x961822 wparam=0x12 lparam=0x9200f8 result=0x0

            if (m.Msg == 0xa1)
            {
                base.OnMouseDown(new MouseEventArgs(MouseButtons.Left, 1, Cursor.Position.X, Cursor.Position.Y, 0));
            }
            else if (m.Msg == 0xa2)
            {
                base.OnMouseUp(new MouseEventArgs(MouseButtons.Left, 1, Cursor.Position.X, Cursor.Position.Y, 0));
            }
            else if (m.Msg == 0xa4)
            {
                base.OnMouseDown(new MouseEventArgs(MouseButtons.Right, 1, Cursor.Position.X, Cursor.Position.Y, 0));
            }
            else if (m.Msg == 0xa5)
            {
                base.OnMouseUp(new MouseEventArgs(MouseButtons.Right, 1, Cursor.Position.X, Cursor.Position.Y, 0));
            }

            //Console.WriteLine(m.ToString());
            base.WndProc(ref m);
        }
    }

    public class ZoomBox : PictureBox
    {
        Image m_imgImage = null;
        int m_iZoom = 1;


        public ZoomBox(Image image, int zoom)
        {
            m_imgImage = image;
            Zoom = zoom;
            Image_Draw();
        }

        public int Zoom
        {
            get
            {
                return m_iZoom;
            }
            set
            {
                if (value > 0)
                {
                    m_iZoom = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public Image ZoomImage
        {
            get
            {
                return m_imgImage;
            }
            set
            {
                m_imgImage = value;
                Image_Draw();
            }
        }
        void Image_Draw()
        {
            Bitmap bSource = new Bitmap(m_imgImage);
            FasterBitmap fbSource = new FasterBitmap(bSource);
            fbSource.LockBits();

            Bitmap bPic = new Bitmap(bSource.Width * m_iZoom, bSource.Height * m_iZoom);
            Graphics gPic = Graphics.FromImage(bPic);

            for (int y = 0; y < fbSource.Height; y++)
            {
                for (int x = 0; x < fbSource.Width; x++)
                {

                    gPic.FillRectangle(new SolidBrush(fbSource.GetPixel(x, y)), new Rectangle(new Point(x * m_iZoom, y * m_iZoom), new Size(m_iZoom, m_iZoom)));
                }
            }
            fbSource.UnlockBits();
            this.Size = bPic.Size;
            this.Image = bPic;
        }

    }

}

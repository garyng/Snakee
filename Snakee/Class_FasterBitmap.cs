using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace FastBitmap
{
    class FasterBitmap
    {
        Bitmap m_bSource = null;
        IntPtr m_ipBit = IntPtr.Zero;
        BitmapData m_bdData = null;

        public byte[] Pixels { get; set; }
        public int Depth { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        int Step { get; set; }

        public FasterBitmap(Bitmap Source)
        {
            m_bSource = Source;
        }
        /// <summary>
        /// Lock bitmap data
        /// </summary>
        public void LockBits()
        {
            try
            {
                Width = m_bSource.Width;
                Height = m_bSource.Height;

                int iPixelTotal = Width * Height;

                Rectangle rectLock = new Rectangle(0, 0, Width, Height);
                Depth = Bitmap.GetPixelFormatSize(m_bSource.PixelFormat); //Get bpp (Bits per pixel)

                if (Depth != 8 && Depth != 24 && Depth != 32)
                {
                    throw new ArgumentException("Only bpp=8,24,32");
                }

                m_bdData = m_bSource.LockBits(rectLock, ImageLockMode.ReadWrite, m_bSource.PixelFormat);

                Step = Depth / 8;
                Pixels = new byte[iPixelTotal * Step];
                m_ipBit = m_bdData.Scan0;

                Marshal.Copy(m_ipBit, Pixels, 0, Pixels.Length);


            }
            catch (Exception ex)
            {
                throw ex;

            }


        }

        public void UnlockBits()
        {
            try
            {
                Marshal.Copy(Pixels, 0, m_ipBit, Pixels.Length);
                m_bSource.UnlockBits(m_bdData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Color GetPixel(int x, int y)
        {
            Color clr = Color.Empty;
            int i = ((y * Width) + x) * Step;
            if (i > Pixels.Length - Step)
            {
                throw new IndexOutOfRangeException();
            }

            if (Depth == 32) //RGBA
            {
                clr = Color.FromArgb(Pixels[i + 3], Pixels[i + 2], Pixels[i + 1], Pixels[i]);
            }
            if (Depth == 24) //RGB
            {
                clr = Color.FromArgb(Pixels[i + 2], Pixels[i + 1], Pixels[i]);
            }
            if (Depth == 8) //R=G=B
            {
                clr = Color.FromArgb(Pixels[i], Pixels[i], Pixels[i]);
            }
            return clr;
        }

        public void SetPixel(int x, int y, Color color)
        {
            int i = ((y * Width) + x) * Step;
            if (Depth == 32)
            {
                Pixels[i] = color.B;
                Pixels[i + 1] = color.G;
                Pixels[i + 2] = color.R;
                Pixels[i + 3] = color.A;
            }
            if (Depth == 24)
            {
                Pixels[i] = color.B;
                Pixels[i + 1] = color.G;
                Pixels[i + 2] = color.R;
            }
            if (Depth == 8)
            {
                Pixels[i] = color.B;
            }
        }

    }
}

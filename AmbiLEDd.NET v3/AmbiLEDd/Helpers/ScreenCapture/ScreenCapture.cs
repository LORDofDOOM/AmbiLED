using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms; // for Screen

namespace AmbiLEDd
{
	/// <summary>
	/// Provides functions to capture the entire screen, or a particular window, and save it to a file.
	/// </summary>
    public class ScreenCapture
	{

        /// <summary>
        /// Creates an Image object containing a screen shot of the entire desktop
        /// </summary>
        /// <returns></returns>
        public Bitmap GDICaptureScreen(int screen, int nWidth, int nHeight) 
        {
            Screen MyScreen = Screen.AllScreens[screen];

            int width = MyScreen.Bounds.Width;
            int height = MyScreen.Bounds.Height;

            if (width != 0 || height != 0)
            {

                IntPtr hBitmap;
                IntPtr hDC = User32.GetWindowDC(User32.GetDesktopWindow());
                IntPtr hMemDC = GDI32.CreateCompatibleDC(hDC);

                //int cx = User32.GetSystemMetrics(User32.SM_CXSCREEN);
                //int cy = User32.GetSystemMetrics(User32.SM_CYSCREEN);

                // original size
                //hBitmap = GDI32.CreateCompatibleBitmap(hDC, MyScreen.Bounds.Width, MyScreen.Bounds.Height);

                // after resize
                hBitmap = GDI32.CreateCompatibleBitmap(hDC, nWidth, nHeight);

                if (hBitmap != IntPtr.Zero)
                {
                    IntPtr hOld = (IntPtr)GDI32.SelectObject(hMemDC, hBitmap);

                    // set stretch mode
                    Win32.SetStretchBltMode(hMemDC, (int)Win32.StretchMode.HALFTONE);

                    /* // OLD BitBlt
                    GDI32.BitBlt    (hMemDC, 0,    0,    MyScreen.Bounds.Width, MyScreen.Bounds.Height, hDC,      MyScreen.Bounds.Left, MyScreen.Bounds.Top, GDI32.SRCCOPY);
                    //*/
                    // helpers -->
                    //BitBlt        (hdcDst, xDst, yDst, cx,                    cy,                     hdcSrc,   xSrc,                 ySrc,                ulRop);
                    //StretchBlt    (hdcDst, xDst, yDst, cx,                    cy,                     hdcSrc,   xSrc,                 ySrc,                cxSrc,  cySrc,  ulRop);
                    //StretchBlt    (dcDest, 0,    0,    bmpDest.Width,         bmpDest.Height,         dcSource, 0,                    0,                   bmpSource.Width, bmpSource.Height, 0xCC0020);
                    // <-- helpers
                    //*
                    Win32.StretchBlt(hMemDC, 0,    0,    nWidth,                nHeight,                hDC,      MyScreen.Bounds.Left, MyScreen.Bounds.Top, MyScreen.Bounds.Width, MyScreen.Bounds.Height, GDI32.SRCCOPY);
                    //*/


                    GDI32.SelectObject(hMemDC, hOld);
                    GDI32.DeleteDC(hMemDC);
                    User32.ReleaseDC(User32.GetDesktopWindow(), hDC);
                    Bitmap bitmap = System.Drawing.Image.FromHbitmap(hBitmap);
                    GDI32.DeleteObject(hBitmap);
                    GC.Collect();

                    return bitmap;
                }
                else return null;
            }
            else return null;
        }

        /// <summary>
        /// Creates an Image object containing a screen shot of a specific window
        /// </summary>
        /// <param name="handle">The handle to the window. (In windows forms, this is obtained by the Handle property)</param>
        /// <returns></returns>
        public Bitmap GDICaptureWindow(IntPtr handle)
        {
            // get te hDC of the target window
            IntPtr hdcSrc = User32.GetWindowDC(handle);
            // get the size
            User32.RECT windowRect = new User32.RECT();
            User32.GetWindowRect(handle,ref windowRect);
            int width = windowRect.right - windowRect.left;
            int height = windowRect.bottom - windowRect.top;

            if (width != 0 || height != 0)
            {
                // create a device context we can copy to
                IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
                // create a bitmap we can copy it to,
                // using GetDeviceCaps to get the width/height
                IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);
                // select the bitmap object
                IntPtr hOld = GDI32.SelectObject(hdcDest, hBitmap);
                // bitblt over
                GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, GDI32.SRCCOPY);
                // restore selection
                GDI32.SelectObject(hdcDest, hOld);
                // clean up 
                GDI32.DeleteDC(hdcDest);
                User32.ReleaseDC(handle, hdcSrc);

                // get a .NET image object for it
                Bitmap bitmap = Image.FromHbitmap(hBitmap);
                // free up the Bitmap object
                GDI32.DeleteObject(hBitmap);

                return bitmap;
            }
            else return null;
        }

        /// <summary>
        /// Creates an Image object containing a screen shot of the entire desktop
        /// </summary>
        /// <returns></returns>
        public Bitmap NETCaptureScreen(int screen)
        {
            Screen MyScreen = Screen.AllScreens[screen];

            int width = MyScreen.Bounds.Width;
            int height = MyScreen.Bounds.Height;

            if (width != 0 || height != 0)
            {
                Graphics g;
                Bitmap bitmap = new Bitmap(width, height);
                g = Graphics.FromImage(bitmap);
                g.CopyFromScreen(MyScreen.Bounds.Left, MyScreen.Bounds.Top, 0, 0, new Size(width, height));
                g.Dispose();

                return bitmap;
            }
            else return null;
        }

        /// <summary>
        /// Creates an Image object containing a screen shot of a specific window
        /// </summary>
        /// <param name="handle">The handle to the window. (In windows forms, this is obtained by the Handle property)</param>
        /// <returns></returns>
        public Bitmap NETCaptureWindow(IntPtr handle)
        {
            // get te hDC of the target window
            IntPtr hdcSrc = User32.GetWindowDC(handle);
            // get the size
            User32.RECT windowRect = new User32.RECT();
            User32.GetWindowRect(handle, ref windowRect);
            int width = windowRect.right - windowRect.left;
            int height = windowRect.bottom - windowRect.top;

            if (width != 0 || height != 0)
            {
                Graphics g;
                Bitmap bitmap = new Bitmap(width, height);
                g = Graphics.FromImage(bitmap);
                g.CopyFromScreen(windowRect.left, windowRect.top, 0, 0, new Size(width, height));
                g.Dispose();

                return bitmap;
            }
            else return null;
        }

        /// <summary>
        /// Helper class containing Gdi32 API functions
        /// </summary>
        private class GDI32
        {
            
            public const int SRCCOPY = 0x00CC0020; // BitBlt dwRop parameter

            [DllImport("gdi32.dll")]
            public static extern bool BitBlt(IntPtr hObject,int nXDest,int nYDest,
                int nWidth,int nHeight,IntPtr hObjectSource,
                int nXSrc,int nYSrc,int dwRop);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC,int nWidth, 
                int nHeight);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr hObject);
            [DllImport("gdi32.dll")]
            public static extern IntPtr SelectObject(IntPtr hDC,IntPtr hObject);
        }
 
        /// <summary>
        /// Helper class containing User32 API functions
        /// </summary>
        private class User32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }

            [DllImport("user32.dll")]
            public static extern IntPtr GetDesktopWindow();
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowDC(IntPtr hWnd);
            [DllImport("user32.dll")]
            public static extern IntPtr ReleaseDC(IntPtr hWnd,IntPtr hDC);
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd,ref RECT rect);

        }


	}
}

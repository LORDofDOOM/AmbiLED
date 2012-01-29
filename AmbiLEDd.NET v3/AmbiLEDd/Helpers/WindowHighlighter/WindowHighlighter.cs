using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace AmbiLEDd
{
	/// <summary>
	/// Summary description for WindowHighlighter.
	/// </summary>
	public class WindowHighlighter
	{				
		/// <summary>
		/// Highlights the specified window just like Spy++
		/// </summary>
		/// <param name="hWnd"></param>
		public static void Highlight(IntPtr hWnd)
		{
			const float penWidth = 3;
			Win32.Rect rc = new Win32.Rect();
			Win32.GetWindowRect(hWnd, ref rc);

			IntPtr hDC = Win32.GetWindowDC(hWnd);
			if (hDC != IntPtr.Zero)
			{
				using (Pen pen = new Pen(Color.Black, penWidth))
				{
					using (Graphics g = Graphics.FromHdc(hDC))
					{
						g.DrawRectangle(pen, 0, 0, rc.right - rc.left - (int)penWidth, rc.bottom - rc.top - (int)penWidth);
					}
				}
			}
			Win32.ReleaseDC(hWnd, hDC);
		}

		/// <summary>
		/// Forces a window to refresh, to eliminate our funky highlighted border
		/// </summary>
		/// <param name="hWnd"></param>
		public static void Refresh(IntPtr hWnd)
		{
			Win32.InvalidateRect(hWnd, IntPtr.Zero, 1 /* TRUE */);
			Win32.UpdateWindow(hWnd);
			Win32.RedrawWindow(hWnd, IntPtr.Zero, IntPtr.Zero, Win32.RDW_FRAME | Win32.RDW_INVALIDATE | Win32.RDW_UPDATENOW | Win32.RDW_ALLCHILDREN);		
		}
	}
}

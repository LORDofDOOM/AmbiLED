using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

namespace AmbiLEDd
{
	/// <summary>
	/// Summary description for FinderToolUtils.
	/// </summary>
	public class EmbeddedResources
	{
		public const string FinderHome = "AmbiLEDd.FinderHome.bmp";
        public const string FinderGone = "AmbiLEDd.FinderGone.bmp";
        public const string Finder = "AmbiLEDd.Finder.cur";

		/// <summary>
		/// Loads an image from an embbedded resource
		/// </summary>
		/// <param name="resourceName"></param>
		/// <returns></returns>
		public static Image LoadImage(string resourceName)
		{
			try
			{
				using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
				{
					return Image.FromStream(stream);
				}
			}
			catch(Exception ex)
			{
				Debug.WriteLine(ex);
			}
			return null;
		}

		/// <summary>
		/// Loads a cursor from an embedded resource
		/// </summary>
		/// <param name="resourceName"></param>
		/// <returns></returns>
		public static Cursor LoadCursor(string resourceName)
		{
			try
			{
				using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
				{
					return new Cursor(stream);
				}
			}
			catch(Exception ex)
			{
				Debug.WriteLine(ex);
			}
			return null;
		}
	}
}

using EBToolkit.Gui;
using System;
using System.Windows.Forms;

namespace EBToolkit
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ja"); // DEBUG - JAPANESE
            Application.Run(new FormSaveEditor());
			//Application.Run(new FormMain());
		}
	}
}

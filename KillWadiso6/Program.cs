using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KillWadiso6
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			SharedClasses.AutoUpdating.CheckForUpdates_ExceptionHandler();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new Form1());
			MainForm f1 = new MainForm();
			f1.ShowDialog();
		}
	}
}
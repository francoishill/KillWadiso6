using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using SharedClasses;

namespace KillWadiso6
{
	public partial class MainForm : Form
	{
		private const string cDefaultProcessName = "Wadiso6";
		private readonly string cPathToProcessName = SettingsInterop.GetFullFilePathInLocalAppdata("ProcessName.fjset", "KillWadiso6");
		double origOpacity;

		public MainForm()
		{
			InitializeComponent();
			origOpacity = this.Opacity;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			int bot = Screen.PrimaryScreen.WorkingArea.Bottom;
			int right = Screen.PrimaryScreen.WorkingArea.Right;
			this.Location = new Point(right - this.Width, bot - this.Height);
		}

		private string processNameToKill
		{
			get
			{
				if (!File.Exists(cPathToProcessName))
					return cDefaultProcessName;

				string fileContents = File.ReadAllText(cPathToProcessName);
				if (string.IsNullOrWhiteSpace(fileContents))
					return cDefaultProcessName;
				else
					return fileContents;
			}
			set
			{
				try { File.WriteAllText(cPathToProcessName, value); }
				catch (Exception exc) { UserMessages.ShowErrorMessage("Unable to set process name to '" + value + "': " + exc.Message); }
			}
		}

		protected override bool ShowWithoutActivation
		{
			get { return true; }
		}

		const UInt32 WS_EX_NOACTIVATE = 0x08000000;
		const UInt32 WS_EX_TOOLWINDOW = 0x0080;
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams baseParams = base.CreateParams;

				baseParams.ExStyle |= (int)(
				  WS_EX_NOACTIVATE |
				  WS_EX_TOOLWINDOW);

				return baseParams;
			}
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			if (!Win32Api.RegisterHotKey(this.Handle, Win32Api.Hotkey1, Win32Api.MOD_WIN, (int)Keys.W))
				UserMessages.ShowWarningMessage("KillWadiso6 could not register hotkey WinKey + W");
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == Win32Api.WM_HOTKEY)
			{
				if (m.WParam == new IntPtr(Win32Api.Hotkey1))
					KillWadiso6Now();
			}
			base.WndProc(ref m);
		}

		private void KillWadiso6Now()
		{
			Process[] processes = Process.GetProcesses();
			for (int i = 0; i < processes.Length; i++)
			{
				try
				{
					if (processes[i].ProcessName.Equals(processNameToKill, StringComparison.InvariantCultureIgnoreCase))
						processes[i].Kill();
				}
				catch { }
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			this.BringToFront();
			//this.TopMost = false;
			//this.TopMost = true;
		}

		private void button1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
				KillWadiso6Now();
			else if (e.Button == System.Windows.Forms.MouseButtons.Right)
				contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Left);
		}

		private void button1_MouseUp(object sender, MouseEventArgs e)
		{
			//if (e.Button == System.Windows.Forms.MouseButtons.Right)
			//    this.Close();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void makeAWindowflashToolStripMenuItem_Click(object sender, EventArgs e)
		{
			List<string> windowTitlesAndHandles = new List<string>();
			Win32Api.EnumWindows(
				(hwnd, param) =>
				{
					IntPtr handle = new IntPtr(hwnd);
					if (Win32Api.GetWindowTextLength(handle) > 0)
					{
						var wintext = Win32Api.GetWindowText(handle);
						if (!string.IsNullOrWhiteSpace(wintext))
							windowTitlesAndHandles.Add(wintext + "," + handle);
					}
					return true;
				},
				0);

			windowTitlesAndHandles.Sort();
			MakeWindowFlash flashform = new MakeWindowFlash(windowTitlesAndHandles);
			flashform.ShowDialog(this);
			flashform.Dispose();
		}

		private static string[] GetLatestWadisoDllpaths()
		{
			string basedir = @"C:\devKiln\build_albion\tundra-output";
			var Wadiso6dllFiles = Directory.GetDirectories(basedir)
				.Select(d => Path.Combine(d, "Wadiso6.dll"))
				.Where(f => File.Exists(f))
				.ToArray();
			//var Wadiso6dllFiles = Directory.GetFiles(basedir, "Wadiso6.dll", SearchOption.AllDirectories);
			var newestDllPaths = Wadiso6dllFiles.Where(f1 => new FileInfo(f1).LastWriteTime.Ticks == Wadiso6dllFiles.Max(f => new FileInfo(f).LastWriteTime.Ticks)).ToArray();
			return newestDllPaths;
		}

		private void gotoLastBuildtWadiso6dllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var newestDllPaths = GetLatestWadisoDllpaths();
			if (newestDllPaths.Length > 1)
			{
				UserMessages.ShowWarningMessage("Found multiple newest Dll paths");//Should never happen
				return;
			}
			else
			{
				Process.Start("explorer", "/select,\"" + newestDllPaths[0] + "\"");
			}
		}

		private void deleteAlbionCACHEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string dir1 = @"C:\Users\francois\AppData\Local\GLS\Albion";
			string dir2 = @"C:\Users\francois\AppData\Local\GLS\adb";

			if (!Directory.Exists(dir1) && !Directory.Exists(dir2))
			{
				UserMessages.ShowInfoMessage("Cannot delete cache, directories not found:"
					+ Environment.NewLine + Environment.NewLine
					+ string.Join(Environment.NewLine, dir1, dir2));
				return;
			}

			string userConfirmMessage = "Are you sure you want to clear Albion CACHE by deleting the following ";
			if (Directory.Exists(dir1) && Directory.Exists(dir2))
				userConfirmMessage += "directories?"
					+ Environment.NewLine + Environment.NewLine
					+ string.Join(Environment.NewLine, dir1, dir2);
			else if (Directory.Exists(dir1))
				userConfirmMessage += "directory (other directory not found '" + dir2 + "')?"
					+ Environment.NewLine + Environment.NewLine
					+ dir1;
			else// if (Directory.Exists(dir2))
				userConfirmMessage += "directory (other directory not found '" + dir1 + "')?"
					+ Environment.NewLine + Environment.NewLine
					+ dir2;

			if (UserMessages.Confirm(userConfirmMessage, "Clear Albion Cache", false, true))
			{
				string[] dirs = new string[] { dir1, dir2 };
				Dictionary<string, string> errors = new Dictionary<string, string>();//dir, error
				foreach (var d in dirs)
				{
					try
					{
						Directory.Delete(d, true);
					}
					catch (Exception exc)
					{
						errors.Add(d, "Error deleting dir '" + d + "': " + exc.Message);
					}
				}
				if (errors.Count > 0)
				{
					if (errors.Count == dirs.Length)//All directories failed
						UserMessages.ShowWarningMessage("Unable to clear Albion Cache, could not delete directories:"
							+ Environment.NewLine + Environment.NewLine
							+ string.Join(Environment.NewLine, errors.Values));
					else
						UserMessages.ShowWarningMessage("Unable to COMPLETELY clear Albion Cache, could not delete directories:"
							+ Environment.NewLine + Environment.NewLine
							+ string.Join(Environment.NewLine, errors.Values));

					/*foreach (var errorDir in errors.Keys)
						Process.Start("explorer", "/select,\"" + errorDir + "\"");*/
					List<string> parentDirsOfErrors =
						errors.Keys.Select(
						dirwitherror => Path.GetDirectoryName(dirwitherror))//get parent dir of dir with error
						.Distinct()
						.ToList();

					foreach (var parentDir in parentDirsOfErrors)
						Process.Start("explorer", parentDir);
				}
			}
		}

		private void button1_MouseEnter(object sender, EventArgs e)
		{
			this.Opacity = 1;
		}

		private void button1_MouseLeave(object sender, EventArgs e)
		{
			this.Opacity = origOpacity;
		}


		private void ChangeProcessNameTokill()
		{
			string processName = DialogBoxStuff.InputDialog("Please enter the processname to be killed", "Process name to kill");
			if (string.IsNullOrWhiteSpace(processName))
				return;
			processNameToKill = processName;
		}

		private void changeProcessNameToKillToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChangeProcessNameTokill();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutWindow2.ShowAboutWindow(new System.Collections.ObjectModel.ObservableCollection<DisplayItem>()
			{
				new DisplayItem("Author", "Francois Hill"),
				new DisplayItem("Icon(s) obtained from", null)
			});
		}
	}
}

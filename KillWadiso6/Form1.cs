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

namespace KillWadiso6
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			int bot = Screen.PrimaryScreen.WorkingArea.Bottom;
			int right = Screen.PrimaryScreen.WorkingArea.Right;
			this.Location = new Point(right - this.Width, bot - this.Height);
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
					if (processes[i].ProcessName.Equals("Wadiso6", StringComparison.InvariantCultureIgnoreCase))
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
	}
}

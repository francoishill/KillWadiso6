using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using SharedClasses;

namespace KillWadiso6
{
	public partial class MakeWindowFlash : Form
	{
		List<TreeNode> allNodes = new List<TreeNode>();

		public MakeWindowFlash(List<string> windowTitlesAndHandles)
		{
			InitializeComponent();

			foreach (string titleAndHandle in windowTitlesAndHandles)
			{
				var node = new TreeNode(titleAndHandle);
				//node.ContextMenuStrip = co
				allNodes.Add(node);
				treeViewWindowTitlesAndHandles.Nodes.Add(node);
			}

			labelCurrentFlashSpeedDisplay.Text = trackBarFlashSpeed.Value.ToString();
		}

		private IntPtr? GetWindowHandleFromSelectedItem(bool showErrorIfNotSelected = true)
		{
			if (treeViewWindowTitlesAndHandles.SelectedNode == null)
			{
				if (showErrorIfNotSelected)
					UserMessages.ShowWarningMessage("Please select an item first.");
				return null;
			}

			int tmphandle;
			var wintitleAndHandle = treeViewWindowTitlesAndHandles.SelectedNode.Text;
			if (!int.TryParse(wintitleAndHandle.Split(',')[wintitleAndHandle.Split(',').Length - 1], out tmphandle))
			{
				UserMessages.ShowErrorMessage("Cannot get window handle (after last comma) from: " + wintitleAndHandle);
				return null;
			}
			else
				return new IntPtr(tmphandle);
		}

		private void buttonMakeFlash_Click(object sender, EventArgs e)
		{
			IntPtr? handle = GetWindowHandleFromSelectedItem();
			if (!handle.HasValue) return;

			Win32Api.FLASHWINFO fInfo = new Win32Api.FLASHWINFO();

			fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
			fInfo.hwnd = handle.Value;
			fInfo.dwFlags = (int)Win32Api.FLASHWINFOFLAGS.FLASHW_ALL;
			fInfo.uCount = (uint)numericUpDownFlashCount.Value;//UInt32.MaxValue;
			fInfo.dwTimeout = (uint)trackBarFlashSpeed.Value;//200;

			Win32Api.FlashWindowEx(ref fInfo);
		}

		private void buttonKillProcess_Click(object sender, EventArgs e)
		{
			IntPtr? handle = GetWindowHandleFromSelectedItem();
			if (!handle.HasValue) return;

			uint processID;
			uint threadID = Win32Api.GetWindowThreadProcessId(handle.Value, out processID);
			Process procToKill = Process.GetProcessById((int)processID);
			if (procToKill != null)
				if (UserMessages.Confirm("Are you sure you want to kill \"" + procToKill.ProcessName + "\""))
					procToKill.Kill();
		}

		private void textBoxFilter_TextChanged(object sender, EventArgs e)
		{
			treeViewWindowTitlesAndHandles.Nodes.Clear();
			foreach (TreeNode node in allNodes)
				if (node.Text.IndexOf(textBoxFilter.Text, StringComparison.InvariantCultureIgnoreCase) != -1)
					treeViewWindowTitlesAndHandles.Nodes.Add(node);
		}

		private readonly Color voidColor = Color.FromArgb(0, 0, 0, 0);
		private void treeViewWindowTitlesAndHandles_AfterSelect(object sender, TreeViewEventArgs e)
		{
			pictureBoxPreview.Image = null;

			IntPtr? handle = GetWindowHandleFromSelectedItem(false);
			if (!handle.HasValue) return;

			Win32Api.WINDOWINFO wininfo = new Win32Api.WINDOWINFO();
			Win32Api.GetWindowInfo(handle.Value, ref wininfo);

			Win32Api.RECT rectToUse = wininfo.rcWindow;//.rcClient;
			Rectangle rect = new Rectangle(
				rectToUse.Left, rectToUse.Top,
				rectToUse.Width, rectToUse.Height);

			if (rect.Width == 0 || rect.Height == 0)
				return;

			Bitmap bmp = new Bitmap((int)rect.Width, (int)rect.Height);
			//if (rect.X == 50)
			//{
			//    uint procID;
			//    Win32Api.GetWindowThreadProcessId(handle.Value, out procID);
			//}
			Graphics memoryGraphics = Graphics.FromImage(bmp);
			IntPtr dc = memoryGraphics.GetHdc();

			bool success = false;
			int maxWaitMilliseconds = 500;//2000;
			if (!ThreadingInterop.ActionWithTimeout(delegate
			{
				success = Win32Api.PrintWindow(handle.Value, dc, 0);
			},
			maxWaitMilliseconds,
			(err) => UserMessages.ShowErrorMessage("Cannot get bitmap from window: " + err)))
			{
				UserMessages.ShowWarningMessage("No response to call Win32Api.PrintWindow, after " + maxWaitMilliseconds + " milliseconds, unable to produce preview of window."
					+ Environment.NewLine + Environment.NewLine + "This can be because this window is in debug mode.");
				return;
			}
			
			if (!success) return;

			memoryGraphics.ReleaseHdc(dc);
			//bmp.Save(@"c:\screenshot.bmp");

			const int maxAllowed = 100;// 200;
			int maxSideLength = Math.Max(rectToUse.Width, rectToUse.Height);

			int imageWidth = rectToUse.Width;
			if (imageWidth > maxAllowed)
				imageWidth = maxAllowed * imageWidth / maxSideLength;

			int imageHeight = rectToUse.Height;
			if (imageHeight > maxAllowed)
				imageHeight = maxAllowed * imageHeight / maxSideLength;

			/*//Ignore if top-left corner is "void" color
			Color pixTopLeft = bmp.GetPixel(0, 0);
			if (pixTopLeft.ToArgb() == voidColor.ToArgb())
				continue;

			//Ignore if all four corners are black
			Color pixTopRight = bmp.GetPixel(rectToUse.Width - 1, 0);
			Color pixTopMiddle = bmp.GetPixel(rectToUse.Width / 2, 0);
			Color pixBotLeft = bmp.GetPixel(0, rectToUse.Height - 1);
			Color pixBotMiddle = bmp.GetPixel(rectToUse.Width / 2, rectToUse.Height - 1);
			Color pixBotRight = bmp.GetPixel(rectToUse.Width - 1, rectToUse.Height - 1);
			Color pixCenter = bmp.GetPixel(rectToUse.Width / 2, rectToUse.Height / 2);
			if (pixTopLeft.ToArgb() == Color.Black.ToArgb()
				&& pixTopMiddle.ToArgb() == Color.Black.ToArgb()
				&& pixTopRight.ToArgb() == Color.Black.ToArgb()
				&& pixCenter.ToArgb() == Color.Black.ToArgb()
				&& pixBotLeft.ToArgb() == Color.Black.ToArgb()
				&& pixBotMiddle.ToArgb() == Color.Black.ToArgb()
				&& pixBotRight.ToArgb() == Color.Black.ToArgb())
				continue;*/

			pictureBoxPreview.Image = bmp;
		}

		private void textBoxFilter_KeyDown(object sender, KeyEventArgs e)
		{
			if (treeViewWindowTitlesAndHandles.Nodes.Count == 0)
				return;

			if (e.KeyCode == Keys.Down)
			{
				if (treeViewWindowTitlesAndHandles.SelectedNode == null)
					treeViewWindowTitlesAndHandles.SelectedNode = treeViewWindowTitlesAndHandles.Nodes[0];
				else
				{
					int selectedIndex = treeViewWindowTitlesAndHandles.Nodes.IndexOf(treeViewWindowTitlesAndHandles.SelectedNode);
					if (selectedIndex + 1 < treeViewWindowTitlesAndHandles.Nodes.Count)
						treeViewWindowTitlesAndHandles.SelectedNode = treeViewWindowTitlesAndHandles.Nodes[selectedIndex + 1];
					else
						treeViewWindowTitlesAndHandles.SelectedNode = treeViewWindowTitlesAndHandles.Nodes[0];
				}
			}
			else if (e.KeyCode == Keys.Up)
			{
				if (treeViewWindowTitlesAndHandles.SelectedNode == null)
					treeViewWindowTitlesAndHandles.SelectedNode = treeViewWindowTitlesAndHandles.Nodes[treeViewWindowTitlesAndHandles.Nodes.Count - 1];
				else
				{
					int selectedIndex = treeViewWindowTitlesAndHandles.Nodes.IndexOf(treeViewWindowTitlesAndHandles.SelectedNode);
					if (selectedIndex - 1 >= 0)
						treeViewWindowTitlesAndHandles.SelectedNode = treeViewWindowTitlesAndHandles.Nodes[selectedIndex - 1];
					else
						treeViewWindowTitlesAndHandles.SelectedNode = treeViewWindowTitlesAndHandles.Nodes[treeViewWindowTitlesAndHandles.Nodes.Count - 1];
				}
			}
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			labelCurrentFlashSpeedDisplay.Text = trackBarFlashSpeed.Value.ToString();
		}
	}
}

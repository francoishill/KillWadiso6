namespace KillWadiso6
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.button1 = new System.Windows.Forms.Button();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.makeAWindowflashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.gotoLastBuildtWadiso6dllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.changeProcessNameToKillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.AutoSize = true;
			this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button1.BackColor = System.Drawing.Color.Transparent;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(0, 0);
			this.button1.Margin = new System.Windows.Forms.Padding(0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(29, 22);
			this.button1.TabIndex = 0;
			this.button1.Text = "W6";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
			this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
			this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
			this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeAWindowflashToolStripMenuItem,
            this.toolStripSeparator1,
            this.gotoLastBuildtWadiso6dllToolStripMenuItem,
            this.toolStripSeparator3,
            this.changeProcessNameToKillToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(224, 132);
			// 
			// makeAWindowflashToolStripMenuItem
			// 
			this.makeAWindowflashToolStripMenuItem.Name = "makeAWindowflashToolStripMenuItem";
			this.makeAWindowflashToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
			this.makeAWindowflashToolStripMenuItem.Text = "Make a window &flash";
			this.makeAWindowflashToolStripMenuItem.Click += new System.EventHandler(this.makeAWindowflashToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(220, 6);
			// 
			// gotoLastBuildtWadiso6dllToolStripMenuItem
			// 
			this.gotoLastBuildtWadiso6dllToolStripMenuItem.Name = "gotoLastBuildtWadiso6dllToolStripMenuItem";
			this.gotoLastBuildtWadiso6dllToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
			this.gotoLastBuildtWadiso6dllToolStripMenuItem.Text = "Goto last built &Wadiso6.dll";
			this.gotoLastBuildtWadiso6dllToolStripMenuItem.Click += new System.EventHandler(this.gotoLastBuildtWadiso6dllToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(220, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 5000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// changeProcessNameToKillToolStripMenuItem
			// 
			this.changeProcessNameToKillToolStripMenuItem.Name = "changeProcessNameToKillToolStripMenuItem";
			this.changeProcessNameToKillToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
			this.changeProcessNameToKillToolStripMenuItem.Text = "C&hange process name to kill";
			this.changeProcessNameToKillToolStripMenuItem.Click += new System.EventHandler(this.changeProcessNameToKillToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(220, 6);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.DarkRed;
			this.ClientSize = new System.Drawing.Size(238, 126);
			this.Controls.Add(this.button1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Form1";
			this.Opacity = 0.3D;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.DarkRed;
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem makeAWindowflashToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gotoLastBuildtWadiso6dllToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem changeProcessNameToKillToolStripMenuItem;
	}
}


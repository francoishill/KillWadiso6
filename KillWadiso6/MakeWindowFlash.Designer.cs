namespace KillWadiso6
{
	partial class MakeWindowFlash
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
			this.buttonMakeFlash = new System.Windows.Forms.Button();
			this.treeViewWindowTitlesAndHandles = new System.Windows.Forms.TreeView();
			this.textBoxFilter = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonKillProcess = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
			this.trackBarFlashSpeed = new System.Windows.Forms.TrackBar();
			this.numericUpDownFlashCount = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.labelCurrentFlashSpeedDisplay = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarFlashSpeed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFlashCount)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonMakeFlash
			// 
			this.buttonMakeFlash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonMakeFlash.Location = new System.Drawing.Point(608, 12);
			this.buttonMakeFlash.Name = "buttonMakeFlash";
			this.buttonMakeFlash.Size = new System.Drawing.Size(75, 23);
			this.buttonMakeFlash.TabIndex = 3;
			this.buttonMakeFlash.Text = "Make &flash";
			this.buttonMakeFlash.UseVisualStyleBackColor = true;
			this.buttonMakeFlash.Click += new System.EventHandler(this.buttonMakeFlash_Click);
			// 
			// treeViewWindowTitlesAndHandles
			// 
			this.treeViewWindowTitlesAndHandles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeViewWindowTitlesAndHandles.HideSelection = false;
			this.treeViewWindowTitlesAndHandles.Location = new System.Drawing.Point(0, 0);
			this.treeViewWindowTitlesAndHandles.Name = "treeViewWindowTitlesAndHandles";
			this.treeViewWindowTitlesAndHandles.Size = new System.Drawing.Size(312, 302);
			this.treeViewWindowTitlesAndHandles.TabIndex = 0;
			this.treeViewWindowTitlesAndHandles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewWindowTitlesAndHandles_AfterSelect);
			// 
			// textBoxFilter
			// 
			this.textBoxFilter.Location = new System.Drawing.Point(47, 17);
			this.textBoxFilter.Name = "textBoxFilter";
			this.textBoxFilter.Size = new System.Drawing.Size(100, 20);
			this.textBoxFilter.TabIndex = 0;
			this.textBoxFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);
			this.textBoxFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxFilter_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Filter";
			// 
			// buttonKillProcess
			// 
			this.buttonKillProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonKillProcess.Location = new System.Drawing.Point(689, 12);
			this.buttonKillProcess.Name = "buttonKillProcess";
			this.buttonKillProcess.Size = new System.Drawing.Size(75, 23);
			this.buttonKillProcess.TabIndex = 5;
			this.buttonKillProcess.Text = "&Kill process";
			this.buttonKillProcess.UseVisualStyleBackColor = true;
			this.buttonKillProcess.Click += new System.EventHandler(this.buttonKillProcess_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(12, 55);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.treeViewWindowTitlesAndHandles);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxPreview);
			this.splitContainer1.Size = new System.Drawing.Size(752, 302);
			this.splitContainer1.SplitterDistance = 312;
			this.splitContainer1.TabIndex = 5;
			// 
			// pictureBoxPreview
			// 
			this.pictureBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBoxPreview.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxPreview.Name = "pictureBoxPreview";
			this.pictureBoxPreview.Size = new System.Drawing.Size(436, 302);
			this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxPreview.TabIndex = 0;
			this.pictureBoxPreview.TabStop = false;
			// 
			// trackBarFlashSpeed
			// 
			this.trackBarFlashSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.trackBarFlashSpeed.AutoSize = false;
			this.trackBarFlashSpeed.LargeChange = 200;
			this.trackBarFlashSpeed.Location = new System.Drawing.Point(498, 12);
			this.trackBarFlashSpeed.Maximum = 2000;
			this.trackBarFlashSpeed.Minimum = 200;
			this.trackBarFlashSpeed.Name = "trackBarFlashSpeed";
			this.trackBarFlashSpeed.Size = new System.Drawing.Size(104, 34);
			this.trackBarFlashSpeed.SmallChange = 200;
			this.trackBarFlashSpeed.TabIndex = 2;
			this.trackBarFlashSpeed.TickFrequency = 200;
			this.trackBarFlashSpeed.Value = 1000;
			this.trackBarFlashSpeed.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// numericUpDownFlashCount
			// 
			this.numericUpDownFlashCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDownFlashCount.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numericUpDownFlashCount.Location = new System.Drawing.Point(341, 15);
			this.numericUpDownFlashCount.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.numericUpDownFlashCount.Name = "numericUpDownFlashCount";
			this.numericUpDownFlashCount.Size = new System.Drawing.Size(69, 20);
			this.numericUpDownFlashCount.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(264, 9);
			this.label2.MaximumSize = new System.Drawing.Size(65, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 26);
			this.label2.TabIndex = 8;
			this.label2.Text = "Flash times (0 = forever)";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(428, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Flash speed";
			// 
			// labelCurrentFlashSpeedDisplay
			// 
			this.labelCurrentFlashSpeedDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCurrentFlashSpeedDisplay.AutoSize = true;
			this.labelCurrentFlashSpeedDisplay.Location = new System.Drawing.Point(428, 24);
			this.labelCurrentFlashSpeedDisplay.Name = "labelCurrentFlashSpeedDisplay";
			this.labelCurrentFlashSpeedDisplay.Size = new System.Drawing.Size(35, 13);
			this.labelCurrentFlashSpeedDisplay.TabIndex = 10;
			this.labelCurrentFlashSpeedDisplay.Text = "label4";
			// 
			// MakeWindowFlash
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(776, 369);
			this.Controls.Add(this.labelCurrentFlashSpeedDisplay);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numericUpDownFlashCount);
			this.Controls.Add(this.trackBarFlashSpeed);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.buttonKillProcess);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxFilter);
			this.Controls.Add(this.buttonMakeFlash);
			this.Name = "MakeWindowFlash";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MakeWindowFlash";
			this.TopMost = true;
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarFlashSpeed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFlashCount)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonMakeFlash;
		private System.Windows.Forms.TreeView treeViewWindowTitlesAndHandles;
		private System.Windows.Forms.TextBox textBoxFilter;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonKillProcess;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.PictureBox pictureBoxPreview;
		private System.Windows.Forms.TrackBar trackBarFlashSpeed;
		private System.Windows.Forms.NumericUpDown numericUpDownFlashCount;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label labelCurrentFlashSpeedDisplay;
	}
}
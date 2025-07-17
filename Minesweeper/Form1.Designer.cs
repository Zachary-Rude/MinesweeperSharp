namespace Minesweeper
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnRestart = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.pnlBody = new System.Windows.Forms.Panel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.difficultyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.beginnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.intermediateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.expertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.howToPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutMinesweeperSharpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.btnRestart);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(381, 76);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Location = new System.Drawing.Point(0, 74);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(381, 2);
			this.label1.TabIndex = 4;
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox2.ForeColor = System.Drawing.Color.Red;
			this.textBox2.Location = new System.Drawing.Point(313, 21);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(56, 32);
			this.textBox2.TabIndex = 2;
			this.textBox2.Text = "0";
			this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBox2.Enter += new System.EventHandler(this.btnRestart_Enter);
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.ForeColor = System.Drawing.Color.Red;
			this.textBox1.Location = new System.Drawing.Point(12, 21);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(56, 32);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "30";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBox1.Enter += new System.EventHandler(this.btnRestart_Enter);
			// 
			// btnRestart
			// 
			this.btnRestart.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnRestart.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnRestart.Image = global::Minesweeper.Properties.Resources.slightly_smiling_face_1f642;
			this.btnRestart.Location = new System.Drawing.Point(169, 16);
			this.btnRestart.Name = "btnRestart";
			this.btnRestart.Size = new System.Drawing.Size(43, 43);
			this.btnRestart.TabIndex = 5;
			this.btnRestart.UseVisualStyleBackColor = true;
			this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// pnlBody
			// 
			this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBody.Location = new System.Drawing.Point(0, 100);
			this.pnlBody.Name = "pnlBody";
			this.pnlBody.Size = new System.Drawing.Size(381, 343);
			this.pnlBody.TabIndex = 1;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
			this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.menuStrip1.Size = new System.Drawing.Size(381, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// gameToolStripMenuItem
			// 
			this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.difficultyToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
			this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
			this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
			this.gameToolStripMenuItem.Text = "&Game";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.newToolStripMenuItem.Text = "&New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.btnRestart_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
			// 
			// difficultyToolStripMenuItem
			// 
			this.difficultyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beginnerToolStripMenuItem,
            this.intermediateToolStripMenuItem,
            this.expertToolStripMenuItem});
			this.difficultyToolStripMenuItem.Name = "difficultyToolStripMenuItem";
			this.difficultyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.difficultyToolStripMenuItem.Text = "&Difficulty";
			// 
			// beginnerToolStripMenuItem
			// 
			this.beginnerToolStripMenuItem.Name = "beginnerToolStripMenuItem";
			this.beginnerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.beginnerToolStripMenuItem.Text = "&Beginner";
			this.beginnerToolStripMenuItem.Click += new System.EventHandler(this.difficultyMenu_Click);
			// 
			// intermediateToolStripMenuItem
			// 
			this.intermediateToolStripMenuItem.Checked = true;
			this.intermediateToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.intermediateToolStripMenuItem.Name = "intermediateToolStripMenuItem";
			this.intermediateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.intermediateToolStripMenuItem.Text = "&Intermediate";
			this.intermediateToolStripMenuItem.Click += new System.EventHandler(this.difficultyMenu_Click);
			// 
			// expertToolStripMenuItem
			// 
			this.expertToolStripMenuItem.Name = "expertToolStripMenuItem";
			this.expertToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.expertToolStripMenuItem.Text = "&Expert";
			this.expertToolStripMenuItem.Click += new System.EventHandler(this.difficultyMenu_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToPlayToolStripMenuItem,
            this.toolStripMenuItem2,
            this.aboutMinesweeperSharpToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// howToPlayToolStripMenuItem
			// 
			this.howToPlayToolStripMenuItem.Name = "howToPlayToolStripMenuItem";
			this.howToPlayToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
			this.howToPlayToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
			this.howToPlayToolStripMenuItem.Text = "&How to Play";
			this.howToPlayToolStripMenuItem.Click += new System.EventHandler(this.howToPlayToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(258, 6);
			// 
			// aboutMinesweeperSharpToolStripMenuItem
			// 
			this.aboutMinesweeperSharpToolStripMenuItem.Name = "aboutMinesweeperSharpToolStripMenuItem";
			this.aboutMinesweeperSharpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F1)));
			this.aboutMinesweeperSharpToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
			this.aboutMinesweeperSharpToolStripMenuItem.Text = "&About MinesweeperSharp";
			this.aboutMinesweeperSharpToolStripMenuItem.Click += new System.EventHandler(this.aboutMinesweeperSharpToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(381, 443);
			this.Controls.Add(this.pnlBody);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MinesweeperSharp";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnRestart;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Panel pnlBody;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem difficultyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem beginnerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem intermediateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem expertToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem howToPlayToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem aboutMinesweeperSharpToolStripMenuItem;
	}
}


namespace Minesweeper {
    partial class frmMainFrame {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainFrame));
            mnsToolbar = new MenuStrip();
            tsmiGame = new ToolStripMenuItem();
            tsmiNewGame = new ToolStripMenuItem();
            tssSeparator1 = new ToolStripSeparator();
            tsmiBegginerDifficulty = new ToolStripMenuItem();
            tsmiIntermediateDifficulty = new ToolStripMenuItem();
            tsmiExpertDifficulty = new ToolStripMenuItem();
            tsmiCustomDifficulty = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            tsmiBiggerTiles = new ToolStripMenuItem();
            tssSeparator2 = new ToolStripSeparator();
            tsmiExit = new ToolStripMenuItem();
            tsmiHelp = new ToolStripMenuItem();
            tsmiAboutMinesweeper = new ToolStripMenuItem();
            ssrStatusStrip = new StatusStrip();
            tsslStatus = new ToolStripStatusLabel();
            tlpGrid = new TableLayoutPanel();
            toolStripSeparator2 = new ToolStripSeparator();
            tsmiGithub = new ToolStripMenuItem();
            mnsToolbar.SuspendLayout();
            ssrStatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // mnsToolbar
            // 
            mnsToolbar.GripMargin = new Padding(0);
            mnsToolbar.Items.AddRange(new ToolStripItem[] { tsmiGame, tsmiHelp });
            mnsToolbar.Location = new Point(0, 0);
            mnsToolbar.Name = "mnsToolbar";
            mnsToolbar.Padding = new Padding(0);
            mnsToolbar.RenderMode = ToolStripRenderMode.System;
            mnsToolbar.Size = new Size(157, 24);
            mnsToolbar.TabIndex = 0;
            // 
            // tsmiGame
            // 
            tsmiGame.DropDownItems.AddRange(new ToolStripItem[] { tsmiNewGame, tssSeparator1, tsmiBegginerDifficulty, tsmiIntermediateDifficulty, tsmiExpertDifficulty, tsmiCustomDifficulty, toolStripSeparator1, tsmiBiggerTiles, tssSeparator2, tsmiExit });
            tsmiGame.Name = "tsmiGame";
            tsmiGame.Padding = new Padding(0);
            tsmiGame.Size = new Size(42, 24);
            tsmiGame.Text = "Game";
            // 
            // tsmiNewGame
            // 
            tsmiNewGame.Name = "tsmiNewGame";
            tsmiNewGame.ShortcutKeys = Keys.F2;
            tsmiNewGame.Size = new Size(164, 22);
            tsmiNewGame.Text = "New";
            tsmiNewGame.Click += tsmiNewGame_Click;
            // 
            // tssSeparator1
            // 
            tssSeparator1.Name = "tssSeparator1";
            tssSeparator1.Size = new Size(161, 6);
            // 
            // tsmiBegginerDifficulty
            // 
            tsmiBegginerDifficulty.Checked = true;
            tsmiBegginerDifficulty.CheckOnClick = true;
            tsmiBegginerDifficulty.CheckState = CheckState.Checked;
            tsmiBegginerDifficulty.Name = "tsmiBegginerDifficulty";
            tsmiBegginerDifficulty.Size = new Size(164, 22);
            tsmiBegginerDifficulty.Tag = "Beginner";
            tsmiBegginerDifficulty.Text = "Beginner";
            tsmiBegginerDifficulty.Click += tsmiDifficulty_Click;
            // 
            // tsmiIntermediateDifficulty
            // 
            tsmiIntermediateDifficulty.CheckOnClick = true;
            tsmiIntermediateDifficulty.Name = "tsmiIntermediateDifficulty";
            tsmiIntermediateDifficulty.Size = new Size(164, 22);
            tsmiIntermediateDifficulty.Tag = "Intermediate";
            tsmiIntermediateDifficulty.Text = "Intermediate";
            tsmiIntermediateDifficulty.Click += tsmiDifficulty_Click;
            // 
            // tsmiExpertDifficulty
            // 
            tsmiExpertDifficulty.CheckOnClick = true;
            tsmiExpertDifficulty.Name = "tsmiExpertDifficulty";
            tsmiExpertDifficulty.Size = new Size(164, 22);
            tsmiExpertDifficulty.Tag = "Expert";
            tsmiExpertDifficulty.Text = "Expert";
            tsmiExpertDifficulty.Click += tsmiDifficulty_Click;
            // 
            // tsmiCustomDifficulty
            // 
            tsmiCustomDifficulty.CheckOnClick = true;
            tsmiCustomDifficulty.Name = "tsmiCustomDifficulty";
            tsmiCustomDifficulty.Size = new Size(164, 22);
            tsmiCustomDifficulty.Tag = "Custom";
            tsmiCustomDifficulty.Text = "Custom...";
            tsmiCustomDifficulty.Click += tsmiDifficulty_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(161, 6);
            // 
            // tsmiBiggerTiles
            // 
            tsmiBiggerTiles.CheckOnClick = true;
            tsmiBiggerTiles.Name = "tsmiBiggerTiles";
            tsmiBiggerTiles.Size = new Size(164, 22);
            tsmiBiggerTiles.Text = "Show bigger tiles";
            tsmiBiggerTiles.Click += tsmiBiggerTiles_Click;
            // 
            // tssSeparator2
            // 
            tssSeparator2.Name = "tssSeparator2";
            tssSeparator2.Size = new Size(161, 6);
            // 
            // tsmiExit
            // 
            tsmiExit.Name = "tsmiExit";
            tsmiExit.Size = new Size(164, 22);
            tsmiExit.Text = "Exit";
            tsmiExit.Click += tsmiExit_Click;
            // 
            // tsmiHelp
            // 
            tsmiHelp.DropDownItems.AddRange(new ToolStripItem[] { tsmiAboutMinesweeper, toolStripSeparator2, tsmiGithub });
            tsmiHelp.Name = "tsmiHelp";
            tsmiHelp.Size = new Size(44, 24);
            tsmiHelp.Text = "Help";
            // 
            // tsmiAboutMinesweeper
            // 
            tsmiAboutMinesweeper.Name = "tsmiAboutMinesweeper";
            tsmiAboutMinesweeper.ShortcutKeys = Keys.F1;
            tsmiAboutMinesweeper.Size = new Size(199, 22);
            tsmiAboutMinesweeper.Text = "About Minesweeper";
            tsmiAboutMinesweeper.Click += tsmiAboutMinesweeper_Click;
            // 
            // ssrStatusStrip
            // 
            ssrStatusStrip.AutoSize = false;
            ssrStatusStrip.BackColor = Color.FromArgb(224, 224, 224);
            ssrStatusStrip.Dock = DockStyle.Top;
            ssrStatusStrip.Items.AddRange(new ToolStripItem[] { tsslStatus });
            ssrStatusStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            ssrStatusStrip.Location = new Point(0, 24);
            ssrStatusStrip.Name = "ssrStatusStrip";
            ssrStatusStrip.RenderMode = ToolStripRenderMode.Professional;
            ssrStatusStrip.Size = new Size(157, 30);
            ssrStatusStrip.SizingGrip = false;
            ssrStatusStrip.TabIndex = 1;
            // 
            // tsslStatus
            // 
            tsslStatus.Name = "tsslStatus";
            tsslStatus.Size = new Size(25, 25);
            tsslStatus.Text = "      ";
            // 
            // tlpGrid
            // 
            tlpGrid.AutoSize = true;
            tlpGrid.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpGrid.BackColor = Color.Gray;
            tlpGrid.ColumnCount = 2;
            tlpGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpGrid.Location = new Point(7, 63);
            tlpGrid.Margin = new Padding(7);
            tlpGrid.MinimumSize = new Size(144, 144);
            tlpGrid.Name = "tlpGrid";
            tlpGrid.Padding = new Padding(3);
            tlpGrid.RowCount = 2;
            tlpGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpGrid.Size = new Size(144, 144);
            tlpGrid.TabIndex = 2;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(196, 6);
            // 
            // tsmiGithub
            // 
            tsmiGithub.Name = "tsmiGithub";
            tsmiGithub.Size = new Size(199, 22);
            tsmiGithub.Text = "View on Github";
            tsmiGithub.Click += tsmiGithub_Click;
            // 
            // frmMainFrame
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Silver;
            ClientSize = new Size(157, 213);
            Controls.Add(tlpGrid);
            Controls.Add(ssrStatusStrip);
            Controls.Add(mnsToolbar);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mnsToolbar;
            MaximizeBox = false;
            Name = "frmMainFrame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Minesweeper";
            KeyUp += frmMainFrame_KeyUp;
            mnsToolbar.ResumeLayout(false);
            mnsToolbar.PerformLayout();
            ssrStatusStrip.ResumeLayout(false);
            ssrStatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnsToolbar;
        private ToolStripMenuItem tsmiGame;
        private ToolStripMenuItem tsmiHelp;
        private ToolStripMenuItem tsmiBegginerDifficulty;
        private ToolStripMenuItem tsmiIntermediateDifficulty;
        private ToolStripMenuItem tsmiExpertDifficulty;
        private ToolStripMenuItem tsmiCustomDifficulty;
        private ToolStripMenuItem tsmiExit;
        private ToolStripMenuItem tsmiAboutMinesweeper;
        private ToolStripMenuItem tsmiNewGame;
        private ToolStripSeparator tssSeparator1;
        private ToolStripSeparator tssSeparator2;
        private StatusStrip ssrStatusStrip;
        private TableLayoutPanel tlpGrid;
        private ToolStripStatusLabel tsslStatus;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsmiBiggerTiles;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem tsmiGithub;
    }
}
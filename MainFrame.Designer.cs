namespace Minesweeper {
    partial class MainFrame {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrame));
            mnsToolbar = new MenuStrip();
            tsmiGame = new ToolStripMenuItem();
            tsmiNewGame = new ToolStripMenuItem();
            tssSeparator1 = new ToolStripSeparator();
            tsmiBegginerDifficulty = new ToolStripMenuItem();
            tsmiIntermediateDifficulty = new ToolStripMenuItem();
            tsmiExpertDifficulty = new ToolStripMenuItem();
            tsmiCustomDifficulty = new ToolStripMenuItem();
            tssSeparator2 = new ToolStripSeparator();
            tsmiExit = new ToolStripMenuItem();
            tsmiHelp = new ToolStripMenuItem();
            tsmiAboutMinesweeper = new ToolStripMenuItem();
            ssrStatusStrip = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            tlpGrid = new TableLayoutPanel();
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
            mnsToolbar.Size = new Size(229, 24);
            mnsToolbar.TabIndex = 0;
            // 
            // tsmiGame
            // 
            tsmiGame.DropDownItems.AddRange(new ToolStripItem[] { tsmiNewGame, tssSeparator1, tsmiBegginerDifficulty, tsmiIntermediateDifficulty, tsmiExpertDifficulty, tsmiCustomDifficulty, tssSeparator2, tsmiExit });
            tsmiGame.Name = "tsmiGame";
            tsmiGame.Padding = new Padding(0);
            tsmiGame.Size = new Size(42, 24);
            tsmiGame.Text = "Game";
            // 
            // tsmiNewGame
            // 
            tsmiNewGame.Name = "tsmiNewGame";
            tsmiNewGame.ShortcutKeys = Keys.F2;
            tsmiNewGame.Size = new Size(141, 22);
            tsmiNewGame.Text = "New";
            tsmiNewGame.Click += tsmiNewGame_Click;
            // 
            // tssSeparator1
            // 
            tssSeparator1.Name = "tssSeparator1";
            tssSeparator1.Size = new Size(138, 6);
            // 
            // tsmiBegginerDifficulty
            // 
            tsmiBegginerDifficulty.Checked = true;
            tsmiBegginerDifficulty.CheckOnClick = true;
            tsmiBegginerDifficulty.CheckState = CheckState.Checked;
            tsmiBegginerDifficulty.Name = "tsmiBegginerDifficulty";
            tsmiBegginerDifficulty.Size = new Size(141, 22);
            tsmiBegginerDifficulty.Tag = "Beginner";
            tsmiBegginerDifficulty.Text = "Beginner";
            tsmiBegginerDifficulty.Click += tsmiDifficulty_Click;
            // 
            // tsmiIntermediateDifficulty
            // 
            tsmiIntermediateDifficulty.CheckOnClick = true;
            tsmiIntermediateDifficulty.Name = "tsmiIntermediateDifficulty";
            tsmiIntermediateDifficulty.Size = new Size(141, 22);
            tsmiIntermediateDifficulty.Tag = "Intermediate";
            tsmiIntermediateDifficulty.Text = "Intermediate";
            tsmiIntermediateDifficulty.Click += tsmiDifficulty_Click;
            // 
            // tsmiExpertDifficulty
            // 
            tsmiExpertDifficulty.CheckOnClick = true;
            tsmiExpertDifficulty.Name = "tsmiExpertDifficulty";
            tsmiExpertDifficulty.Size = new Size(141, 22);
            tsmiExpertDifficulty.Tag = "Expert";
            tsmiExpertDifficulty.Text = "Expert";
            tsmiExpertDifficulty.Click += tsmiDifficulty_Click;
            // 
            // tsmiCustomDifficulty
            // 
            tsmiCustomDifficulty.CheckOnClick = true;
            tsmiCustomDifficulty.Name = "tsmiCustomDifficulty";
            tsmiCustomDifficulty.Size = new Size(141, 22);
            tsmiCustomDifficulty.Tag = "Custom";
            tsmiCustomDifficulty.Text = "Custom...";
            tsmiCustomDifficulty.Click += tsmiDifficulty_Click;
            // 
            // tssSeparator2
            // 
            tssSeparator2.Name = "tssSeparator2";
            tssSeparator2.Size = new Size(138, 6);
            // 
            // tsmiExit
            // 
            tsmiExit.Name = "tsmiExit";
            tsmiExit.Size = new Size(141, 22);
            tsmiExit.Text = "Exit";
            tsmiExit.Click += tsmiExit_Click;
            // 
            // tsmiHelp
            // 
            tsmiHelp.DropDownItems.AddRange(new ToolStripItem[] { tsmiAboutMinesweeper });
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
            ssrStatusStrip.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ssrStatusStrip.AutoSize = false;
            ssrStatusStrip.Dock = DockStyle.None;
            ssrStatusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            ssrStatusStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            ssrStatusStrip.Location = new Point(0, 243);
            ssrStatusStrip.Name = "ssrStatusStrip";
            ssrStatusStrip.RenderMode = ToolStripRenderMode.Professional;
            ssrStatusStrip.Size = new Size(166, 22);
            ssrStatusStrip.SizingGrip = false;
            ssrStatusStrip.TabIndex = 1;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // tlpGrid
            // 
            tlpGrid.ColumnCount = 2;
            tlpGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpGrid.Location = new Point(0, 24);
            tlpGrid.Margin = new Padding(0);
            tlpGrid.Name = "tlpGrid";
            tlpGrid.Padding = new Padding(10);
            tlpGrid.RowCount = 2;
            tlpGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpGrid.Size = new Size(226, 211);
            tlpGrid.TabIndex = 2;
            // 
            // MainFrame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(229, 265);
            Controls.Add(tlpGrid);
            Controls.Add(ssrStatusStrip);
            Controls.Add(mnsToolbar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mnsToolbar;
            Name = "MainFrame";
            Text = "Minesweeper";
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
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}
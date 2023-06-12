namespace Minesweeper {
    partial class frmCustomGameSettings {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomGameSettings));
            lblSettingHeight = new Label();
            lblSettingWidth = new Label();
            lblSettingMines = new Label();
            btnSettingsOk = new Button();
            btnSettingsCancel = new Button();
            nudSettingsMines = new NumericUpDown();
            nudSettingsWidth = new NumericUpDown();
            nudSettingsHeight = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nudSettingsMines).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSettingsWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSettingsHeight).BeginInit();
            SuspendLayout();
            // 
            // lblSettingHeight
            // 
            lblSettingHeight.AutoSize = true;
            lblSettingHeight.Location = new Point(16, 15);
            lblSettingHeight.Name = "lblSettingHeight";
            lblSettingHeight.Size = new Size(46, 15);
            lblSettingHeight.TabIndex = 0;
            lblSettingHeight.Text = "Height:";
            // 
            // lblSettingWidth
            // 
            lblSettingWidth.AutoSize = true;
            lblSettingWidth.Location = new Point(16, 44);
            lblSettingWidth.Name = "lblSettingWidth";
            lblSettingWidth.Size = new Size(42, 15);
            lblSettingWidth.TabIndex = 2;
            lblSettingWidth.Text = "Width:";
            // 
            // lblSettingMines
            // 
            lblSettingMines.AutoSize = true;
            lblSettingMines.Location = new Point(16, 73);
            lblSettingMines.Name = "lblSettingMines";
            lblSettingMines.Size = new Size(42, 15);
            lblSettingMines.TabIndex = 3;
            lblSettingMines.Text = "Mines:";
            // 
            // btnSettingsOk
            // 
            btnSettingsOk.Location = new Point(156, 24);
            btnSettingsOk.Name = "btnSettingsOk";
            btnSettingsOk.Size = new Size(75, 23);
            btnSettingsOk.TabIndex = 6;
            btnSettingsOk.Text = "Ok";
            btnSettingsOk.UseVisualStyleBackColor = true;
            btnSettingsOk.Click += btnSettingsOk_Click;
            // 
            // btnSettingsCancel
            // 
            btnSettingsCancel.Location = new Point(156, 54);
            btnSettingsCancel.Name = "btnSettingsCancel";
            btnSettingsCancel.Size = new Size(75, 23);
            btnSettingsCancel.TabIndex = 7;
            btnSettingsCancel.Text = "Cancel";
            btnSettingsCancel.UseVisualStyleBackColor = true;
            btnSettingsCancel.Click += btnSettingsCancel_Click;
            // 
            // nudSettingsMines
            // 
            nudSettingsMines.Location = new Point(68, 71);
            nudSettingsMines.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudSettingsMines.Name = "nudSettingsMines";
            nudSettingsMines.Size = new Size(65, 23);
            nudSettingsMines.TabIndex = 8;
            // 
            // nudSettingsWidth
            // 
            nudSettingsWidth.Location = new Point(68, 42);
            nudSettingsWidth.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            nudSettingsWidth.Name = "nudSettingsWidth";
            nudSettingsWidth.Size = new Size(65, 23);
            nudSettingsWidth.TabIndex = 9;
            // 
            // nudSettingsHeight
            // 
            nudSettingsHeight.Location = new Point(68, 13);
            nudSettingsHeight.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            nudSettingsHeight.Name = "nudSettingsHeight";
            nudSettingsHeight.Size = new Size(65, 23);
            nudSettingsHeight.TabIndex = 10;
            // 
            // frmCustomGameSettings
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(245, 105);
            Controls.Add(nudSettingsHeight);
            Controls.Add(nudSettingsWidth);
            Controls.Add(nudSettingsMines);
            Controls.Add(btnSettingsCancel);
            Controls.Add(btnSettingsOk);
            Controls.Add(lblSettingMines);
            Controls.Add(lblSettingWidth);
            Controls.Add(lblSettingHeight);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCustomGameSettings";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Custom Field";
            Load += frmCustomGameSettings_Load;
            ((System.ComponentModel.ISupportInitialize)nudSettingsMines).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSettingsWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSettingsHeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSettingHeight;
        private Label lblSettingWidth;
        private Label lblSettingMines;
        private Button btnSettingsOk;
        private Button btnSettingsCancel;
        private NumericUpDown nudSettingsMines;
        private NumericUpDown nudSettingsWidth;
        private NumericUpDown nudSettingsHeight;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper {
    public partial class frmCustomGameSettings : Form {
        private frmMainFrame mainForm;

        public frmCustomGameSettings(frmMainFrame mainForm) {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void frmCustomGameSettings_Load(object sender, EventArgs e) {
            nudSettingsHeight.Value = Program.HEIGHT;
            nudSettingsWidth.Value = Program.WIDTH;
            nudSettingsMines.Value = Program.NB_MINES;
        }

        private void btnSettingsCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnSettingsOk_Click(object sender, EventArgs e) {
            // Limits (from the original game) :
            // 9 < SIZE_X < 24
            // 9 < SIZE_Y < 30
            // MINES < SIZE_X-1 * SIZE_Y-1
            Program.HEIGHT = Math.Clamp((int)nudSettingsHeight.Value, 9, 24);
            Program.WIDTH = Math.Clamp((int)nudSettingsWidth.Value, 9, 30);
            Program.NB_MINES = Math.Min((int)nudSettingsMines.Value, (Program.HEIGHT-1) * (Program.WIDTH-1));
            MessageBox.Show("Height: " + Program.HEIGHT + "\nWidth: " + Program.WIDTH + "\nMines: " + Program.NB_MINES);

            mainForm.newGame(Program.HEIGHT, Program.WIDTH, Program.NB_MINES);
            this.Close();
        }
    }
}

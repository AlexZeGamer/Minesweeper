using System.Diagnostics;

namespace Minesweeper {
    public partial class MainFrame : Form {
        int SIZE_X = 9; // rows
        int SIZE_Y = 9; // columns
        int MINES = 10;
        const int BUTTON_SIZE = 16; // in pixels

        public MainFrame() {
            InitializeComponent();
            newGame(SIZE_X, SIZE_Y, MINES);
        }

        private void newGame(int sizeX, int sizeY, int nbMines) {
            this.SIZE_X = sizeX;
            this.SIZE_Y = sizeY;
            this.MINES = nbMines;

            createGrid(sizeX, sizeY);
        }

        private void createGrid(int sizeX, int sizeY) {
            // Suspend layout updates
            tlpGrid.SuspendLayout();

            // empty existing grid if any
            tlpGrid.Controls.Clear();

            // creating grid with good dimensions
            tlpGrid.RowCount = sizeX;
            tlpGrid.ColumnCount = sizeY;
            tlpGrid.AutoSize = true;
            tlpGrid.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // adding buttons
            for (int x = 0; x < sizeX; x++) {
                for (int y = 0; y < sizeY; y++) {
                    Button btn = create_button();
                    tlpGrid.Controls.Add(btn, y, x);
                }
            }

            // Resume layout updates and perform a final layout
            tlpGrid.ResumeLayout();
            tlpGrid.PerformLayout();
        }

        private Button create_button() {
            Button button = new Button();
            button.BackgroundImage = Properties.Resources.undiscovered;
            button.BackgroundImageLayout = ImageLayout.Stretch;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Margin = new Padding(0);
            button.Size = new Size(BUTTON_SIZE, BUTTON_SIZE);

            // add event handler
            button.Click += new EventHandler(button_Click);

            return button;
        }

        private void button_Click(object sender, EventArgs e) {
            Button button = (Button)sender;
            button.BackgroundImage = Properties.Resources.discovered;

            // get button position
            int x = tlpGrid.GetRow(button);
            int y = tlpGrid.GetColumn(button);
        }

        private void OpenWinverWindow() {
            // Create a new process for running the "winver" command
            Process process = new Process();

            // Set the process start info
            ProcessStartInfo startInfo = new ProcessStartInfo {
                FileName = "winver",    // Command to run
                UseShellExecute = true  // Use the shell to execute the command
            };

            process.StartInfo = startInfo;

            try {
                // Start the process
                process.Start();
            }
            catch (Exception ex) {
                // Handle any exceptions that may occur
                MessageBox.Show("Error opening winver: " + ex.Message);
            }
        }



        // tsmiGame items

        private void tsmiNewGame_Click(object sender, EventArgs e) {
            newGame(SIZE_X, SIZE_Y, MINES);
        }

        // ----------

        private void tsmiDifficulty_Click(object sender, EventArgs e) {

            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

            // Uncheck every item in the dropdown menu...
            foreach (ToolStripItem item in clickedItem.Owner.Items) {
                // ... only if it's a Difficulty button
                if (item is ToolStripMenuItem && item.Name.EndsWith("Difficulty")) {
                    ((ToolStripMenuItem)item).Checked = false;
                }
            }
            // And check the selected item
            clickedItem.Checked = true;

            // Get the difficulty level from the Tag property of the clicked item.
            string difficultyLevel = clickedItem.Tag.ToString() ?? string.Empty;

            // Do something with the difficulty level.
            switch (difficultyLevel) {
                case "Beginner":
                    newGame(9, 9, 10);
                    break;
                case "Intermediate":
                    newGame(16, 16, 40);
                    break;
                case "Expert":
                    newGame(16, 30, 99);
                    break;
                case "Custom":
                    // TODO
                    break;
                default:
                    newGame(SIZE_X, SIZE_Y, MINES);
                    break;
            }
        }

        // ----------
        private void tsmiExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }



        // tsmiHelp items

        private void tsmiAboutMinesweeper_Click(object sender, EventArgs e) {
            String title = "About";
            String message = "This game was made by Alexandre MALFREYT." + Environment.NewLine
                + "It was made for the course \"Développement d'applications avec IHM\" at the IUT d'Orsay." + Environment.NewLine
                + "It is an assignment for the 2nd semester." + Environment.NewLine
                + "The source code is available on GitHub at https://github.com/AlexZeGamer/Minesweeper";

            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
        }
    }
}
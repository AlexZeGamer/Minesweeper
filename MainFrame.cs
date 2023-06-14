using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security.Policy;

namespace Minesweeper {

    public partial class frmMainFrame : Form {
        private KonamiSequence sequence = new KonamiSequence(); // Konami sequence

        static int TILE_SIZE = 16; // in pixels

        public frmMainFrame() {
            this.KeyPreview = true; // Allows the form to process key events
            InitializeComponent();
            new_game(Program.HEIGHT, Program.WIDTH, Program.NB_MINES);
        }

        /// <summary>
        /// Generate a random integer between min and max
        /// </summary>
        private int randint(int min, int max) {
            Random rand = new Random();
            int x = min;
            int y = max;
            int randInt = rand.Next(x, y);
            return randInt;
        }

        /// <summary>
        /// Reset every game variables and create a new game
        /// </summary>
        public void new_game(int height, int width, int nbMines) {
            Program.inGame = false;
            Program.gameLost = false;
            Program.nbClicks = 0;

            Program.HEIGHT = height;
            Program.WIDTH = width;
            Program.NB_MINES = nbMines;

            Program.nbMinesRemaining = nbMines;

            Program.REVEALED_GRID = new bool[Program.HEIGHT, Program.WIDTH]; // grid of revealed tiles
            Program.FLAGS_GRID = new bool[Program.HEIGHT, Program.WIDTH]; // grid of flags
            Program.MINES_GRID = shuffle_mines(height, width, nbMines); // grid of mines
            create_buttons_grid(height, width); // create the grid of buttons
        }

        /// <summary>
        /// Debug function to print the grid of mines
        /// </summary>
        private string print_mines_grid() {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Program.HEIGHT; i++) {
                for (int j = 0; j < Program.WIDTH; j++) {
                    sb.Append(Program.MINES_GRID[i, j] ? "1" : "0");
                    sb.Append(" ");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        /// <summary>
        /// Create a grid of mines with nbMines mines randomly placed
        /// </summary>
        private bool[,] shuffle_mines(int height, int width, int nbMines) {
            bool[,] mines = new bool[height, width];
            int count = 0;

            while (count < nbMines) {
                int row = randint(0, height);
                int col = randint(0, width);

                if (!mines[row, col]) {
                    mines[row, col] = true;
                    count++;
                }
            }

            return mines;
        }

        /// <summary>
        /// Create the grid of buttons with the given dimensions and add them to the TableLayoutPanel
        /// </summary>
        private void create_buttons_grid(int height, int width) {
            Program.inGame = false;
            tsslStatus.Text = "Loading...";
            this.Refresh();

            tlpGrid.SuspendLayout();

            // creating grid with good dimensions
            tlpGrid.RowCount = height;
            tlpGrid.ColumnCount = width;

            // empty existing grid if any
            tlpGrid.Controls.Clear();

            // adding buttons
            for (int x = 0; x < height; x++) {
                for (int y = 0; y < width; y++) {
                    Button btn = create_button();
                    tlpGrid.Controls.Add(btn, y, x);
                }
            }

            tlpGrid.ResumeLayout(true);

            Program.inGame = true;
            update_status_text();
        }

        /// <summary>
        /// Create a button with the default properties to be added to the grid of buttons and return it
        /// </summary>
        private Button create_button() {
            Button button = new Button();
            button.BackgroundImage = Properties.Resources.undiscovered;
            button.BackgroundImageLayout = ImageLayout.Stretch;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Margin = new Padding(0);
            button.Size = new Size(TILE_SIZE, TILE_SIZE);

            // add event handler
            button.MouseUp += new MouseEventHandler(tile_click);

            return button;
        }

        /// <summary>
        /// Handle the click on a tile (left, right or middle click) and call the appropriate functions
        /// </summary>
        private void tile_click(object sender, MouseEventArgs e) {
            // if the game is not running or if the game is over, do nothing
            if (!Program.inGame || Program.gameLost) { return; }

            // get clicked button position
            Button button = (Button)sender;
            int x = tlpGrid.GetRow(button);
            int y = tlpGrid.GetColumn(button);

            switch (e.Button) {
                case MouseButtons.Left:
                    left_click(x, y);
                    break;

                case MouseButtons.Right:
                    right_click(x, y);
                    break;

                case MouseButtons.Middle:
                    middle_click(x, y);
                    break;

                default: break;
            }

            update_status_text();
        }

        /// <summary>
        /// Handle left click on a tile (revealing the tile)
        /// </summary>
        private void left_click(int x, int y) {
            if (is_flag(x, y)) { return; } // if the tile is flagged, do nothing


            // if the player clicks on a mine, he loses
            if (!is_revealed(x, y) && is_mine(x, y)) {

                // Prevents the player from losing on the first click
                if (Program.nbClicks == 0) {
                    while (is_mine(x, y)) {
                        Program.MINES_GRID = shuffle_mines(Program.HEIGHT, Program.WIDTH, Program.NB_MINES);
                    }
                    left_click(x, y); // call the function again to reveal the tile
                    return;
                }

                if (Program.invincibleMode) {
                    set_flag(x, y, !is_flag(x, y));
                    return;
                }

                game_lost(x, y);
                return;
            }

            // if the tile has already been revealed and all adjacent mines flagged, clear the surroundings of the tile
            if (is_revealed(x, y)) {
                clear_surroundings(x, y);
            }

            // if the player clicks on a tile with adjacent mines, reveal the tile
            if (!is_revealed(x, y) && get_nb_adjacent_mines(x, y) > 0) {
                if (Program.nbClicks > 0) { }
                reveal_tile(x, y);
            }

            // if the player clicks on a tile with no adjacent mines, flood fill
            if (!is_revealed(x, y) && get_nb_adjacent_mines(x, y) == 0) {
                flood_fill(x, y);
            }

            Program.nbClicks++;
        }

        /// <summary>
        /// Handle right click on a tile (flagging)
        /// </summary>
        private void right_click(int x, int y) {
            // if the tile is not revealed, change the status of the flag
            // (if not flagged -> flag, if flagged -> unflag)
            if (!is_revealed(x, y)) {
                set_flag(x, y, !is_flag(x, y));
                return;
            }
        }

        /// <summary>
        /// Handle middle click on a tile (clearing surroundings)
        /// </summary>
        private void middle_click(int x, int y) {
            if (is_flag(x, y)) { return; } // if the tile is flagged, do nothing

            // if the tile has already been revealed and all adjacent mines flagged, clear the surroundings of the tile
            if (is_revealed(x, y)) {
                clear_surroundings(x, y);
                return;
            }
        }

        /// <summary>
        /// Set if a tile is flagged or not
        /// </summary>
        private void set_flag(int x, int y, bool flag) {
            Program.FLAGS_GRID[x, y] = flag;

            if (flag) {
                set_tile_state(x, y, Properties.Resources.undiscovered_with_flag);
                Program.nbMinesRemaining--;
            } else {
                set_tile_state(x, y, Properties.Resources.undiscovered);
                Program.nbMinesRemaining++;
            }

            update_status_text();
        }

        /// <summary>
        /// Clear the surroundings of the tile at position (x, y) if all the surrounding mines are flagged
        /// </summary>
        private void clear_surroundings(int x, int y) {
            // if the number of adjacent flags is equal to the number of adjacent mines, clear the surroundings (reveal all the tiles that are not flagged)
            if (get_nb_adjacent_flags(x, y) == get_nb_adjacent_mines(x, y)) {
                for (int i = Math.Max(x - 1, 0); i <= Math.Min(x + 1, Program.HEIGHT - 1); i++) {
                    for (int j = Math.Max(y - 1, 0); j <= Math.Min(y + 1, Program.WIDTH - 1); j++) {
                        if (!is_flag(i, j)) {
                            flood_fill(i, j);
                            reveal_tile(i, j);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Change the sprite of a tile to a given sprite
        /// </summary>
        private void set_tile_state(int x, int y, Bitmap sprite) {
            Button btn = (Button)tlpGrid.GetControlFromPosition(y, x);
            btn.BackgroundImage = sprite;
        }

        /// <summary>
        /// Return if a tile is a mine or not
        /// </summary>
        private bool is_mine(int x, int y) {
            return Program.MINES_GRID[x, y];
        }

        /// <summary>
        /// Return is a tile is flagged or not
        /// </summary>
        private bool is_flag(int x, int y) {
            return Program.FLAGS_GRID[x, y];
        }

        /// <summary>
        /// Return if a tile is revealed or not
        /// </summary>
        private bool is_revealed(int x, int y) {
            return Program.REVEALED_GRID[x, y];
        }

        /// <summary>
        /// Set a tile to a revealed state and set the sprite to the appropriate number of adjacent mines
        /// </summary>
        private void reveal_tile(int x, int y) {
            if (is_revealed(x, y)) { return; }

            if (is_mine(x, y)) {
                game_lost(x, y);
            } else {
                Program.REVEALED_GRID[x, y] = true;
                set_tile_sprite_to_nb_adjacent_mines(x, y);
            }

            if (check_win()) {
                game_won();
            }
        }

        /// <summary>
        /// Handle game lost event and reveal all the mines
        /// </summary>
        private void game_lost(int x, int y) {
            Program.inGame = false;
            Program.gameLost = true;

            // Reveal all the mines (except flags)
            for (int i = 0; i < Program.HEIGHT; i++) {
                for (int j = 0; j < Program.WIDTH; j++) {
                    if (is_mine(i, j) && !is_flag(i, j)) {
                        set_tile_state(i, j, Properties.Resources.discovered_bomb);
                    }

                    if (!is_mine(i, j) && is_flag(i, j)) {
                        set_tile_state(i, j, Properties.Resources.discovered_wrong_flag);
                    }
                }
            }

            // Set the mine that was clicked to a red mine sprite instead of the default one
            // to indicate that it was the mine that killed the player
            set_tile_state(x, y, Properties.Resources.discovered_bomb_red);

            update_status_text();
        }

        /// <summary>
        /// Handle game win event
        /// </summary>
        private void game_won() {
            Program.inGame = false;

            // Reveal all the mines as flags
            for (int i = 0; i < Program.HEIGHT; i++) {
                for (int j = 0; j < Program.WIDTH; j++) {
                    if (is_mine(i, j)) {
                        set_tile_state(i, j, Properties.Resources.undiscovered_with_flag);
                    }
                }
            }

            update_status_text();
        }

        private bool check_win() {
            int count = 0;

            // Count the number of tiles that are not revealed
            for (int i = 0; i < Program.REVEALED_GRID.GetLength(0); i++) {
                for (int j = 0; j < Program.REVEALED_GRID.GetLength(1); j++) {
                    if (!Program.REVEALED_GRID[i, j]) {
                        count++;
                    }
                }
            }

            // If the number of tiles that are not revealed is equal to the number of mines, the player wins
            return count == Program.NB_MINES;
        }


        /// <summary>
        /// Set the tile at position (x, y) to the appropriate sprite depending on the number of adjacent mines
        /// </summary>
        private void set_tile_sprite_to_nb_adjacent_mines(int x, int y) {
            int nbAdjacentMines = get_nb_adjacent_mines(x, y);
            Bitmap[] sprites = new Bitmap[9] {
                Properties.Resources.discovered,
                Properties.Resources.discovered_1,
                Properties.Resources.discovered_2,
                Properties.Resources.discovered_3,
                Properties.Resources.discovered_4,
                Properties.Resources.discovered_5,
                Properties.Resources.discovered_6,
                Properties.Resources.discovered_7,
                Properties.Resources.discovered_8
            };

            set_tile_state(x, y, sprites[nbAdjacentMines]);
        }


        /// <summary>
        /// Return the number of adjacent mines of the tile at position (x, y)
        /// </summary>
        private int get_nb_adjacent_mines(int x, int y) {
            int count = 0;

            for (int i = Math.Max(x - 1, 0); i <= Math.Min(x + 1, Program.HEIGHT - 1); i++) {
                for (int j = Math.Max(y - 1, 0); j <= Math.Min(y + 1, Program.WIDTH - 1); j++) {
                    if (Program.MINES_GRID[i, j]) {
                        count++;
                    }
                }
            }

            return count;
        }
        /// <summary>
        /// Return the number of adjacent flags of the tile at position (x, y)
        /// </summary>
        private int get_nb_adjacent_flags(int x, int y) {
            int count = 0;

            for (int i = Math.Max(x - 1, 0); i <= Math.Min(x + 1, Program.HEIGHT - 1); i++) {
                for (int j = Math.Max(y - 1, 0); j <= Math.Min(y + 1, Program.WIDTH - 1); j++) {
                    if (Program.FLAGS_GRID[i, j]) {
                        count++;
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Recursively reveal all the tiles that are not adjacent to any mine (flood fill algorithm) if the clicked tile is not adjacent to any mine
        /// </summary>
        private void flood_fill(int x, int y) {
            // if (x < 0 || x >= Program.HEIGHT || y < 0 || y >= Program.WIDTH)

            // If the tile is already revealed, do nothing
            if (is_revealed(x, y)) { return; }

            // If the tile is a mine, do nothing
            if (Program.MINES_GRID[x, y]) { return; }

            int numAdjacentMines = get_nb_adjacent_mines(x, y);
            reveal_tile(x, y);

            if (numAdjacentMines == 0) {
                for (int i = Math.Max(x - 1, 0); i <= Math.Min(x + 1, Program.HEIGHT - 1); i++) {
                    for (int j = Math.Max(y - 1, 0); j <= Math.Min(y + 1, Program.WIDTH - 1); j++) {
                        flood_fill(i, j);
                    }
                }
            }
        }

        private void update_status_text() {
            tsslStatus.Text = "Remaining mines: " + Program.nbMinesRemaining;

            if (check_win()) { tsslStatus.Text += " - 😎"; } else if (Program.gameLost) { tsslStatus.Text += " - 😵"; } else { tsslStatus.Text += " - 😊"; }
        }



        private void tsmiNewGame_Click(object sender, EventArgs e) {
            new_game(Program.HEIGHT, Program.WIDTH, Program.NB_MINES);
        }

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
                    new_game(9, 9, 10);
                    break;
                case "Intermediate":
                    new_game(16, 16, 40);
                    break;
                case "Expert":
                    new_game(16, 30, 99);
                    break;
                case "Custom":
                    frmCustomGameSettings settingsForm = Program.settingsForm;
                    settingsForm.ShowDialog();
                    break;
                default:
                    new_game(Program.HEIGHT, Program.WIDTH, Program.NB_MINES);
                    break;
            }
        }
        private void tsmiExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void tsmiAboutMinesweeper_Click(object sender, EventArgs e) {
            String title = "About";
            String message = "This game was made by Alexandre MALFREYT." + Environment.NewLine
                + "It was made for the course \"Développement d'applications avec IHM\" at the IUT d'Orsay." + Environment.NewLine
                + "It is an assignment for the 2nd semester." + Environment.NewLine
                + "The source code is available on GitHub at https://github.com/AlexZeGamer/Minesweeper";

            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
        }

        private void tsmiBiggerTiles_Click(object sender, EventArgs e) {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;

            if (tsmi.Checked) {
                TILE_SIZE = 32;
            } else {
                TILE_SIZE = 16;
            }

            // reload a game with the new size
            new_game(Program.HEIGHT, Program.WIDTH, Program.NB_MINES);
        }

        private void frmMainFrame_KeyUp(object sender, KeyEventArgs e) {
            // If the sequence is completed, enable invincible mode
            if (sequence.IsCompletedBy(e.KeyCode)) {
                MessageBox.Show("INVINCIBLE!!!");
                Program.invincibleMode = true;
            }
        }

        private void tsmiGithub_Click(object sender, EventArgs e) {
            string key = @"htmlfile\shell\open\command";
            RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(key, false);
            // Get the default browser path on the system
            string Default_Browser_Path = ((string)registryKey.GetValue(null, null)).Split('"')[1];

            Process p = new Process();
            p.StartInfo.FileName = Default_Browser_Path;
            p.StartInfo.Arguments = "https://github.com/AlexZeGamer/Minesweeper";
            p.Start();
        }

        private void tsmiHowToPlay_Click(object sender, EventArgs e) {
            String title = "How to play";
            string rules = "Minesweeper is a classic computer game where you need to uncover all the cells on a grid without hitting any mines." + Environment.NewLine
                + Environment.NewLine
                + "Rules:" + Environment.NewLine
                + " - The game board consists of a grid of cells, some of which contain hidden mines." + Environment.NewLine
                + " - Your goal is to reveal all the cells that do not contain mines." + Environment.NewLine
                + " - If you reveal a cell that contains a mine, the game ends, and you lose." + Environment.NewLine
                + " - If you reveal a cell that does not contain a mine, it will display a number indicating the total number of mines in the adjacent cells (including diagonals)." + Environment.NewLine
                + " - If you reveal a cell with no adjacent mines, it will reveal all adjacent cells." + Environment.NewLine
                + " - You can use this information to deduce which cells are safe to reveal." + Environment.NewLine
                + Environment.NewLine
                + "Controls:" + Environment.NewLine
                + "- Left click: reveal a cell" + Environment.NewLine
                + "- Right click: add a flag to a cell" + Environment.NewLine
                + "- Middle click: reveal all adjacent cells if all mines arround are flagged" + Environment.NewLine
                + Environment.NewLine
                + "Good luck and enjoy playing Minesweeper!";

            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(rules, title, buttons, MessageBoxIcon.Information);
        }
    }
}
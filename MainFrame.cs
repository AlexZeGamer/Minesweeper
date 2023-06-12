using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;

namespace Minesweeper {
    public partial class frmMainFrame : Form {

        const int BUTTON_SIZE = 16; // in pixels

        public frmMainFrame() {
            InitializeComponent();
            newGame(Program.HEIGHT, Program.WIDTH, Program.NB_MINES);
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
        public void newGame(int height, int width, int nbMines) {
            Program.inGame = false;
            Program.gameLost = false;

            Program.HEIGHT = height;
            Program.WIDTH = width;
            Program.NB_MINES = nbMines;

            Program.nbMinesRemaining = nbMines;

            Program.REVEALED_GRID = new bool[Program.HEIGHT, Program.WIDTH]; // grid of revealed tiles
            Program.FLAGS_GRID = new bool[Program.HEIGHT, Program.WIDTH]; // grid of flags
            Program.MINES_GRID = shuffleMines(height, width, nbMines); // grid of mines
            createButtonsGrid(height, width); // create the grid of buttons
        }

        /// <summary>
        /// Debug function to print the grid of mines
        /// </summary>
        private string PrintMinesGrid() {
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
        private bool[,] shuffleMines(int height, int width, int nbMines) {
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
        private void createButtonsGrid(int height, int width) {
            Program.inGame = false;
            tsslStatus.Text = "Loading...";

            // creating grid with good dimensions
            tlpGrid.RowCount = height;
            tlpGrid.ColumnCount = width;
            tlpGrid.AutoSize = true;
            tlpGrid.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            tlpGrid.SuspendLayout();

            // empty existing grid if any
            tlpGrid.Controls.Clear();
            
            // adding buttons
            for (int x = 0; x < height; x++) {
                for (int y = 0; y < width; y++) {
                    Button btn = create_button();
                    tlpGrid.Controls.Add(btn, y, x);
                }
            
            }
            tlpGrid.ResumeLayout();

            Program.inGame = true;
            updateStatusText();
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
            button.Size = new Size(BUTTON_SIZE, BUTTON_SIZE);

            // add event handler
            button.MouseUp += new MouseEventHandler(tileClick);

            return button;
        }

        /// <summary>
        /// Handle the click on a tile (left, right or middle click) and call the appropriate functions
        /// </summary>
        private void tileClick(object sender, MouseEventArgs e) {
            // if the game is not running or if the game is over, do nothing
            if (!Program.inGame || Program.gameLost) { return; }

            // get clicked button position
            Button button = (Button)sender;
            int x = tlpGrid.GetRow(button);
            int y = tlpGrid.GetColumn(button);

            switch (e.Button) {
                case MouseButtons.Left:
                    leftClick(x, y);
                    break;

                case MouseButtons.Right:
                    rightClick(x, y);
                    break;

                case MouseButtons.Middle:
                    middleClick(x, y);
                    break;

                default: break;
            }

            updateStatusText();
        }

        /// <summary>
        /// Handle left click on a tile (revealing the tile)
        /// </summary>
        private void leftClick(int x, int y) {
            if (isFlag(x, y)) { return; } // if the tile is flagged, do nothing

            // if the player clicks on a mine, he loses
            if (isMine(x, y)) {
                gameLost(x, y);
                return;
            }

            // if the tile has already been revealed and all adjacent mines flagged, clear the surroundings of the tile
            if (isRevealed(x, y)) {
                clearSurroundings(x, y);
                return;
            }

            // if the player clicks on a tile with adjacent mines, reveal the tile
            if (!isRevealed(x, y) && getNbAdjacentMines(x, y) > 0) {
                revealTile(x, y);
                return;
            }

            // if the player clicks on a tile with no adjacent mines, flood fill
            if (!isRevealed(x, y) && getNbAdjacentMines(x, y) == 0) {
                floodFill(x, y);
                return;
            }
        }

        /// <summary>
        /// Handle right click on a tile (flagging)
        /// </summary>
        private void rightClick(int x, int y) {
            // if the tile is not revealed, change the status of the flag
            // (if not flagged -> flag, if flagged -> unflag)
            if (!isRevealed(x, y)) {
                setFlag(x, y, !isFlag(x, y));
                return;
            }
        }

        /// <summary>
        /// Handle middle click on a tile (clearing surroundings)
        /// </summary>
        private void middleClick(int x, int y) {
            if (isFlag(x, y)) { return; } // if the tile is flagged, do nothing

            // if the tile has already been revealed and all adjacent mines flagged, clear the surroundings of the tile
            if (isRevealed(x, y)) {
                clearSurroundings(x, y);
                return;
            }
        }

        /// <summary>
        /// Set if a tile is flagged or not
        /// </summary>
        private void setFlag(int x, int y, bool flag) {
            Program.FLAGS_GRID[x, y] = flag;

            if (flag) {
                setTileState(x, y, Properties.Resources.undiscovered_with_flag);
                Program.nbMinesRemaining--;
            } else {
                setTileState(x, y, Properties.Resources.undiscovered);
                Program.nbMinesRemaining++;
            }

            updateStatusText();
        }

        /// <summary>
        /// Clear the surroundings of the tile at position (x, y) if all the surrounding mines are flagged
        /// </summary>
        private void clearSurroundings(int x, int y) {
            // if the number of adjacent flags is equal to the number of adjacent mines, clear the surroundings (reveal all the tiles that are not flagged)
            if (getNbAdjacentFlags(x, y) == getNbAdjacentMines(x, y)) {
                for (int i = Math.Max(x - 1, 0); i <= Math.Min(x + 1, Program.HEIGHT - 1); i++) {
                    for (int j = Math.Max(y - 1, 0); j <= Math.Min(y + 1, Program.WIDTH - 1); j++) {
                        if (!isFlag(i, j)) {
                            floodFill(i, j);
                            revealTile(i, j);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Change the sprite of a tile to a given sprite
        /// </summary>
        private void setTileState(int x, int y, Bitmap sprite) {
            Button btn = (Button)tlpGrid.GetControlFromPosition(y, x);
            btn.BackgroundImage = sprite;
        }

        /// <summary>
        /// Return if a tile is a mine or not
        /// </summary>
        private bool isMine(int x, int y) {
            return Program.MINES_GRID[x, y];
        }

        /// <summary>
        /// Return is a tile is flagged or not
        /// </summary>
        private bool isFlag(int x, int y) {
            return Program.FLAGS_GRID[x, y];
        }

        /// <summary>
        /// Return if a tile is revealed or not
        /// </summary>
        private bool isRevealed(int x, int y) {
            return Program.REVEALED_GRID[x, y];
        }

        /// <summary>
        /// Set a tile to a revealed state and set the sprite to the appropriate number of adjacent mines
        /// </summary>
        private void revealTile(int x, int y) {
            if (isRevealed(x, y)) { return; }

            if (isMine(x, y)) {
                gameLost(x, y);
            } else {
                Program.REVEALED_GRID[x, y] = true;
                setTileSpriteToNbAdjacentMines(x, y);
            }

            if (checkWin()) {
                gameWon();
            }
        }

        /// <summary>
        /// Handle game lost event and reveal all the mines
        /// </summary>
        private void gameLost(int x, int y) {
            Program.inGame = false;
            Program.gameLost = true;

            // Reveal all the mines (except flags)
            for (int i = 0; i < Program.HEIGHT; i++) {
                for (int j = 0; j < Program.WIDTH; j++) {
                    if (isMine(i, j) && !isFlag(i, j)) {
                        setTileState(i, j, Properties.Resources.discovered_bomb);
                    }

                    if (!isMine(i, j) && isFlag(i, j)) {
                        setTileState(i, j, Properties.Resources.discovered_wrong_flag);
                    }
                }
            }

            // Set the mine that was clicked to a red mine sprite instead of the default one
            // to indicate that it was the mine that killed the player
            setTileState(x, y, Properties.Resources.discovered_bomb_red);

            updateStatusText();
        }

        /// <summary>
        /// Handle game win event
        /// </summary>
        private void gameWon() {
            Program.inGame = false;

            // Reveal all the mines as flags
            for (int i = 0; i < Program.HEIGHT; i++) {
                for (int j = 0; j < Program.WIDTH; j++) {
                    if (isMine(i, j)) {
                        setTileState(i, j, Properties.Resources.undiscovered_with_flag);
                    }
                }
            }

            updateStatusText();
        }

        private bool checkWin() {
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
        private void setTileSpriteToNbAdjacentMines(int x, int y) {
            int nbAdjacentMines = getNbAdjacentMines(x, y);
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

            setTileState(x, y, sprites[nbAdjacentMines]);
        }


        /// <summary>
        /// Return the number of adjacent mines of the tile at position (x, y)
        /// </summary>
        private int getNbAdjacentMines(int x, int y) {
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
        private int getNbAdjacentFlags(int x, int y) {
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
        private void floodFill(int x, int y) {
            // if (x < 0 || x >= Program.HEIGHT || y < 0 || y >= Program.WIDTH)

            // If the tile is already revealed, do nothing
            if (isRevealed(x, y)) { return; }

            // If the tile is a mine, do nothing
            if (Program.MINES_GRID[x, y]) { return; }

            int numAdjacentMines = getNbAdjacentMines(x, y);
            revealTile(x, y);

            if (numAdjacentMines == 0) {
                for (int i = Math.Max(x - 1, 0); i <= Math.Min(x + 1, Program.HEIGHT - 1); i++) {
                    for (int j = Math.Max(y - 1, 0); j <= Math.Min(y + 1, Program.WIDTH - 1); j++) {
                        floodFill(i, j);
                    }
                }
            }
        }

        private void updateStatusText() {
            tsslStatus.Text = "Remaining mines: " + Program.nbMinesRemaining;

            if (checkWin()) { tsslStatus.Text += " - 😎"; } else if (Program.gameLost) { tsslStatus.Text += " - 😵"; } else { tsslStatus.Text += " - 😊"; }
        }



        private void tsmiNewGame_Click(object sender, EventArgs e) {
            newGame(Program.HEIGHT, Program.WIDTH, Program.NB_MINES);
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
                    newGame(9, 9, 10);
                    break;
                case "Intermediate":
                    newGame(16, 16, 40);
                    break;
                case "Expert":
                    newGame(16, 30, 99);
                    break;
                case "Custom":
                    frmCustomGameSettings settingsForm = Program.settingsForm;
                    settingsForm.ShowDialog();
                    break;
                default:
                    newGame(Program.HEIGHT, Program.WIDTH, Program.NB_MINES);
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
    }
}
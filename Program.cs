namespace Minesweeper
{
    internal static class Program
    {
        // Game settings
        public static int HEIGHT = 9; // number of rows
        public static int WIDTH = 9; // number of columns
        public static int NB_MINES = 10; // number of mines

        // Game variables
        public static bool[,]? MINES_GRID;
        public static bool[,]? FLAGS_GRID;
        public static bool[,]? REVEALED_GRID;
        public static bool inGame;
        public static bool gameLost;
        public static int nbMinesRemaining;
        public static int nbClicks;

        // Forms
        public static frmMainFrame mainForm = new frmMainFrame();
        public static frmCustomGameSettings settingsForm = new frmCustomGameSettings(mainForm);

        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(mainForm);
        }
    }
}
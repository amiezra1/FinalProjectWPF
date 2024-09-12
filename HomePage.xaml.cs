using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FinalProjectWPF.Chess;
using FinalProjectWPF.CountriesProject;
using FinalProjectWPF.FifteenPuzzle;
using FinalProjectWPF.InventorySystem;
using FinalProjectWPF.Painter;
using FinalProjectWPF.PacMan;
using FinalProjectWPF.TicTacToeGame;
using FinalProjectWPF.Snakes;
using FinalProjectWPF.TetrisGame;


namespace FinalProjectWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();

        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = (sender as Image)!;
            image.Opacity = 0.6;
            GameText.Content = (image.Name) switch
            {
                "ChessImg" => "Chess Game",
                "InventorySystemImg" => "Inventory System",
                "PainterImg" => "Painter",
                "PacManImg" => "PacMan Game",
                "TicTacToeImg" => "Tic Tac Toe Game",
                "SnakeImg" => "Snake Game",
                "TetrisImg" => "Tetris Game",
                "CountriesProjectImg" => "Countries Project",
                "FifteenPuzzleGameImg" => "Fifteen Puzzle Game",
                "UserLogo" => "Logo",

                _ => "Please pick a project"
            };
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Image)!.Opacity = 1;
            GameText.Content = "please pick a game";
        }

        private void Chess_Click(object sender, RoutedEventArgs e)
        {
            ChessUI chessUI = new ChessUI();
            PresentationPage presentationPage = new PresentationPage();
            NavigationService.Navigate(presentationPage);
            presentationPage.OnStart(
                "Chess Game", "" +
                "- This is a Chess Game Program.\n" +
                "- The Technologies I used in this project: C# based on WPF Interface, .NET.\n\n" +
                "- This Program allows you to play a full game of chess with all the standard rules.\n" +
                "- You can move pieces by clicking and dragging, and the game will validate your moves.\n" +
                "- It supports player vs player.\n" +
                "- The game includes features like check, checkmate, stalemate, and castling.\n\n" +
                "- To Start the game, click the 'Start Game' button on the main screen.\n" +
                "- To Reset the game, click the 'Restart Game' button at any time.\n" +
                "- To Return to the Home Page, click the chessboard icon at the top-right corner of the window.",

                ChessImg.Source,
                chessUI,
                "Start Game"
            );
            
        }

        private void InventorySystem_Click(object sender, RoutedEventArgs e)
        {
            InventorySystemApp inventorySystemApp = new InventorySystemApp();
            PresentationPage presentationPage = new PresentationPage();
            NavigationService.Navigate(presentationPage);
            presentationPage.OnStart(
                "Inventory System", "" +
                "- This is an Inventory Management Program.\n" +
                "- The Technologies I used in this project: C# based on WPF Interface, .NET, and save the data in json file.\n" +
                "- This Program allows you to manage inventory efficiently with features for adding, editing, and deleting items.\n" +
                "- You can view  through the inventory, track stock levels.\n\n" +
                "- To Start using the system, click the 'Start' button on the main screen.\n" +
                "- To Return to the Home Page, click the home icon at the top-right corner of the window.",

                InventorySystemImg.Source,
                inventorySystemApp
            );
        }

        private void Painter_Click(object sender, RoutedEventArgs e)
        {
            PainterWindow painterWindow = new PainterWindow();
            PresentationPage presentationPage = new PresentationPage();
            NavigationService.Navigate(presentationPage);
            presentationPage.OnStart(
                "Painter", "" +
                "- This is a simple painting application.\n" +
                "- The technologies I used in this project: C# based on WPF Interface, .NET.\n" +
                "- The program allows you to draw on a canvas with different pen colors and sizes.\n" +
                "- You can choose pen colors from a dropdown menu and adjust the pen size.\n\n" +
                "- To start drawing, select a color from the 'Pen Colour' dropdown and adjust the size as needed.\n" +
                "- To clear the canvas,  use an eraser..\n" +
                "- To exit the Painter, click the 'Exit' button located at the top-right corner of the window.",

                PainterImg.Source,
                painterWindow
            );

        }

        private void PacMan_Click(object sender, RoutedEventArgs e)
        {
            PAC_ManGameMainWindow PAC_ManGame = new PAC_ManGameMainWindow();
            PresentationPage presentationPage = new PresentationPage();
            NavigationService.Navigate(presentationPage);
            presentationPage.OnStart(
                "PacMan Game", "" +
                "- This is a Pac-Man game application.\n" +
                "- The technologies I used in this project: C# based on WPF Interface, .NET.\n" +
                "- The game allows you to control Pac-Man and navigate through the maze while avoiding ghosts.\n" +
                "- Collect dots and power-ups to earn points and defeat the ghosts.\n\n" +
                "- To start the game, click the 'Start' button on the main menu.\n" +
                "- Use the arrow keys on your keyboard to control Pac-Man's movement.\n" +
                "- To quit the game, click the 'Exit' button located at the top-right corner of the window.",

                PacManImg.Source,
                PAC_ManGame,
                "Start Game"
            );

        }

        private void TicTacToe_Click(object sender, RoutedEventArgs e)
        {
            TicTacToe TicTacToeGame = new TicTacToe();
            PresentationPage presentationPage = new PresentationPage();
            NavigationService.Navigate(presentationPage);
            presentationPage.OnStart(
                "TicTacToe Game", "" +
                "- This is a Tic-Tac-Toe game application.\n" +
                "- The technologies I used in this project: C# based on WPF Interface, .NET.\n" +
                "- The game allows a player to compete against the computer on a 3x3 grid.\n" +
                "- The player and the computer take turns placing 'X' or 'O' on the grid to try and form a line.\n\n" +
                "- To start a new game, click the 'New Game' button on the main screen.\n" +
                "- The player can click on an empty cell to place their mark.\n" +
                "- The first to form a horizontal, vertical, or diagonal line wins.\n" +
                "- To reset the game, click the 'Reset' button.\n" +
                "- To exit the game, click the 'Exit' button located at the top-right corner of the window.",

                TicTacToeImg.Source,
                TicTacToeGame,
                "Start Game"
            );
        }

        private void Snake_Click(object sender, RoutedEventArgs e)
        {
            SnakeGameWindow snakeGame = new SnakeGameWindow();
            PresentationPage presentationPage = new PresentationPage();
            NavigationService.Navigate(presentationPage);
            presentationPage.OnStart(
                "Snake Game", "" +
                "- This is a Snake game application.\n" +
                "- The technologies I used in this project: C# based on WPF Interface, .NET.\n" +
                "- The game allows the player to control a snake, navigating a grid to eat food and grow longer.\n" +
                "- The goal is to grow the snake as long as possible without hitting the walls or itself.\n\n" +
                "- To start the game, click the 'Start' button on the main menu.\n" +
                "- Use the arrow keys to control the snake's movement.\n" +
                "- The game ends if the snake hits a wall or its own body.\n" +
                "- To restart the game, click the 'Restart' button.\n" +
                "- To exit the game, click the 'Exit' button located at the top-right corner of the window.",

                SnakeImg.Source,
                snakeGame,
                "Start Game"
            );
        }

        private void Tetris_Click(object sender, RoutedEventArgs e)
        {
            TetrisGameWindow tetrisGame = new TetrisGameWindow();
            PresentationPage presentationPage = new PresentationPage();
            NavigationService.Navigate(presentationPage);
            presentationPage.OnStart(
                "Tetris Game", "" +
                "- This is a Tetris game application.\n" +
                "- The technologies I used in this project: C# based on WPF Interface, .NET.\n" +
                "- The game allows the player to control falling blocks (tetrominoes) and fit them together to clear rows.\n" +
                "- The goal is to clear as many rows as possible by completing full lines without gaps.\n\n" +
                "- To start the game, click the 'Start' button on the main menu.\n" +
                "- Use the arrow keys to move and rotate the blocks as they fall.\n" +
                "- The game ends if the blocks stack to the top of the screen.\n" +
                "- To restart the game, click the 'Restart' button.\n" +
                "- To exit the game, click the 'Exit' button located at the top-right corner of the window.",

                TetrisImg.Source,
                tetrisGame,
                "Start Game"
            );

        }

        private void CountriesProject_Click(object sender, RoutedEventArgs e)
        {
            CountriesProjectMainWindow countriesProject = new CountriesProjectMainWindow();
            PresentationPage presentationPage = new PresentationPage();
            NavigationService.Navigate(presentationPage);
            presentationPage.OnStart(
                "Countries Project", "" +
                "- This is a country information application.\n" +
                "- The technologies I used in this project: C# based on WPF Interface, .NET.\n" +
                "- The application provides detailed information about different countries around the world.\n" +
                "- You can view data such as population, capital and more.\n\n" +
                "- To start, select a country from the dropdown list on the main screen.\n" +
                "- The selected country’s details will be displayed in the information section.\n" +
                "- To search for a country, use the search bar at the top of the window.\n" +
                "- To exit the application, click the 'Exit' button located at the top-right corner of the window.",

                CountriesProjectImg.Source,
                countriesProject
            );
        }

        private void FifteenPuzzleGame_Click(object sender, RoutedEventArgs e)
        {
            FifteenPuzzleGame fifteenPuzzleGame = new FifteenPuzzleGame();
            PresentationPage presentationPage = new PresentationPage();
            NavigationService.Navigate(presentationPage);
            presentationPage.OnStart(
                "Fifteen Puzzle Game", "" +
                "- This is a Fifteen Puzzle game application.\n" +
                "- The technologies I used in this project: C# based on WPF Interface, .NET.\n" +
                "- The game consists of a 4x4 grid with numbered tiles that are randomly shuffled.\n" +
                "- The goal is to arrange the tiles in numerical order by sliding them into the empty space.\n\n" +
                "- To start a new game, click the 'New Game' button on the main screen.\n" +
                "- Click on a tile adjacent to the empty space to slide it.\n" +
                "- The game ends when all the tiles are arranged in the correct order.\n" +
                "- To reset the game, click the 'Reset' button.\n" +
                "- To exit the game, click the 'Exit' button located at the top-right corner of the window.",

                FifteenPuzzleGameImg.Source,
                fifteenPuzzleGame,
                "Start Game"
            );

        }

         private void Avatar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
         {
            ContactInfoWindow contactInfoWindow = new ContactInfoWindow();
            contactInfoWindow.Show();
        }

    }
}

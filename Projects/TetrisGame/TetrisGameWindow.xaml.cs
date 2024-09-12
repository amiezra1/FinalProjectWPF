using FinalProjectWPF.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinalProjectWPF.TetrisGame
{

    public partial class TetrisGameWindow : Window
    {
        private readonly ImageSource[] tileImages = new ImageSource[]
{
            new BitmapImage(new Uri("TetrisAssets/TileEmpty.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/TileCyan.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/TileBlue.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/TileOrange.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/TileYellow.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/TileGreen.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/TilePurple.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/TileRed.png", UriKind.Relative))

};
        private readonly ImageSource[] blockImages = new ImageSource[]
        {
            new BitmapImage(new Uri("TetrisAssets/Block-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/Block-I.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/Block-J.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/Block-L.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/Block-O.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/Block-S.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/Block-T.png", UriKind.Relative)),
            new BitmapImage(new Uri("TetrisAssets/Block-Z.png", UriKind.Relative))
        };
        private readonly Image[,] imageControls;
        private readonly int maxDalay = 1000;
        private readonly int minDalay = 100;
        private readonly int dalayDecrease = 25;
        private GameState gameState = new GameState();
        public TetrisGameWindow()
        {
            InitializeComponent();
            imageControls = SetupGameCanvas(gameState.GameGrid);
        }
        private Image[,] SetupGameCanvas(GameGrid grid)
        {
            Image[,] imageControls = new Image[grid.Rows, grid.Columns];
            int cellSize = 25;
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    Image imageControl = new Image
                    {
                        Width = cellSize,
                        Height = cellSize,
                    };

                    Canvas.SetTop(imageControl, (r - 2) * cellSize + 10);
                    Canvas.SetLeft(imageControl, c * cellSize);
                    GameCanvas.Children.Add(imageControl);
                    imageControls[r, c] = imageControl;

                }
            }
            return imageControls;
        }
        private void DrawGrid(GameGrid grid)
        {
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    int id = grid[r, c];
                    imageControls[r, c].Opacity = 1;
                    imageControls[r, c].Source = tileImages[id];
                }
            }
        }
        private void DrawBlock(Block block)
        {
            foreach (Position p in block.TilePositiones())
            {
                imageControls[p.Row, p.Column].Opacity = 1;
                imageControls[p.Row, p.Column].Source = tileImages[block.Id];
            }
        }
        private void DrawNextBlock(BlockQueue blockQueue)
        {
            Block next = blockQueue.NextBlock;
            NextImage.Source = blockImages[next.Id];
        }

        private void DrawHoldBlock(Block holdBlock)
        {
            if (holdBlock == null)
            {
                HoldImage.Source = blockImages[0];
            }
            else
            {
                HoldImage.Source = blockImages[holdBlock.Id];
            }
        }
        private void DrawShadowBlock(Block block)
        {
            int dropDistamce = gameState.BlockDropDistance();

            foreach (Position p in block.TilePositiones())
            {
                imageControls[p.Row + dropDistamce, p.Column].Opacity = 0.28;
                imageControls[p.Row + dropDistamce, p.Column].Source = tileImages[block.Id];
            }
        }

        private void Draw(GameState gameState)
        {
            DrawGrid(gameState.GameGrid);
            DrawShadowBlock(gameState.CurrentBlock);
            DrawBlock(gameState.CurrentBlock);
            DrawNextBlock(gameState.BlockQueue);
            DrawHoldBlock(gameState.HeldBlock);
            ScoreText.Text = $"Score: {gameState.Score}";
        }
        private async Task GameLoop()
        {
            Draw(gameState);
            while (!gameState.GameOver)
            {
                int delay = Math.Max(minDalay, maxDalay - (gameState.Score * dalayDecrease));
                await Task.Delay(delay);
                gameState.MoveBlockDown();
                Draw(gameState);
            }
            GameOverMenu.Visibility = Visibility.Visible;
            FinalScoreText.Text = $"Score: {gameState.Score}";
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameState.GameOver)
            {
                return;
            }
            switch (e.Key)
            {
                case Key.Left:
                    gameState.MoveBlockLeft();
                    break;
                case Key.Right:
                    gameState.MoveBlockRight();
                    break;
                case Key.Down:
                    gameState.MoveBlockDown();
                    break;
                case Key.Up:
                    gameState.RotateBlockCW();
                    break;
                case Key.Z:
                    gameState.RotateBlockCCW();
                    break;
                case Key.C:
                    gameState.HoldBlock();
                    break;
                case Key.Space:
                    gameState.DropBlock();
                    break;
                default:
                    return;
            }
            Draw(gameState);
        }
        private async void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            await GameLoop();
        }
        private async void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            gameState = new GameState();
            GameOverMenu.Visibility = Visibility.Hidden;
            await GameLoop();
        }
    }
}

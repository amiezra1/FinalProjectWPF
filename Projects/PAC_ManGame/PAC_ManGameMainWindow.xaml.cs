using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FinalProjectWPF.PacMan
{
    public partial class PAC_ManGameMainWindow : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();
        bool goLeft, goRight, goDown, goUp;
        bool noLeft, noRight, noDown, noUp;
        int speed = 8;
        Rect pacmanHitBox;
        int ghostSpeed = 10;
        int ghostMoveStep = 160;
        int currentGhostStep;
        int score = 0;
        public PAC_ManGameMainWindow()
        {
            InitializeComponent();
            GameSetUp();
        }
        private void GameSetUp()
        {
            MyCanvas.Focus();
            InitializeGameTimer();
            InitializeImages();
        }

        private void InitializeGameTimer()
        {
            gameTimer.Tick += GameLoop;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Start();
            currentGhostStep = ghostMoveStep;
        }

        private void InitializeImages()
        {
            SetImage(pacman, "pack://application:,,,/Projects/PAC_ManGame/PacManAssets/pacman.jpg");
            SetImage(redGuy, "pack://application:,,,/Projects/PAC_ManGame/PacManAssets/red.jpg");
            SetImage(orangeGuy, "pack://application:,,,/Projects/PAC_ManGame/PacManAssets/orange.jpg");
            SetImage(pinkGuy, "pack://application:,,,/Projects/PAC_ManGame/PacManAssets/pink.jpg");

        }


        private void SetImage(Rectangle rect, string uri)
        {
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(uri));
            rect.Fill = brush;
        }

        private void CanvasKeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyPress(e.Key);
        }

        private void HandleKeyPress(Key key)
        {
            ResetMovementRestrictions();

            if (key == Key.Left && !noLeft)
            {
                SetMovementDirection(ref goLeft, -180);
            }
            else if (key == Key.Right && !noRight)
            {
                SetMovementDirection(ref goRight, 0);
            }
            else if (key == Key.Up && !noUp)
            {
                SetMovementDirection(ref goUp, -90);
            }
            else if (key == Key.Down && !noDown)
            {
                SetMovementDirection(ref goDown, 90);
            }
        }

        private void ResetMovementRestrictions()
        {
            goLeft = goRight = goUp = goDown = false;
            noLeft = noRight = noUp = noDown = false;
        }

        private void SetMovementDirection(ref bool direction, double rotationAngle)
        {
            direction = true;
            pacman.RenderTransform = new RotateTransform(rotationAngle, pacman.Width / 2, pacman.Height / 2);
        }

        private void GameLoop(object sender, EventArgs e)
        {
            UpdateScore();
            MovePacman();
            CheckCollisions();
        }

        private void UpdateScore()
        {
            txtScore.Content = "Score: " + score;
        }

        private void MovePacman()
        {
            if (goRight) MoveHorizontally(speed);
            if (goLeft) MoveHorizontally(-speed);
            if (goUp) MoveVertically(-speed);
            if (goDown) MoveVertically(speed);

            RestrictMovement();
            pacmanHitBox = new Rect(Canvas.GetLeft(pacman), Canvas.GetTop(pacman), pacman.Width, pacman.Height);
        }

        private void MoveHorizontally(int distance)
        {
            Canvas.SetLeft(pacman, Canvas.GetLeft(pacman) + distance);
        }

        private void MoveVertically(int distance)
        {
            Canvas.SetTop(pacman, Canvas.GetTop(pacman) + distance);
        }

        private void RestrictMovement()
        {
            if (goDown && Canvas.GetTop(pacman) + 80 > Application.Current.MainWindow.Height)
            {
                noDown = true;
                goDown = false;
            }
            if (goUp && Canvas.GetTop(pacman) < 1)
            {
                noUp = true;
                goUp = false;
            }
            if (goLeft && Canvas.GetLeft(pacman) - 10 < 1)
            {
                noLeft = true;
                goLeft = false;
            }
            if (goRight && Canvas.GetLeft(pacman) + 70 > Application.Current.MainWindow.Width)
            {
                noRight = true;
                goRight = false;
            }
        }

        private void CheckCollisions()
        {
            foreach (var x in MyCanvas.Children.OfType<Rectangle>())
            {
                Rect hitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                if ((string)x.Tag == "wall") HandleWallCollision(hitBox);
                if ((string)x.Tag == "coin") HandleCoinCollision(x, hitBox);
                if ((string)x.Tag == "ghost") HandleGhostCollision(x, hitBox);
            }

            if (score == 85)
            {
                GameOver("You Win, you collected all of the coins");
            }
        }

        private void HandleWallCollision(Rect hitBox)
        {
            if (goLeft && pacmanHitBox.IntersectsWith(hitBox)) AdjustPacmanPosition(10, 0, ref goLeft, ref noLeft);
            if (goRight && pacmanHitBox.IntersectsWith(hitBox)) AdjustPacmanPosition(-10, 0, ref goRight, ref noRight);
            if (goDown && pacmanHitBox.IntersectsWith(hitBox)) AdjustPacmanPosition(0, -10, ref goDown, ref noDown);
            if (goUp && pacmanHitBox.IntersectsWith(hitBox)) AdjustPacmanPosition(0, 10, ref goUp, ref noUp);
        }

        private void AdjustPacmanPosition(int horizontalAdjustment, int verticalAdjustment, ref bool direction, ref bool restriction)
        {
            Canvas.SetLeft(pacman, Canvas.GetLeft(pacman) + horizontalAdjustment);
            Canvas.SetTop(pacman, Canvas.GetTop(pacman) + verticalAdjustment);
            restriction = true;
            direction = false;
        }

        private void HandleCoinCollision(Rectangle coin, Rect hitBox)
        {
            if (pacmanHitBox.IntersectsWith(hitBox) && coin.Visibility == Visibility.Visible)
            {
                coin.Visibility = Visibility.Hidden;
                score++;
            }
        }

        private void HandleGhostCollision(Rectangle ghost, Rect hitBox)
        {
            if (pacmanHitBox.IntersectsWith(hitBox))
            {
                GameOver("Ghosts got you, click ok to play again");
            }

            MoveGhost(ghost);
        }

        private void MoveGhost(Rectangle ghost)
        {
            if (ghost.Name == "orangeGuy")
            {
                MoveHorizontallyForGhost(ghost, -ghostSpeed);
            }
            else
            {
                MoveHorizontallyForGhost(ghost, ghostSpeed);
            }

            currentGhostStep--;

            if (currentGhostStep < 1)
            {
                currentGhostStep = ghostMoveStep;
                ghostSpeed = -ghostSpeed;
            }
        }

        private void MoveHorizontallyForGhost(Rectangle ghost, int distance)
        {
            Canvas.SetLeft(ghost, Canvas.GetLeft(ghost) + distance);
        }

        private void GameOver(string message)
        {
            gameTimer.Stop();
            MessageBox.Show(message, "The Pac Man Game WPF MOO ICT");
            RestartGame();
        }

        private void RestartGame()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                MainWindow newMainWindow = new MainWindow();
                Application.Current.MainWindow = newMainWindow;
                newMainWindow.Show();
                this.Close();
            });
        }

    }
}
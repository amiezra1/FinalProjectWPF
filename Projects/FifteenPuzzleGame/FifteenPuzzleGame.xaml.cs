using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace FinalProjectWPF.FifteenPuzzle
{

    public partial class FifteenPuzzleGame : Window
    {
        GameLogicPuzzle game;
        GameHistory gameHistory;
        DispatcherTimer timer;
        public FifteenPuzzleGame()
        {
            InitializeComponent();
            game = new GameLogicPuzzle(4);
            gameHistory = new GameHistory();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timer_Tick);
            StartNewGame();
        }
        private Button GetButton(int index)
        {
            return (Button)FindName("button" + index);
        }

        private void RefreshButtonField()
        {
            for (int i = 0; i < 16; i++)
            {
                Button tempButton = GetButton(i);
                tempButton.Content = game.GetNumber(i).ToString();
                String tempString = tempButton.Content.ToString();
                if (tempString == "0") tempButton.Visibility = Visibility.Hidden;
                else tempButton.Visibility = Visibility.Visible;
            }
        }

        private void MenuStartGame_Click(object sender, RoutedEventArgs e)
        {
            StartNewGame();
        }

        private void StartNewGame()
        {
            MenuCancelMyTurn.Visibility = Visibility.Hidden;
            timer.Stop();
            game.Start();
            for (int i = 0; i < 100; i++) game.ShiftRandom();
            RefreshButtonField();
            labelTime.Content = "Timer: 0";
            labelScore.Content = "Steps: 0";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            int position = Convert.ToInt32(((Button)sender).Tag);

            int x, y;
            game.TurnPositionToCoordinates(position, out x, out y);
            if (game.CanShift(x, y))
            {
                gameHistory.History.Push(game.SaveState());
                game.Shift(x, y);

                int currentScore = 0;
                if (int.TryParse(labelScore.Content.ToString().Replace("Steps: ", ""), out currentScore))
                {
                    labelScore.Content = $"Steps: {currentScore + 1}";
                }
                else
                {
                    labelScore.Content = "Steps: 1";
                }

                RefreshButtonField();
                MenuCancelMyTurn.Visibility = Visibility.Visible;
            }

            if (game.CheckWin())
            {
                timer.Stop();
                MessageBox.Show("You win the game!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CancelMyTurn_Click(object sender, RoutedEventArgs e)
        {
            CancelTurn();
        }

        private void CancelTurn()
        {
            if (gameHistory.History.Count > 0)
            {
                game.RestoreState(gameHistory.History.Pop());
                if (gameHistory.History.Count == 0) MenuCancelMyTurn.Visibility = Visibility.Hidden;
                RefreshButtonField();
            }
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            if (int.TryParse(labelTime.Content.ToString().Replace("Timer: ", ""), out int currentTime))
            {
                labelTime.Content = $"Timer: {currentTime + 1}";
            }
            else
            {
                labelTime.Content = "Timer: 1";
            }
        }

        private void DockPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Z) && (e.KeyboardDevice.Modifiers == ModifierKeys.Control)) CancelTurn();
        }

    }
}

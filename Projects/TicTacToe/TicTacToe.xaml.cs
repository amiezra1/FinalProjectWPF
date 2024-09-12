using System.Windows;
using System.Windows.Controls;

namespace FinalProjectWPF.TicTacToeGame
{
    public partial class TicTacToe : Window
    {
        GameTicTacToe GameModel;
        int UserScore = 0;
        int ComputerScore = 0;
        public TicTacToe()
        {
            InitializeComponent();
            GameModel = new GameTicTacToe();
        }

        private async void UserPlay_Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int row = Grid.GetRow(btn);
            int col = Grid.GetColumn(btn);

            if (GameModel.GameBoard[row, col] == 0 && GameModel.CurrentPlayer == 'X')
            {
                GameModel.GameBoard[row, col] = 'X';
                btn.Content = "X";

                if (GameModel.CheckForWin())
                {
                    UserScore++;

                    UserScore1.Text = "Your Score: "+ UserScore.ToString();
                    MessageBox.Show($" You wins!, Computer Score: {ComputerScore} \n Your Score: {UserScore}", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                    ResetGame();
                    return;
                }
                else if (GameModel.IsBoardFull())
                {
                    MessageBox.Show($"It's a draw! \n Computer Score: {ComputerScore} \n Your Score: {UserScore}", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                    ResetGame();
                    return;
                }

                GameModel.ToggleCurrentPlayer();
                txtCurrentPlayer.Text = $"Current Player: {GameModel.ComputerPlayer}";

                await Task.Delay(100); 
                PerformComputerMove();
            }
        }


        private void ResetGame()
        {
            GameModel = new GameTicTacToe();
            txtCurrentPlayer.Text = $"Current Player: {GameModel.CurrentPlayer}";

            foreach (Button btn in MainGrid.Children)
            {
                btn.Content = "";
                btnRestart.Content = "Restart Game"; 
            }
        }
        private async void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(50);

            ResetGame();
            UserScore = 0;
            ComputerScore = 0;
            UserScore1.Text = "Your Score: " + UserScore.ToString();
            ComputerScore1.Text = "Computer Score: " + ComputerScore.ToString();
        }


        private async void PerformComputerMove()
        {
            Random random = new Random();

            await Task.Delay(100);

            int row, col;
            do
            {
                row = random.Next(0, 3);
                col = random.Next(0, 3);
            } while (GameModel.GameBoard[row, col] != 0); 

            GameModel.GameBoard[row, col] = 'O';
            Button btn = (Button)MainGrid.Children.Cast<UIElement>().First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == col);
            btn.Content = "O";

            if (GameModel.CheckForWin())
            {
                ComputerScore++;
                ComputerScore1.Text = "Computer Score: " + ComputerScore.ToString();


                MessageBox.Show($"Computer wins! Computer Score: {ComputerScore} \n Your Score: {UserScore}", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                ResetGame();
            }
            else if (GameModel.IsBoardFull())
            {
                MessageBox.Show($"It's a draw! \n Computer Score: {ComputerScore} \n Your Score: {UserScore}", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                ResetGame();
            }
            else
            {
                GameModel.ToggleCurrentPlayer();
                txtCurrentPlayer.Text = $"Current Player: {GameModel.CurrentPlayer}"; 
            }
        }

    }
}

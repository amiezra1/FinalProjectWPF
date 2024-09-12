using System.Windows;
using System.Windows.Controls;

namespace FinalProjectWPF.Chess
{
    /// <summary>
    /// Interaction logic for GameOverMenu.xaml
    /// </summary>
    public partial class GameOverMenu : UserControl
    {
        public event Action<Option> OptionSelected;
        public GameOverMenu(GameState gameState)
        {
            InitializeComponent();

            Result result = gameState.Result;
            WinnerText.Text = GetWinnerText(result.Winner);
            ReasonText.Text = GetReasonText(result.Reason, gameState.CurrentPlayer);

        }
        private static string GetWinnerText(Player winner)
        {
            return winner switch
            {
                Player.White => "WHITH WINS!",
                Player.Black => "BLACK WINS!",
                _ => "IT'S A DRAW"
            };
        }
        private static string PlayerString(Player player)
        {
            return player switch
            {
                Player.White => "WHITH",
                Player.Black => "BLACK",
                _ => ""
            };
        }
        private static string GetReasonText(EndReason reason, Player currentPlayer)
        {
            return reason switch
            {
                EndReason.Stalemate => $"STALEMATE - {PlayerString(currentPlayer)} CAN'T MOVE",
                EndReason.Checkmate => $"STALEMATE - {PlayerString(currentPlayer)} CAN'T MOVE",
                //In development
                EndReason.FiftyMoveRule => "FIFTY-MOVE-RULE",
                EndReason.InsufficientMaterial => "INSUFFICIENT-MATERIAL",
                EndReason.ThreefoldRepetition => "THREEFOLD-REPETITION",
                _ => ""
            };
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Restart);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Exit);
        }
    }
}

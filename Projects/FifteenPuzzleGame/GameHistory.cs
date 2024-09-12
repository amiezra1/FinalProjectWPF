namespace FinalProjectWPF.FifteenPuzzle
{
    public class GameHistory
    {
        public Stack<GameMemento> History { get; private set; }

        public GameHistory()
        {
            History = new Stack<GameMemento>();
        }
    }
}

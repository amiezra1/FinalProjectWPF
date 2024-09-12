namespace FinalProjectWPF.FifteenPuzzle
{
    public class GameLogicPuzzle
    {
        int[,] field;
        int size, x0, y0;
        Random rand = new Random();

        public GameLogicPuzzle(int size)
        {
            this.size = size;
            field = new int[size, size];
        }

        private int TurnCoordinatesToPosition(int x, int y)
        {
            return 4 * y + x;
        }

        public void TurnPositionToCoordinates(int position, out int x, out int y)
        {
            x = Math.Abs(position % 4);
            y = Math.Abs(position / 4);
        }

        public void Start()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    field[i, j] = TurnCoordinatesToPosition(i, j) + 1;

            field[3, 3] = 0;
            x0 = 3;
            y0 = 3;
        }

        public int GetNumber(int position)
        {
            int x, y;
            TurnPositionToCoordinates(position, out x, out y);

            if ((x > -1) && (x < 4) && (y > -1) && (y < 4)) return field[x, y];
            else return 0;
        }

        public bool CanShift(int x, int y)
        {
            if (((Math.Abs(x0 - x) < 2) && (y0 - y == 0)) || ((x0 - x == 0) && (Math.Abs(y0 - y) < 2)))
                return true;
            else return false;
        }

        public void Shift(int x, int y)
        {
            field[x0, y0] = field[x, y];
            field[x, y] = 0;
            x0 = x;
            y0 = y;
        }

        public void ShiftRandom()
        {
            int move = rand.Next(4), x = x0, y = y0;

            if (move == 0) x = Math.Abs(x - 1) % 4;
            else if (move == 1) x = Math.Abs(x + 1) % 4;
            else if (move == 2) y = Math.Abs(y - 1) % 4;
            else y = Math.Abs(y + 1) % 4;

            if (CanShift(x, y)) Shift(x, y);
        }

        public bool CheckWin()
        {
            if (field[3, 3] != 0) return false;
            else return CheckEachPosition();
        }

        private bool CheckEachPosition()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (
                        (field[i, j] != TurnCoordinatesToPosition(i, j) + 1) &&
                        (((i != 3) || (j != 3)))
                       )
                        return false;
            return true;
        }

        public GameMemento SaveState()
        {
            return new GameMemento(field, x0, y0);
        }

        public void RestoreState(GameMemento memento)
        {
            this.field = memento.Field;
            this.x0 = memento.x0;
            this.y0 = memento.y0;
        }
    }



}

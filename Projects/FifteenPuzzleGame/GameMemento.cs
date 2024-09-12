using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectWPF.FifteenPuzzle
{
    public class GameMemento
    {
        public int[,] Field { get; private set; }
        public int x0 { get; private set; }
        public int y0 { get; private set; }

        public GameMemento(int[,] field, int x0, int y0)
        {
            Field = new int[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    Field[i, j] = field[i, j];

            this.x0 = x0;
            this.y0 = y0;
        }
    }
}

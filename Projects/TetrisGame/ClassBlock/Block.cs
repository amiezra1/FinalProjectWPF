using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectWPF.TetrisGame
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position Startoffset { get; }
        public abstract int Id { get; }
        private int rotationState;
        private Position offset;
        public Block()
        {
            offset = new Position(Startoffset.Row, Startoffset.Column);
        }
        public IEnumerable<Position> TilePositiones()
        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        public void RotateCW()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }
        public void RotateCCW()
        {
            if (rotationState == 0)
            {
                rotationState = (rotationState - 1);
            }
            else
            {
                rotationState--;
            }
        }

        public void Move (int rows, int columns)
        {

            offset.Row += rows;
            offset.Column += columns;
        }
        public void Reset()
        {
            rotationState = 0;
            offset.Row = Startoffset.Row;
            offset.Column = Startoffset.Column;
        }

    }
}

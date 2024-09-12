namespace FinalProjectWPF.Snakes
{
    public class Snake
    {
        public List<Point> Body { get; private set; }
        public Point Head => Body[Body.Count-1];
        private Directions direction;

        public Snake(int x, int y)
        {
            Body = new List<Point> { new Point(x, y) };
            direction = Directions.Right;
        }

        public void Move()
        {
            Point newHead = new Point(Head.X, Head.Y);

            switch (direction)
            {
                case Directions.Up:
                    newHead.Y--;
                    break;
                case Directions.Down:
                    newHead.Y++;
                    break;
                case Directions.Left:
                    newHead.X--;
                    break;
                case Directions.Right:
                    newHead.X++;
                    break;
            }

            Body.Add(newHead);
            Body.RemoveAt(0);
        }

        public void Grow()
        {
            Point lastPoint = Body[Body.Count - 1];
            Body.Add(new Point(lastPoint.X, lastPoint.Y));
        }

        public void ChangeDirection(Directions newDirection)
        {
            if ((direction == Directions.Up && newDirection != Directions.Down) ||
                (direction == Directions.Down && newDirection != Directions.Up) ||
                (direction == Directions.Left && newDirection != Directions.Right) ||
                (direction == Directions.Right && newDirection != Directions.Left))
            {
                direction = newDirection;
            }
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

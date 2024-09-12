namespace FinalProjectWPF.Snakes
{
    public enum Directions { Up, Down, Left, Right }
    public enum CellState { Empty, Snake, Apple }

    internal class SnakeGame
    {

        private Snake snake;
        private Apple apple;
        private int width;
        private int height;
        private Random random;
        public bool GameOver { get; private set; }

        public int Score { get; private set; }

        public SnakeGame(int width, int height)
        {
            this.width = width;
            this.height = height;
            ResetGame();
        }
        public void ResetGame()
        {
            snake = new Snake(width / 2, height / 2);
            random = new Random();
            GenerateApple();
            Score = 0;
            GameOver = false;
        }

        public void Update()
        {
            if (GameOver) return;

            snake.Move();

            if (snake.Head.X == apple.X && snake.Head.Y == apple.Y)
            {
                snake.Grow();
                GenerateApple();
                Score++;
            }

            if (IsGameOver())
            {
                GameOver = true;
            }
        }

        public void ChangeDirection(Directions direction)
        {
            snake.ChangeDirection(direction);
        }

        public CellState GetCellState(int x, int y)
        {
            if (snake.Body.Any(p => p.X == x && p.Y == y))
                return CellState.Snake;
            if (apple.X == x && apple.Y == y)
                return CellState.Apple;
            return CellState.Empty;
        }



        private void GenerateApple()
        {
            do
            {
                apple = new Apple(random.Next(width), random.Next(height));
            } while (snake.Body.Any(p => p.X == apple.X && p.Y == apple.Y));
        }




        private bool IsGameOver()
        {
            bool outOfBounds = snake.Head.X < 0 || snake.Head.X >= width || snake.Head.Y < 0 || snake.Head.Y >= height;

            bool collidesWithBody = false;
            for (int i = 0; i < snake.Body.Count - 2; i++)
            {
                if (snake.Body[i].X == snake.Head.X && snake.Body[i].Y == snake.Head.Y)
                {
                    collidesWithBody = true;
                    break;
                }
            }

            return outOfBounds || collidesWithBody;
        }


    }
}

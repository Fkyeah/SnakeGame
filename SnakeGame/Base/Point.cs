using System;

namespace SnakeGame.Base
{
    public class Point
    {
        public Point() { }

        public Point(int x, int y, char sym)
        {
            X = x;
            Y = y;
            Symbol = sym;
        }

        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
            Symbol = p.Symbol;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public char Symbol { get; set; }

        private const char DEFAULT_SYMBOL = ' ';
        
        public void Move(int offset, Direction direction)
        {
            switch (direction)
            {
                case Direction.RIGHT:
                    X += offset;
                    break;
                case Direction.LEFT:
                    X -= offset;
                    break;
                case Direction.UP:
                    Y -= offset;
                    break;
                case Direction.DOWN:
                    Y += offset;
                    break;
                default:
                    throw new NotImplementedException("Actions for this direction have not been implemented");
            }
        }

        public bool IsHit(Point p) => p.X == X && p.Y == Y;

        public void Clear()
        {
            Symbol = DEFAULT_SYMBOL;
            Draw();
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }
    }
}

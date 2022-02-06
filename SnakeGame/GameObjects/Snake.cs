using SnakeGame.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame.GameObjects
{
    class Snake : Figure
    {
        public Snake(Point tail, int lenght, Direction direction)
        {
            _pointList = new List<Point>();
            for (int i = 0; i < lenght; i++)
            {
                Point p = new(tail);
                p.Move(i, direction);
                _pointList.Add(p);
            }
        }

        private Direction _direction;

        internal void Move()
        {
            Point tail = _pointList.First();
            _pointList.Remove(tail);
            Point head = GetNextPoint();
            _pointList.Add(head);
            tail.Clear();
            head.Draw();
        }

        public Point GetNextPoint()
        {
            Point head = _pointList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, _direction);
            return nextPoint;
        }

        public bool IsHitTail()
        {
            var head = _pointList.Last();
            for (int i = 0; i < _pointList.Count - 2; i++)
            {
                if (head.IsHit(_pointList[i]))
                    return true;
            }
            return false;
        }

        public bool CheckPositionFood(Point food)
        {
            for (int i = 0; i < _pointList.Count; i++)
            {
                if (food.IsHit(_pointList[i]))
                    return true;
            }
            return false;
        }

        public void GetDirection(ConsoleKey Key)
        {
            if (Key == ConsoleKey.LeftArrow && _direction != Direction.RIGHT)
                _direction = Direction.LEFT;
            else if (Key == ConsoleKey.RightArrow && _direction != Direction.LEFT)
                _direction = Direction.RIGHT;
            else if (Key == ConsoleKey.UpArrow && _direction != Direction.DOWN)
                _direction = Direction.UP;
            else if (Key == ConsoleKey.DownArrow && _direction != Direction.UP)
                _direction = Direction.DOWN;
            else if (Key == ConsoleKey.Escape)
                Environment.Exit(0);
            else if (Key == ConsoleKey.F10)
                Console.ReadKey();
        }

        public bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.Symbol = head.Symbol;
                _pointList.Add(food);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

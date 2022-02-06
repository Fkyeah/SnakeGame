using SnakeGame.Base;
using System.Collections.Generic;

namespace SnakeGame.GameSpace
{
    public class Walls : Figure
    {
        public Walls(int lenght, int weight)
        {
            _walls = new List<Figure>();
            HorizontalLine LeftLine = new(2, 0, weight - 1, WALL_SYMBOL);
            HorizontalLine RightLine = new(lenght - 2, 0, weight - 1, WALL_SYMBOL);
            VerticalLine UpLine = new(2, lenght - 2, 0, WALL_SYMBOL);
            VerticalLine DownLine = new(2, lenght - 2, weight - 1, WALL_SYMBOL);
            _walls.Add(LeftLine);
            _walls.Add(RightLine);
            _walls.Add(UpLine);
            _walls.Add(DownLine);
        }

        private List<Figure> _walls;
        private const char WALL_SYMBOL = '+';

        public new void Draw()
        {
            foreach (var wall in _walls)
            {
                wall.Draw();
            }
        }

        internal bool HitinWall(Figure figure)
        {
            foreach (var wall in _walls)
            {
                if (wall.IsHit(figure))
                    return true;
            }
            return false;
        }

    }
}

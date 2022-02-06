using SnakeGame.Base;
using System.Collections.Generic;

namespace SnakeGame.GameSpace
{
    public class HorizontalLine : Figure
    {
        public HorizontalLine(int x, int yUp, int yDown, char symbol)
        {
            _pointList = new List<Point>();
            for (int y = yUp; y <= yDown; y++)
            {
                Point p = new(x, y, symbol);
                _pointList.Add(p);
            }
        }
    }
}

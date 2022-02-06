using SnakeGame.Base;
using System.Collections.Generic;

namespace SnakeGame.GameSpace
{
    class VerticalLine : Figure
    {
        public VerticalLine(int xLeft, int xRight, int y, char sym)
        {
            _pointList = new List<Point>();
            for (int x = xLeft; x <= xRight; x++)
            {
                Point p = new(x, y, sym);
                _pointList.Add(p);
            }
        }
    }
}

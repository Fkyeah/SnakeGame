using System.Collections.Generic;

namespace SnakeGame.Base
{
    public class Figure
    {
        protected List<Point> _pointList;
        public void Draw()
        {
            foreach (Point p in _pointList)
            {
                p.Draw();
            }
        }
        internal bool IsHit(Figure figure)
        {
            foreach (var p in _pointList)
            {
                if (figure.IsHit(p))
                    return true;
            }
            return false;
        }
        private bool IsHit(Point point)
        {
            foreach (var p in _pointList)
            {
                if (p.IsHit(point))
                    return true;
            }
            return false;
        }
    }
}

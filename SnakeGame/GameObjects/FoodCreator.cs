using SnakeGame.Base;
using System;

namespace SnakeGame.GameObjects
{
    public class FoodCreator
    {
        public FoodCreator(int mapX, int mapY, char symbol)
        {
            _mapX = mapX;
            _mapY = mapY;
            _symbol = symbol;
        }

        private readonly int _mapX;
        private readonly int _mapY;
        private readonly char _symbol;
        private readonly Random _random = new();

        public Point CreateFood()
        {
            int x = _random.Next(3, _mapX - 3);
            int y = _random.Next(2, _mapY - 3);
            return new Point(x, y, _symbol);
        }

    }
}

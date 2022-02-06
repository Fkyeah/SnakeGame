using SnakeGame.Base;
using SnakeGame.GameObjects;
using SnakeGame.GameSpace;
using SnakeGame.Menu;
using System;
using System.Threading;

namespace SnakeGame
{
    class Program
    {
        private static int _windowHeigth = 28;
        private static int _windowWidth = 102;
        private static int _gameMapHeigth = _windowHeigth - 3;
        private static int _gameMapWidth = _windowWidth - 2;
        private static int _startPositionX = 5;
        private static int _startPositionY = 4;
        private static Direction _startDirection = Direction.RIGHT;
        private static char _eatSymbol = '$';
        private static char _snakeSymbol = '*';
        private static int _snakeLength = 5;

        static void Main(string[] args)
        {
            int Score = 0;
            Console.SetWindowSize(_windowWidth, _windowHeigth);
            Console.SetBufferSize(_windowWidth, _windowHeigth);
            Console.CursorVisible = false;

            Walls walls = new(_windowWidth, _windowHeigth - 1);
            walls.Draw();

            GameMenu GameParams = new();

            Point p = new(_startPositionX, _startPositionY, _snakeSymbol);
            Snake snake = new(p, _snakeLength, _startDirection);

            FoodCreator foodCreator = new(_gameMapWidth, _gameMapHeigth, _eatSymbol);
            Point food = foodCreator.CreateFood();

            snake.Draw();
            food.Draw();

            while (true)
            {
                GameParams.WriteMenu();
                GameParams.WriteScore(Score);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.GetDirection(key.Key);
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    while (snake.CheckPositionFood(food))
                    {
                        food = foodCreator.CreateFood();
                    }
                    food.Draw();
                    Score++;
                    GameParams.WriteScore(Score);
                }
                snake.Draw();

                if (snake.IsHitTail() || walls.HitinWall(snake))
                {
                    GameParams.WriteGameIsOver(Score);
                    break;
                }
                else
                    Thread.Sleep(100);

                snake.Move();
            }

            Console.ReadLine();
        }
    }
}

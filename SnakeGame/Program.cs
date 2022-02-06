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
        static void Main(string[] args)
        {
            int Score = 0;
            Console.SetWindowSize(102, 28);
            Console.SetBufferSize(102, 28);
            Console.CursorVisible = false;
            Walls walls = new Walls(102, 27);
            walls.Draw();
            GameMenu GameParams = new GameMenu();
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 5, Direction.RIGHT);
            FoodCreator foodCreator = new FoodCreator(100, 25, '$');
            Point food = foodCreator.CreateFood();
            Point food2 = foodCreator.CreateFood();
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

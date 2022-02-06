using System;

namespace SnakeGame.Menu
{
    public class GameMenu
    {
        public void WriteGameIsOver(int Count)
        {
            Console.Clear();
            Console.SetCursorPosition(46, 11);
            Console.WriteLine("GAME OVER");
            Console.SetCursorPosition(44, 10);
            Console.WriteLine("Total Score: " + Count);
            Console.SetCursorPosition(42, 12);
            Console.WriteLine("Press Enter to Exit");
        }
        public void WriteScore(int Count)
        {
            Console.SetCursorPosition(2, 27);
            Console.Write("Total Score: " + Count);
        }
        public void WriteMenu()
        {
            Console.SetCursorPosition(40, 27);
            Console.Write("Press F10 to Pause");
            Console.SetCursorPosition(84, 27);
            Console.Write("Press Esc to Exit");

        }
    }
}

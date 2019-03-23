using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    class Program
    {
        static void Main(string[] args)
        {



            int consoleWidth = 81;
            int consoleHeight = 41;
            ConsoleKeyInfo consoleKey;
            Console.SetWindowSize(1, 1);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetBufferSize(200 + consoleWidth, 100 + consoleHeight);
            Console.SetWindowSize(consoleWidth, consoleHeight);
            //            Console.SetWindowSize(consoleWidth, consoleHeight);
            //            Console.WriteLine("BufferHeight : {0}", Console.BufferHeight);
            //            Console.WriteLine("BufferWidth  : {0}", Console.BufferWidth);
            //            Console.WriteLine("WindowsTop   : {0}", Console.WindowTop);
            //            Console.WriteLine("WindowsLeft  : {0}", Console.WindowLeft);
            //            Console.ReadKey();
            //            Console.Clear();
            //            Console.SetWindowSize(1, 1);
            for (int i = 0 + consoleHeight / 2; i < Console.BufferHeight - consoleHeight / 2; i++)
            {
                for (int j = 0 + consoleWidth / 2; j < Console.BufferWidth - consoleWidth / 2; j++)
                {
                    if (j % 2 < 1 && i % 2 < 1)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.ForegroundColor = (ConsoleColor)SingletonRandom.Instance.Next(0, Enum.GetValues(typeof(ConsoleColor)).Length);
                        Console.BackgroundColor = (ConsoleColor)SingletonRandom.Instance.Next(0, Enum.GetValues(typeof(ConsoleColor)).Length);
                        //Console.Write("\u0471");
                        Console.Write("\u24c8");
                    }
                }
            }
            Console.SetWindowPosition((Console.BufferWidth - Console.WindowWidth) / 2, (Console.BufferHeight - Console.WindowHeight) / 2);
            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
            Console.CursorVisible = true;
            do
            {
                consoleKey = Console.ReadKey(true);
                switch (consoleKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (Console.WindowLeft > 0)
                        {
                            Console.SetWindowPosition(Console.WindowLeft - 1, Console.WindowTop);
                            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (Console.WindowTop > 0)
                        {
                            Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop - 1);
                            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (Console.WindowLeft < (Console.BufferWidth - Console.WindowWidth))
                        {
                            Console.SetWindowPosition(Console.WindowLeft + 1, Console.WindowTop);
                            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (Console.WindowTop < (Console.BufferHeight - Console.WindowHeight))
                        {
                            Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop + 1);
                            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                        }
                        break;
                }
            }
            while (consoleKey.Key != ConsoleKey.Escape);  // end do-while
        }
    }
}

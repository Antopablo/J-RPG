using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;

namespace J_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ConsoleKeyInfo consoleKey;
            int consoleWidth = 81;
            int consoleHeight = 41;
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(200 + consoleWidth, 100 + consoleHeight);
            Console.SetWindowSize(consoleWidth, consoleHeight);

            char[,] test = new char[201, 101];
            for (int j = 0; j < test.GetLength(1); j++)
            {
                for (int i = 0; i < test.GetLength(0); i++)
                {
                    test[i, j] = ((j + 1)%2 == 1) ? '-' : '°';
                }
            }
            
            StringBuilder mapStringBuilder = new StringBuilder();
            for (int j = 0; j < Console.BufferHeight; j++)
            {
                for (int i = 0; i < Console.BufferWidth; i++)
                {
                    if (!(i < consoleWidth / 2) && (i < Console.BufferWidth - consoleWidth / 2) && (!(j < consoleHeight / 2) && (j < Console.BufferHeight - consoleHeight / 2)))
                    {
                        mapStringBuilder.Append(test[i - (consoleWidth / 2), j - (consoleHeight / 2)]);
                    }
                    else
                    {
                        if (!(i == Console.BufferWidth - 1 && j == Console.BufferHeight - 1))
                        {
                            mapStringBuilder.Append(' ');
                        }
                    }
                }
            }

            Console.Write(mapStringBuilder.ToString());
            Console.SetWindowPosition((Console.BufferWidth - Console.WindowWidth) / 2, (Console.BufferHeight - Console.WindowHeight) / 2);
            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
            Console.Write("@");
            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
            Console.CursorVisible = false;
            do
            {
                consoleKey = Console.ReadKey(true);
                switch (consoleKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (Console.WindowLeft > 0)
                        {
                            Console.Write(test[Console.CursorLeft - Console.WindowWidth / 2, Console.CursorTop - Console.WindowHeight / 2].ToString());
                            Console.SetWindowPosition(Console.WindowLeft - 1, Console.WindowTop);
                            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                            Console.Write("@");
                            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (Console.WindowTop > 0)
                        {
                            Console.Write(test[Console.CursorLeft - Console.WindowWidth / 2, Console.CursorTop - Console.WindowHeight / 2].ToString());
                            Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop - 1);
                            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                            Console.Write("@");
                            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (Console.WindowLeft < (Console.BufferWidth - Console.WindowWidth))
                        {
                            Console.Write(test[Console.CursorLeft - Console.WindowWidth / 2, Console.CursorTop - Console.WindowHeight / 2].ToString());
                            Console.SetWindowPosition(Console.WindowLeft + 1, Console.WindowTop);
                            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                            Console.Write("@");
                            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (Console.WindowTop < (Console.BufferHeight - Console.WindowHeight))
                        {
                            Console.Write(test[Console.CursorLeft - Console.WindowWidth / 2, Console.CursorTop - Console.WindowHeight / 2].ToString());
                            Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop + 1);
                            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                            Console.Write("@");
                            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                        }
                        break;
                }
            }
            while (consoleKey.Key != ConsoleKey.Escape);

          
          
        }
    }
}

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

            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(1, 1);
            int consoleWidth = 101;
            int consoleHeight = 51;
            Console.SetBufferSize(500 + consoleWidth, 180 + consoleHeight);
            Console.SetWindowSize(consoleWidth, consoleHeight);
            ConsoleKeyInfo consoleKey;

            bool wallsCollision;

            char[] walls = new char[] { '☼', '╣', '║', '╗', '╝', '╚', '╔', '╩', '╦', '╠', '═', '╬' };

            char[][] worldMap = new char[501][];
            for (int i = 0; i < worldMap.GetLength(0); i++)
            {
                worldMap[i] = new char[181];
            }

            string path = @"..\..\Maps\";
            DataContractJsonSerializer dataContractJsonSerializer;
            Stream stream = new StreamReader(path + "WorldMap.json").BaseStream;
            dataContractJsonSerializer = new DataContractJsonSerializer(typeof(char[][]));
            worldMap = (char[][])dataContractJsonSerializer.ReadObject(stream);
            stream.Close();

            //for (int j = 99; j > 80; j--)
            //{
            //    for (int i = 232; i < 269; i++)
            //    {
            //        test[i][j] = test[i][j - 1];
            //        test[i][j - 1] = test[231][100];
            //    }
            //}

            //for (int j = 0; j < test[0].Length; j++)
            //{
            //    for (int i = 0; i < test.Length; i++)
            //    {
            //        if (test[i][j] == '-')
            //        {
            //            test[i][j] = test[7][3];
            //        }
            //        if (test[i][j] == ':')
            //        {
            //            test[i][j] = test[6][4];
            //        }
            //        if (test[i][j] == '$')
            //        {
            //            test[i][j] = test[43][1];
            //        }
            //    }
            //}

            //string line = "";
            //int compteur = 0;
            //StreamReader rStream = new StreamReader(path + "map.txt");
            //while (line != null)
            //{
            //    line = rStream.ReadLine();
            //    if (line != null)
            //    {
            //        for (int i = 0; i < line.Length; i++)
            //        {
            //            test[i][compteur] = line[i];
            //        }
            //        compteur++;
            //    }
            //}

            //path = @"..\..\Maps\";
            //stream = new StreamWriter(path + "WorldMap.json").BaseStream;
            //dataContractJsonSerializer = new DataContractJsonSerializer(typeof(char[][]));
            //dataContractJsonSerializer.WriteObject(stream, test);
            //stream.Close();

            StringBuilder mapStringBuilder = new StringBuilder();
            for (int j = 0; j < Console.BufferHeight; j++)
            {
                for (int i = 0; i < Console.BufferWidth; i++)
                {
                    if (!(i < consoleWidth / 2) && (i < Console.BufferWidth - consoleWidth / 2) && (!(j < consoleHeight / 2) && (j < Console.BufferHeight - consoleHeight / 2)))
                    {
                        mapStringBuilder.Append(worldMap[i - (consoleWidth / 2)][j - (consoleHeight / 2)]);
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


            //Console.SetWindowPosition((Console.BufferWidth - Console.WindowWidth) / 2, (Console.BufferHeight - Console.WindowHeight) / 2 + 17);
            //Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
            Console.SetCursorPosition(Console.BufferWidth / 2, Console.BufferHeight / 2 + 17);
            Console.SetWindowPosition(Console.CursorLeft - Console.WindowWidth / 2, Console.CursorTop - Console.WindowHeight / 2);
            Console.Write("@");
            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
            Console.CursorVisible = false;
            do
            {
                int actualLeftCursor = Console.CursorLeft;
                int actualTopCursor = Console.CursorTop;
                wallsCollision = false;
                consoleKey = Console.ReadKey(true);
                switch (consoleKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        //case ConsoleKey.Q:
                        if (Console.WindowLeft > 0)
                        {
                            for (int i = 0; i < walls.Length; i++)
                            {
                                wallsCollision = wallsCollision || (worldMap[Console.CursorLeft - 1 - Console.WindowWidth / 2][Console.CursorTop - Console.WindowHeight / 2] == walls[i]);
                            }
                            if (!wallsCollision)
                            {
                                Console.Write(worldMap[Console.CursorLeft - Console.WindowWidth / 2][Console.CursorTop - Console.WindowHeight / 2].ToString());
                                Console.SetWindowPosition(Console.WindowLeft - 1, Console.WindowTop);
                                Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                                Console.Write("@");
                                Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        //case ConsoleKey.Z:
                        if (Console.WindowTop > 0)
                        {
                            for (int i = 0; i < walls.Length; i++)
                            {
                                wallsCollision = wallsCollision || (worldMap[Console.CursorLeft - Console.WindowWidth / 2][Console.CursorTop - 1 - Console.WindowHeight / 2] == walls[i]);
                            }
                            if (!wallsCollision)
                            {
                                Console.Write(worldMap[Console.CursorLeft - Console.WindowWidth / 2][Console.CursorTop - Console.WindowHeight / 2].ToString());
                                Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop - 1);
                                Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                                Console.Write("@");
                                Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                            }
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        //case ConsoleKey.D:
                        if (Console.WindowLeft < (Console.BufferWidth - Console.WindowWidth))
                        {
                            for (int i = 0; i < walls.Length; i++)
                            {
                                wallsCollision = wallsCollision || (worldMap[Console.CursorLeft + 1 - Console.WindowWidth / 2][Console.CursorTop - Console.WindowHeight / 2] == walls[i]);
                            }
                            if (!wallsCollision)
                            {
                                Console.Write(worldMap[Console.CursorLeft - Console.WindowWidth / 2][Console.CursorTop - Console.WindowHeight / 2].ToString());
                                Console.SetWindowPosition(Console.WindowLeft + 1, Console.WindowTop);
                                Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                                Console.Write("@");
                                Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                            }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        //case ConsoleKey.S:
                        if (Console.WindowTop < (Console.BufferHeight - Console.WindowHeight))
                        {
                            for (int i = 0; i < walls.Length; i++)
                            {
                                wallsCollision = wallsCollision || (worldMap[Console.CursorLeft - Console.WindowWidth / 2][Console.CursorTop + 1 - Console.WindowHeight / 2] == walls[i]);
                            }
                            if (!wallsCollision)
                            {
                                Console.Write(worldMap[Console.CursorLeft - Console.WindowWidth / 2][Console.CursorTop - Console.WindowHeight / 2].ToString());
                                Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop + 1);
                                Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                                Console.Write("@");
                                Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                            }
                        }
                        break;
                    case ConsoleKey.S:
                        if ((consoleKey.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control)
                        {
                            path = @"..\..\Maps\";
                            stream = new StreamWriter(path + "WorldMap.json").BaseStream;
                            dataContractJsonSerializer = new DataContractJsonSerializer(typeof(char[][]));
                            dataContractJsonSerializer.WriteObject(stream, worldMap);
                            stream.Close();
                        }
                        else
                        {
                            worldMap[actualLeftCursor - Console.WindowWidth / 2][actualTopCursor - Console.WindowHeight / 2] = consoleKey.KeyChar;
                            Console.Write(consoleKey.KeyChar);
                        }
                        break;
                    default:
                        worldMap[actualLeftCursor - Console.WindowWidth / 2][actualTopCursor - Console.WindowHeight / 2] = consoleKey.KeyChar;
                        Console.Write(consoleKey.KeyChar);
                        break;
                }
            }
            while (consoleKey.Key != ConsoleKey.Escape);  // end do-while



        }
    }
}

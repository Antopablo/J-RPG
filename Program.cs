using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
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
                    case ConsoleKey.T:
                        if ((consoleKey.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control)
                        {
                            string[] test = new string[worldMap[0].Length];
                            for (int j = 0; j < worldMap[0].Length; j++)
                            {
                                string line = "";
                                for (int i = 0; i < worldMap.Length; i++)
                                {
                                    line += worldMap[i][j];
                                }
                                test[j] = line;
                            }
                            string textToWrite = test[0];
                            for (int j = 1; j < worldMap[0].Length; j++)
                            {
                                textToWrite += "\r\n" + test[j];
                            }
                            path = @"..\..\Maps\";
                            StreamWriter streamWriter = new StreamWriter(path + "WorldMap.txt");
                            streamWriter.Write(textToWrite);
                            streamWriter.Close();
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
/*
// This example demonstrates the Console.WindowLeft and
//                               Console.WindowTop properties.
using System;
using System.Text;
using System.IO;
//
class Sample
{
    public static int saveBufferWidth;
    public static int saveBufferHeight;
    public static int saveWindowHeight;
    public static int saveWindowWidth;
    public static bool saveCursorVisible;
    //
    public static void Main()
    {
        string m1 = "1) Press the cursor keys to move the console window.\n" +
                    "2) Press any key to begin. When you're finished...\n" +
                    "3) Press the Escape key to quit.";
        string g1 = "+----";
        string g2 = "|    ";
        string grid1;
        string grid2;
        StringBuilder sbG1 = new StringBuilder();
        StringBuilder sbG2 = new StringBuilder();
        ConsoleKeyInfo cki;
        int y;
        //
        try
        {
            saveBufferWidth = Console.BufferWidth;
            saveBufferHeight = Console.BufferHeight;
            saveWindowHeight = Console.WindowHeight;
            saveWindowWidth = Console.WindowWidth;
            saveCursorVisible = Console.CursorVisible;
            //
            Console.Clear();
            Console.WriteLine(m1);
            Console.ReadKey(true);

            // Set the smallest possible window size before setting the buffer size.
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(80, 80);
            Console.SetWindowSize(40, 20);

            // Create grid lines to fit the buffer. (The buffer width is 80, but
            // this same technique could be used with an arbitrary buffer width.)
            for (y = 0; y < Console.BufferWidth / g1.Length; y++)
            {
                sbG1.Append(g1);
                sbG2.Append(g2);
            }
            sbG1.Append(g1, 0, Console.BufferWidth % g1.Length);
            sbG2.Append(g2, 0, Console.BufferWidth % g2.Length);
            grid1 = sbG1.ToString();
            grid2 = sbG2.ToString();

            Console.CursorVisible = false;
            Console.Clear();
            for (y = 0; y < Console.BufferHeight - 1; y++)
            {
                if (y % 3 == 0)
                    Console.Write(grid1);
                else
                    Console.Write(grid2);
            }

            Console.SetWindowPosition(0, 0);
            do
            {
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (Console.WindowLeft > 0)
                            Console.SetWindowPosition(
                                    Console.WindowLeft - 1, Console.WindowTop);
                        break;
                    case ConsoleKey.UpArrow:
                        if (Console.WindowTop > 0)
                            Console.SetWindowPosition(
                                    Console.WindowLeft, Console.WindowTop - 1);
                        break;
                    case ConsoleKey.RightArrow:
                        if (Console.WindowLeft < (Console.BufferWidth - Console.WindowWidth))
                            Console.SetWindowPosition(
                                    Console.WindowLeft + 1, Console.WindowTop);
                        break;
                    case ConsoleKey.DownArrow:
                        if (Console.WindowTop < (Console.BufferHeight - Console.WindowHeight))
                            Console.SetWindowPosition(
                                    Console.WindowLeft, Console.WindowTop + 1);
                        break;
                }
            }
            while (cki.Key != ConsoleKey.Escape);  // end do-while
        } // end try
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.Clear();
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(saveBufferWidth, saveBufferHeight);
            Console.SetWindowSize(saveWindowWidth, saveWindowHeight);
            Console.CursorVisible = saveCursorVisible;
        }
    } // end Main
} // end Sample
*/
/*
This example produces results similar to the following:

1) Press the cursor keys to move the console window.
2) Press any key to begin. When you're finished...
3) Press the Escape key to quit.

...

+----+----+----+-
|    |    |    |
|    |    |    |
+----+----+----+-
|    |    |    |
|    |    |    |
+----+----+----+-

*/

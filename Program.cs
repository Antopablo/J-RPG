using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading;

namespace J_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleWindowConfiguration.Setup();
            ConsoleConfiguration.Setup();

            Camera camera = new Camera(ConsoleConfiguration.AvailableConsoleWidth, ConsoleConfiguration.AvailableConsoleHeight);

            // WorldMap.txt
            //WorldMap map = new WorldMap("", @"..\..\Maps", "WorldMap.txt", null);
            //Player player = new Player(250, 107);

            // WorldMap.txt
            //WorldMap map = new WorldMap("", @"..\..\Maps", "WorldMap2.txt", null);
            //Player player = new Player(238, 22);

            // WorldMap.txt
            //WorldMap map = new WorldMap("", @"..\..\Maps", "WorldMap3.txt", null);
            //Player player = new Player(49, 92);

            // WorldMap.txt
            WorldMap map = new WorldMap("", @"..\..\Maps", "WorldMap4.txt", null);
            Player player = new Player(22, 22);

            camera.Map = map;
            camera.player = player;

            char[] wallsChar = new char[] { '☼', '╣', '║', '╗', '╝', '╚', '╔', '╩', '╦', '╠', '═', '╬' , '█' };
            string walls = new string(wallsChar);

            Thread display = new Thread(camera.Render);
            display.Start();

            bool exit = false;
            while (!exit)
            {
                if (Console.KeyAvailable)
                {
                    lock (player)
                    {
                        int nextAbscissa = player.Abscissa;
                        int nextOrdinate = player.Ordinate;
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.Escape:
                                exit = true;
                                break;
                            case ConsoleKey.LeftArrow:
                            case ConsoleKey.Q:
                                nextAbscissa--;
                                break;
                            case ConsoleKey.UpArrow:
                            case ConsoleKey.Z:
                                nextOrdinate--;
                                break;
                            case ConsoleKey.RightArrow:
                            case ConsoleKey.D:
                                nextAbscissa++;
                                break;
                            case ConsoleKey.DownArrow:
                            case ConsoleKey.S:
                                nextOrdinate++;
                                break;
                            default:
                                break;
                        }
                        if (!exit)
                        {
                            if (!walls.Contains(map.GetCharString(nextAbscissa, nextOrdinate)))
                            {
                                player.Abscissa = nextAbscissa;
                                player.Ordinate = nextOrdinate;
                            }
                        }
                    }
                }
            }
            camera.Stop = true;
            display.Join();
        }
    }
}

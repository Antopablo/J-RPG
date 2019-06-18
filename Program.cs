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

            MapsDatas.Initialize();
            MapsDatas.CreateJsonMetadatas();

            //char[] wallsChar = new char[] { '☼', '╣', '║', '╗', '╝', '╚', '╔', '╩', '╦', '╠', '═', '╬', '█' };
            //string walls = new string(wallsChar);

            WorldMap map;
            Character player;

            // WorldMap.txt
            //map = new WorldMap("", @"..\..\Maps", "World", walls, null);
            //player = new Character(250, 107);

            // WorldMap.txt
            //map = new WorldMap("", @"..\..\Maps", "WorldMap2.txt", walls, null);
            //player = new Character(238, 22);

            // WorldMap.txt
            //map = new WorldMap("", @"..\..\Maps", "WorldMap3.txt", walls, null);
            //player = new Character(49, 92);

            // WorldMap.txt
            //map = new WorldMap("", @"..\..\Maps", "WorldMap4.txt", walls, null);
            //player = new Character(22, 22);

            map = MapsDatas.GetWorldMap("Ifantasia");
            map.Load();
            player = new Character(250, 107);

            Camera camera = new Camera(ConsoleConfiguration.AvailableConsoleWidth, ConsoleConfiguration.AvailableConsoleHeight);
            camera.NonDeMethodePourSetLaMap(map);
            camera.Player = player;

            Thread display = new Thread(camera.Run);
            display.Start();

            bool exit = false;
            while (!exit)
            {
                if (Console.KeyAvailable)
                {
                    lock (player)
                    {
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.Escape:
                                exit = true;
                                break;
                            case ConsoleKey.LeftArrow:
                            case ConsoleKey.Q:
                                if (!map.IsWall(player.NextLeft))
                                {
                                    player.Left();
                                }
                                break;
                            case ConsoleKey.UpArrow:
                            case ConsoleKey.Z:
                                if (!map.IsWall(player.NextUp))
                                {
                                    player.Up();
                                }
                                break;
                            case ConsoleKey.RightArrow:
                            case ConsoleKey.D:
                                if (!map.IsWall(player.NextRight))
                                {
                                    player.Right();
                                }
                                break;
                            case ConsoleKey.DownArrow:
                            case ConsoleKey.S:
                                if (!map.IsWall(player.NextDown))
                                {
                                    player.Down();
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    if (map.IsDoorway(player.Position))
                    {
                        lock (player)
                        {
                            string originMapName = map.Name;
                            map = MapsDatas.GetWorldMap(map.DoorwayTarget(player.Position));
                            camera.NonDeMethodePourSetLaMap(map);
                            player.SetPosition(MapsDatas.GetHall(originMapName, map));
                        }
                    }
                }
            }
            camera.Stop = true;
            display.Join();
        }
    }
}

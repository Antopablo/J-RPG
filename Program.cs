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


            // Insertion des données dans la base
            FabriquePersonnage Fabrique = new FabriquePersonnage();
            string playername;
            string ClasseChoice;
            bool Continue = false;

            Console.WriteLine("Bienvenue dans ce nouveau jeux épique");
            Console.WriteLine("Voici votre personnage : @");
            Console.WriteLine("Quel est son nom?");

            playername = Console.ReadLine();
            Console.WriteLine(playername + " ? C'est très moyen mais ça ira...");
            while (!Continue)
            {
                Console.WriteLine("Dans ce jeu, vous avez le choix de votre voie. Quelle sera-t-elle ?");
                Console.WriteLine("Archer / Assassin / Chaman / Chevalier / Guerrier / Mage");
                ClasseChoice = Console.ReadLine().ToUpper();
                Fabrique.CreerPerso(ClasseChoice, playername);
                Continue = true;
            }
            Console.WriteLine("Pour commencer l'aventure dans le merveilleux monde de Ifantasia, appuyer sur entrée");
            Console.ReadLine();
            Console.Clear();

            char[] wallsChar = new char[] { '☼', '╣', '║', '╗', '╝', '╚', '╔', '╩', '╦', '╠', '═', '╬', '█' };
            string walls = new string(wallsChar);

            WorldMap map;
            Personnage player;
            Quete quest;

            // WorldMap.txt
            map = new WorldMap("", @"..\..\Maps", "WorldMap.txt", walls, null);
            player = new Personnage("Frank", 250, 107);
            
            // WorldMap.txt
            //map = new WorldMap("", @"..\..\Maps", "WorldMap2.txt", walls, null);
            //player = new Character(238, 22);

            // WorldMap.txt
            //map = new WorldMap("", @"..\..\Maps", "WorldMap3.txt", walls, null);
            //player = new Character(49, 92);

            // WorldMap.txt // carte Donjon
            //map = new WorldMap("", @"..\..\Maps", "WorldMap4.txt", walls, null);
            //player = new Character(22, 22);


            Camera camera = new Camera(ConsoleConfiguration.AvailableConsoleWidth, ConsoleConfiguration.AvailableConsoleHeight);
            camera.NonDeMethodePourSetLaMap(map);
            camera.Player = player;

            quest = new Quete(01, new Item("Sword", Stats.attaque, 10), new string[] { "test1", "test2", "test3" }, player, ETAT_QUEST.NON_COMMENCE, 252, 107);
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
                }
                    if (player.Position.Equals(quest.Position))
                    {
                        map = new WorldMap("", @"..\..\Maps", "WorldMap4.txt", walls, null);
                        camera.NonDeMethodePourSetLaMap(map);
                        player.Abscissa = 22;
                        player.Ordinate = 22;
                        camera.Player = player;
                    }
                
            }
            camera.Stop = true;
            display.Join();
        }
    }
}


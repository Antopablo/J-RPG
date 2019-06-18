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

            WorldMap map;
            Character player;
            Quete quest;

            

            map = MapsDatas.GetWorldMap("Ifantasia");
            map.Load();
            player = new Character("Frank", 250, 107);


            Camera camera = new Camera(ConsoleConfiguration.AvailableConsoleWidth, ConsoleConfiguration.AvailableConsoleHeight);
            camera.NonDeMethodePourSetLaMap(map);
            camera.Player = player;

            List<string> questText = new List<string>();
            questText.Add("QUETE :");
            questText.Add("Videz le donjon,");
            questText.Add("récupérez le Rubis");
            questText.Add("et revenez me voir");
            questText.Add(" ");
            questText.Add("Accepter (entrée)");
            questText.Add("Plus tard (Echap)");
            quest = new Quete(01, new Item("Sword", Stats.attaque, 10), questText, ETAT_QUEST.ENABLE, new Coordinates(252, 107));
            Thread display = new Thread(camera.Run);
            display.Start();

            PopUp Popup = new PopUp();

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
                    if (quest.Position.Equals(player.Position))
                    {
                        lock (Popup)
                        {
                            Popup.Text = quest.TextQuest;
                            Popup.Displayed = true;
                        }
                    }
                }
            }
            camera.Stop = true;
            display.Join();
        }
    }
}

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
        static public void InitialiserTOUSpersonnage(List<Personnage> List_Perso_Recrutable, FabriquePersonnage fabrique)
        {
            List_Perso_Recrutable.Add(fabrique.CreerPerso("ARCHER", "Archer"));
            List_Perso_Recrutable.Add(fabrique.CreerPerso("ASSASSIN", "Assassin"));
            List_Perso_Recrutable.Add(fabrique.CreerPerso("CHAMAN", "Chaman"));
            List_Perso_Recrutable.Add(fabrique.CreerPerso("CHEVALIER", "Chevalier"));
            List_Perso_Recrutable.Add(fabrique.CreerPerso("GUERRIER", "Guerrier"));
            List_Perso_Recrutable.Add(fabrique.CreerPerso("MAGE", "Mage"));
            List_Perso_Recrutable.Add(fabrique.CreerPerso("PRETRE", "Prêtre"));
        }

        static void Main(string[] args)
        {
            FabriquePersonnage fabriquePerso = new FabriquePersonnage();
            List<Personnage> List_Perso_Recrutable = new List<Personnage>(); // TOUS les personnages
            List<Personnage> List_Team = new List<Personnage>(); // Notre équipe de 3 perso max
            InitialiserTOUSpersonnage(List_Perso_Recrutable, fabriquePerso);
            CreerHeroPrincipale(List_Team, fabriquePerso);
        }

        static public void CreerHeroPrincipale(List<Personnage> Liste_TEAM, FabriquePersonnage fabrique)
        {
            string UserChoice_Name;
            string UserChoice_Class;
            Personnage perso;
            Console.WriteLine("#########  CRÉATION DE NOTRE HERO PRINCIPAL ##########");
            Console.WriteLine("Quel est le nom de votre héros ?");
            UserChoice_Name = Console.ReadLine();

            Console.WriteLine("Quel est la classe de " + UserChoice_Name);
            Console.Write("Archer / Assassin / Chaman / Chevalier / Guerrier / Mage / Pretre \r\n");
            UserChoice_Class = Console.ReadLine();
            perso = fabrique.CreerPerso(UserChoice_Class.ToUpper(), UserChoice_Name);
            Liste_TEAM.Add(perso);
            perso.DessinerPersonnage(UserChoice_Class.ToUpper());
            Console.WriteLine(perso);

            int ratio = 80;
            ConsoleWindowConfiguration.Setup();
            ConsoleConfiguration.Setup();


            //Console.OutputEncoding = Encoding.UTF8;
            //Console.SetWindowSize(1, 1);
            //Console.WriteLine("LargestWindowWidth : {0}", Console.LargestWindowWidth);
            //Console.WriteLine("LargestWindowHeight : {0}", Console.LargestWindowHeight);
            int consoleWidth = ((Console.LargestWindowWidth * ratio / 100) % 2 == 0) ? Console.LargestWindowWidth * ratio / 100 - 1 : Console.LargestWindowWidth * ratio / 100;
            int consoleHeight = ((Console.LargestWindowHeight * ratio / 100) % 2 == 0) ? Console.LargestWindowHeight * ratio / 100 - 1 : Console.LargestWindowHeight * ratio / 100;


            if (true)
            {
                Console.SetBufferSize(500 + consoleWidth, 180 + consoleHeight);
                Console.SetWindowSize(consoleWidth, consoleHeight);

                ConsoleKeyInfo consoleKey;

                bool wallsCollision;

                char[] usedChar = new char[] { '☼', '╣', '║', '╗', '╝', '╚', '╔', '╩', '╦', '╠', '═', '╬', '│', '┤', '┐', '└', '┴', '┬', '├', '─', '┼', '┘', '┌', '█', '░', '▒', '▓', '~', '§', '/', char.Parse(@"\"), '^', '¯', '(', ')', '_' };

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
}
        
        
      
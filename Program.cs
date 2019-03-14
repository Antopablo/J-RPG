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
            Console.SetWindowSize(80, 41);
            Console.Title = "Jeu de OUF";
            

            Guerrier perso = new Guerrier("Anto");
            Console.WriteLine(perso);

            Chaman perso2 = new Chaman("toto");
            Console.WriteLine(perso2);

            Pretre perso3 = new Pretre("titi");
            Console.WriteLine(perso3);

            Archer perso4 = new Archer("tutu");
            Console.WriteLine(perso4);

            Assassin perso5 = new Assassin("tata");
            Console.WriteLine(perso5);

            Chevalier perso6 = new Chevalier("zozo");
            Console.WriteLine(perso6);

            Mage perso7 = new Mage("zouzou");
            Console.WriteLine(perso7);
        }
    }
}

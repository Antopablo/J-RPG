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
            

            Chaman perso2 = new Chaman("toto");
            

            Pretre perso3 = new Pretre("titi");
            

            Archer perso4 = new Archer("tutu");
            

            Assassin perso5 = new Assassin("tata");
            

            Chevalier perso6 = new Chevalier("zozo");
            

            Mage perso7 = new Mage("zouzou");
            
        }
    }
}

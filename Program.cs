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
            Console.OutputEncoding = Encoding.GetEncoding("iso8859-1");
            Console.Title = "Jeu de OUF";

            FabriquePersonnage fabrique = new FabriquePersonnage();
            int UserChoiceINT;

            Console.WriteLine("Quel perso créer \n1) Chevalier \n2) Mage \n3) Assassin \n4) Archer \n5) Chaman \n6) Pretre \n7) Guerrier \n8) STOP");
            UserChoiceINT = (Int32.Parse(Console.ReadLine()));
            if (UserChoiceINT != 8)
            {
                Console.WriteLine("Quel est son nom");
                string nomPerso = Console.ReadLine();
                Console.WriteLine(fabrique.CreerPerso(UserChoiceINT, nomPerso));
            }
            

            bool fofo = true;
            while (fofo == true)
            {
                if (Console.ReadKey(true).KeyChar == 'z')
                {
                    fabrique.ListePersonnage[0].Deplacement('z');
                }
            }
        }
    }
}

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
            FabriquePersonnage fabriquePerso = new FabriquePersonnage();
            List<Personnage> List_Perso_Recrutable = new List<Personnage>(); // TOUS les personnages
            List<Personnage> List_Team = new List<Personnage>(); // Notre équipe de 3 perso max
            string UserChoice_Name;
            string UserChoice_Class;

            Console.WriteLine("#########  CRÉATION DE NOTRE HERO PRINCIPAL ##########");
            Console.WriteLine("Quel est le nom de votre héros ?");
            UserChoice_Name = Console.ReadLine();

            Console.WriteLine("Quel est la classe de "  + UserChoice_Name);
            Console.Write("Archer / Assassin / Chaman / Chevalier / Guerrier / Mage / Pretre \r\n");
            UserChoice_Class = Console.ReadLine();
            List_Team.Add(fabriquePerso.CreerPerso(UserChoice_Class.ToUpper(), UserChoice_Name));
            
        }
    }
}

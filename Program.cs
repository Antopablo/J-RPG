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
        }
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
    }
}

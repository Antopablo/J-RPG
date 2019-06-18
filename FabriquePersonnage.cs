using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    class FabriquePersonnage
    {
        public FabriquePersonnage()
        {
            ListePersonnage = new List<Character>();
        }

        private List<Character> _ListePersonnage;
        public List<Character> ListePersonnage 
        {
            get { return _ListePersonnage; }
            set { _ListePersonnage = value; }
        }


        public Character CreerPerso (string quelperso, string nom)
        {
            Character perso = null;
            switch (quelperso)
            {
                case "CHEVALIER":
                    perso = new Chevalier(nom, 250,107);
                    ListePersonnage.Add(perso);
                    perso.DessinerPersonnage("CHEVALIER");
                    Console.WriteLine(perso);
                    break;
                case "MAGE":
                    perso = new Mage(nom, 250, 107);
                    ListePersonnage.Add(perso);
                    perso.DessinerPersonnage("MAGE");

                    Console.WriteLine(perso);
                    break;
                case "ASSASSIN":
                    perso = new Assassin(nom, 250, 107);
                    ListePersonnage.Add(perso);
                    perso.DessinerPersonnage("ASSASSIN");

                    Console.WriteLine(perso);
                    break;
                case "ARCHER":
                    perso = new Archer(nom, 250, 107);
                    ListePersonnage.Add(perso);
                    perso.DessinerPersonnage("ARCHER");

                    Console.WriteLine(perso);
                    break;
                case "CHAMAN":
                    perso = new Chaman(nom, 250, 107);
                    ListePersonnage.Add(perso);
                    perso.DessinerPersonnage("CHAMAN");

                    Console.WriteLine(perso);
                    break;
                case "PRETRE":
                    perso = new Pretre(nom, 250, 107);
                    ListePersonnage.Add(perso);
                    perso.DessinerPersonnage("PRETRE");

                    Console.WriteLine(perso);
                    break;
                case "GUERRIER":
                    perso = new Guerrier(nom, 250, 107);
                    ListePersonnage.Add(perso);
                    perso.DessinerPersonnage("GUERRIER");

                    Console.WriteLine(perso);
                    break;
                default:
                    Console.WriteLine("Personnage inexistant");
                    break;
            }
            return perso;
        }


    }
}

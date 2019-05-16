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
            ListePersonnage = new List<Personnage>();
        }

        private List<Personnage> _ListePersonnage;
        public List<Personnage> ListePersonnage 
        {
            get { return _ListePersonnage; }
            set { _ListePersonnage = value; }
        }


        public Personnage CreerPerso (string quelperso, string nom)
        {
            Personnage perso = null;
            switch (quelperso)
            {
                case "CHEVALIER":
                    perso = new Chevalier(nom);
                    ListePersonnage.Add(perso);
                    Console.WriteLine(perso);
                    break;
                case "MAGE":
                    perso = new Mage(nom);
                    ListePersonnage.Add(perso);
                    Console.WriteLine(perso);
                    break;
                case "ASSASSIN":
                    perso = new Assassin(nom);
                    ListePersonnage.Add(perso);
                    Console.WriteLine(perso);
                    break;
                case "ARCHER":
                    perso = new Archer(nom);
                    ListePersonnage.Add(perso);
                    Console.WriteLine(perso);
                    break;
                case "CHAMAN":
                    perso = new Chaman(nom);
                    ListePersonnage.Add(perso);
                    Console.WriteLine(perso);
                    break;
                case "PRETRE":
                    perso = new Pretre(nom);
                    ListePersonnage.Add(perso);
                    Console.WriteLine(perso);
                    break;
                case "GUERRIER":
                    perso = new Guerrier(nom);
                    ListePersonnage.Add(perso);
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

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
                case "chevalier":
                    perso = new Chevalier(nom);
                    ListePersonnage.Add(perso);
                    break;
                case "mage":
                    perso = new Mage(nom);
                    ListePersonnage.Add(perso);
                    Console.WriteLine(perso);
                    break;
                case "assassin":
                    perso = new Assassin(nom);
                    ListePersonnage.Add(perso);
                    break;
                case "archer":
                    perso = new Archer(nom);
                    ListePersonnage.Add(perso);
                    break;
                case "chaman":
                    perso = new Chaman(nom);
                    ListePersonnage.Add(perso);
                    break;
                case "pretre":
                    perso = new Pretre(nom);
                    ListePersonnage.Add(perso);
                    break;
                case "guerrier":
                    perso = new Guerrier(nom);
                    ListePersonnage.Add(perso);
                    break; 
            }
            return perso;
        }


    }
}

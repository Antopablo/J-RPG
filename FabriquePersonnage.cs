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


        public Personnage CreerPerso (int quelperso, string nom)
        {
            Personnage perso = null;
            switch (quelperso)
            {
                case 1:
                    perso = new Chevalier(nom);
                    break;
                case 2:
                    perso = new Mage(nom);
                    break;
                case 3:
                    perso = new Assassin(nom);
                    break;
                case 4:
                    perso = new Archer(nom);
                    break;
                case 5:
                    perso = new Chaman(nom);
                    break;
                case 6:
                    perso = new Pretre(nom);
                    break;
                case 7:
                    perso = new Guerrier(nom);
                    break; 
            }
            return perso;
        }


    }
}

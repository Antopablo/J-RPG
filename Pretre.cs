using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    class Pretre : Personnage
    {
        public Pretre(string nom) : base(nom)
        {
            base.Attaque -= 5;
            base.Defense -= 5;
            base.Magie += 5;
            base.Resistance += 0;
            base.Vitesse += 5;
            base.PvMax += 10;
        }

        public override string ToString()
        {
            return "Notre héros s'appelle " + base.Nom + ".\nC'est un prêtre soigneur" + base.ToString();
        }
    }
}

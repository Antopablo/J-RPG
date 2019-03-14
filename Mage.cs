using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    class Mage : Personnage
    {
        public Mage(string nom) : base(nom)
        {
            base.Attaque -= 5;
            base.Defense -= 5;
            base.Magie += 10;
            base.Resistance += 0;
            base.Vitesse -= 5;
            base.PvMax -= 20;

            Console.WriteLine(ToString());
            base.DessinerPersonnage("mage");
        }

        public override string ToString()
        {
            return "Notre héros s'appelle " + base.Nom + ".\nC'est un mage mystique" + base.ToString();
        }


    }
}

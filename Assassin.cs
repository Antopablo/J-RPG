using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    class Assassin : Personnage
    {
        public Assassin(string nom) : base(nom)
        {
            base.Attaque += 10;
            base.Defense -= 5;
            base.Magie -= 5;
            base.Resistance -= 5;
            base.Vitesse += 10;
            base.PvMax -= 10;

            Console.WriteLine(ToString());
            base.DessinerPersonnage("assassin");
        }

        public override string ToString()
        {
            return "Notre héros s'appelle " + base.Nom + ".\nC'est un assassin efficace" + base.ToString();
        }
    }
}

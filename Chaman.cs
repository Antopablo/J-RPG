using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    class Chaman : Personnage
    {
        public Chaman(string nom) : base(nom)
        {
            base.Attaque -= 5;
            base.Defense += 0;
            base.Magie += 5;
            base.Resistance += 0;
            base.Vitesse += 0;
            base.PvMax -= 10;

            Console.WriteLine(ToString());
            base.DessinerPersonnage("chaman");
        }

        public override string ToString()
        {
            return "Notre héros s'appelle " + base.Nom + ".\nC'est un chaman erudit" + base.ToString();
        }
    }
}

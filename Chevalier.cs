using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    class Chevalier : Personnage
    {
        public Chevalier(string nom) : base(nom)
        {
            base.Attaque += 0;
            base.Defense += 10;
            base.Magie -= 5;
            base.Resistance += 5;
            base.Vitesse -= 5;
            base.PvMax += 30;

            
            base.DessinerPersonnage("chevalier");
            
        }

        public override string ToString()
        {
            return "Notre héros s'appelle " + base.Nom + ".\nC'est un chevalier courageux" + base.ToString();
        }
    }
}

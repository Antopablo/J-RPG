﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    class Archer : Personnage
    {
        public Archer(string nom) : base(nom)
        {
            base.Attaque += 5;
            base.Defense += 0;
            base.Magie -= 5;
            base.Resistance -= 5;
            base.Vitesse += 5;
            base.PvMax += 10;

            
            base.DessinerPersonnage("archer");
        }

        public override string ToString()
        {
            return "Notre héros s'appelle " + base.Nom + ".\nC'est un archer très précis" + base.ToString();
        }
    }
}

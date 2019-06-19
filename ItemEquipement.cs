using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    public class ItemEquipement : Item
    {
        public ItemEquipement(string nom, Stats nomStat, int bonus) : base(nom, nomStat, bonus)
        {
        }

        public override string ToString()
        {
            return "L'objet " + base.Nom + " ajoute " + base.Bonus + " à la caracteristique " + base.NomStat;
        }
    }
}

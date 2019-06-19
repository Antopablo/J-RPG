using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    public enum Stats
    {
        attaque,
        defense,
        magie,
        resistance,
        vitesse,
        pv
    }

    [Table("Item")]
    public class Item
    {
        public int ID { get; set; }

        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        private Stats _nomStat;
        public Stats NomStat
        {
            get { return _nomStat; }
            set { _nomStat = value; }
        }

        private int _bonus;
        public int Bonus
        {
            get { return _bonus; }
            set { _bonus = value; }
        }

        public Item(string nom, Stats nomStat, int bonus)
        {
            Nom = nom;
            NomStat = nomStat;
            Bonus = bonus;
        }

        public Item()
        {
            
        }
    }
}

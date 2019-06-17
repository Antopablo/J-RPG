using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    enum ETAT_QUEST
    {
        NON_COMMENCE,
        COMMENCE,
        TERMINEE
    }
    class Quete : Displayable
    {
        public Quete(int iD, Item recompense, string[] texte_Quete, Personnage inventaire_Personnage, ETAT_QUEST etat_Quete, int x, int y) : base ('!', x, y)
        {
            ID = iD;
            CompteurQuest = 0;
            Recompense = recompense;
            Texte_Quete = texte_Quete;
            Inventaire_Personnage = inventaire_Personnage.InventaireCommun;
            Etat_Quete = etat_Quete;
            x = 252;
            y = 107;
        }

        public int ID { get; set; }

        public int CompteurQuest { get; set; }

        public Item Recompense { get; set; }

        public string[] Texte_Quete { get; set; }

        public List<Item> Inventaire_Personnage { get; set; }

        public ETAT_QUEST Etat_Quete { get; set; }



    }
}

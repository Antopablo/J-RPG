using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    enum ETAT_QUEST
    {
       DISABLE,
       ENABLE,
       RUNNING,
       FINISH
    }
    class Quete : Displayable
    {
        public Quete(int iD, Item recompense,List<string> textQuest, ETAT_QUEST etat_Quete, Coordinates coord) : base ('!', coord.Abscissa, coord.Ordinate)
        {
            ID = iD;
            CompteurQuest = 0;
            Recompense = recompense;
            TextQuest = new List<string>();
            Etat_Quete = etat_Quete;
        }

        public int ID { get; set; }

        public int CompteurQuest { get; set; }

        public Item Recompense { get; set; }

        public List<string> TextQuest { get; set; }

        public ETAT_QUEST Etat_Quete { get; set; }
    }
}

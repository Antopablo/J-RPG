using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace J_RPG
{
    public class Interest
    {
        /*#####################################################*/
        /*############                             ############*/
        /*############   Attributs et propriétés   ############*/
        /*############                             ############*/
        /*#####################################################*/

        public int Id { get; set; }

        private string _name;
        public string Name { get { return _name; } set { _name = value; } }

        private List<Coordinates> _triggers;
        [InverseProperty("Spark")]
        virtual public List<Coordinates> Triggers { get { return _triggers; } set { _triggers = value; } }

        private int _mapId;
        public int MapId { get { return _mapId; } set { _mapId = value; } }
        [Index]
        [ForeignKey("MapId")]
        virtual public WorldMap Map { get; set; }


        // Possible de globaliser ainsi de façon qu'un Id de WorldMap ou un Id de Quest
        // ou un Id d'autre chose puisse référencer la valeur de la clé étrangère ?

        //private int _targetId;
        //public int TargetId
        //{
        //    get { return _targetId; }
        //    set { _targetId = value; }
        //}
        //[Index]
        //[ForeignKey("TargetId")]
        //virtual public object Target { get; set; }

        /*#####################################################*/
        /*############                             ############*/
        /*############  Constructeurs et méthodes  ############*/
        /*############                             ############*/
        /*#####################################################*/

        public Interest() { }

        public Interest(string name, List<Coordinates> triggers)
        {
            _name = name;
            _triggers = triggers;
        }

        public bool IsTriggered(Coordinates coordinates)
        {
            return _triggers.Contains(coordinates);
        }
    }
}

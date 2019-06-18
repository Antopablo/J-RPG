using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace J_RPG
{
    [DataContract]
    class Interest
    {
        /*#####################################################*/
        /*############                             ############*/
        /*############   Attributs et propriétés   ############*/
        /*############                             ############*/
        /*#####################################################*/


        private string _name;
        [DataMember]
        public string Name { get { return _name; } set { _name = value; } }

        private List<Coordinates> _triggers;
        [DataMember]
        public List<Coordinates> Triggers { get { return _triggers; } set { _triggers = value; } }

        /*#####################################################*/
        /*############                             ############*/
        /*############  Constructeurs et méthodes  ############*/
        /*############                             ############*/
        /*#####################################################*/


        //public Interest() { }

        public Interest(string name, List<Coordinates> triggers)
        {
            Name = name;
            Triggers = triggers;
        }

        public bool IsTriggered(Coordinates coordinates)
        {
            return _triggers.Contains(coordinates);
        }
    }
}

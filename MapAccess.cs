using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    class MapAccess
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private List<Coordinate> _accesses;

        public List<Coordinate> Accesses
        {
            get { return _accesses; }
            set { _accesses = value; }
        }

        public MapAccess(string name, List<Coordinate> access)
        {
            _name = name;
            _accesses = access;
        }
    }
}

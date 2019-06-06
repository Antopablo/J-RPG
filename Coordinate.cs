using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace J_RPG
{
    class Coordinate
    {
        private int _abscissa;

        public int Abscissa
        {
            get { return _abscissa; }
            set { _abscissa = value; }
        }

        private int _ordinate;

        public int Ordinate
        {
            get { return _ordinate; }
            set { _ordinate = value; }
        }

        public Coordinate(int abscissa, int ordinate)
        {
            _abscissa = abscissa;
            _ordinate = ordinate;
        }

        //public override bool Equals(object obj)
        //{
        //    return base.Equals(obj);
        //}

        public override string ToString()
        {
            return _abscissa + " " + _ordinate;
        }
    }
}

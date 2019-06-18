using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace J_RPG
{
    [DataContract]
    class Coordinates
    {
        /*#####################################################*/
        /*############                             ############*/
        /*############   Attributs et propriétés   ############*/
        /*############                             ############*/
        /*#####################################################*/


        protected int _abscissa;
        [DataMember]
        public int Abscissa { get { return _abscissa; } set { _abscissa = value; } }

        protected int _ordinate;
        [DataMember]
        public int Ordinate { get { return _ordinate; } set { _ordinate = value; } }

        public Coordinates Position { get { return new Coordinates(this); } }

        /*#####################################################*/
        /*############                             ############*/
        /*############  Constructeurs et méthodes  ############*/
        /*############                             ############*/
        /*#####################################################*/


        //public Coordinates() { }

        public Coordinates(int abscissa, int ordinate)
        {
            Abscissa = abscissa;
            Ordinate = ordinate;
        }

        public Coordinates(Coordinates coordinate)
        {
            _abscissa = coordinate.Abscissa;
            _ordinate = coordinate.Ordinate;
        }

        public override bool Equals(object obj)
        {
            bool isEqual;
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                isEqual = false;
            }
            else
            {
                Coordinates coordinate = (Coordinates)obj;
                isEqual = (_abscissa == coordinate._abscissa) && (_ordinate == coordinate._ordinate);
            }
            return isEqual;
        }

        public override int GetHashCode()
        {
            return (_abscissa << 2) ^ _ordinate;
        }

        public override string ToString()
        {
            return _abscissa + " " + _ordinate;
        }

    }
}

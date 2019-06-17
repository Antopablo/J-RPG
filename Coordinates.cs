using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace J_RPG
{
    public class Coordinates
    {
        /*#####################################################*/
        /*############                             ############*/
        /*############   Attributs et propriétés   ############*/
        /*############                             ############*/
        /*#####################################################*/

        public int Id { get; set; }

        protected int _abscissa;
        public int Abscissa { get { return _abscissa; } set { _abscissa = value; } }

        protected int _ordinate;
        public int Ordinate { get { return _ordinate; } set { _ordinate = value; } }

        [NotMapped]
        public Coordinates Position { get { return this; } }

        private int _interestId;
        public int InterestId { get { return _interestId; } set { _interestId = value; } }
        [Index]
        [ForeignKey("InterestId")]
        virtual public Interest Spark { get; set; }

        /*#####################################################*/
        /*############                             ############*/
        /*############  Constructeurs et méthodes  ############*/
        /*############                             ############*/
        /*#####################################################*/

        public Coordinates() { }

        public Coordinates(int abscissa, int ordinate)
        {
            _abscissa = abscissa;
            _ordinate = ordinate;
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

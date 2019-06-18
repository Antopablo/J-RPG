using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    abstract class Displayable : Coordinates
    {
        /*#####################################################*/
        /*############                             ############*/
        /*############   Attributs et propriétés   ############*/
        /*############                             ############*/
        /*#####################################################*/

        protected char _avatar;
        public char Avatar { get { return _avatar; } set { _avatar = value; } }

        /*#####################################################*/
        /*############                             ############*/
        /*############  Constructeurs et méthodes  ############*/
        /*############                             ############*/
        /*#####################################################*/

        //public Displayable() { }

        public Displayable(char avatar, int abscissa, int ordinate) : base(abscissa, ordinate)
        {
            _avatar = avatar;
        }
    }
}

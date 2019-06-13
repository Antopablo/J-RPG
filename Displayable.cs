using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    abstract class Displayable : Coordinate
    {
        protected char _avatar;

        public char Avatar
        {
            get { return _avatar; }
            set { _avatar = value; }
        }

        public Displayable() { }

        public Displayable(char avatar, int abscissa, int ordinate) : base(abscissa, ordinate)
        {
            _avatar = avatar;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    class Player : Displayable
    {
        public Player(int abscissa, int ordinate) : base('@', abscissa, ordinate) { }
    }
}

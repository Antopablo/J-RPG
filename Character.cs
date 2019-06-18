using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    class Character : Displayable
    {
        public Character(int abscissa, int ordinate) : base('@', abscissa, ordinate) { }

        public Character(Coordinates coordinates) : base('@', coordinates.Abscissa, coordinates.Ordinate) { }

        public void SetPosition(Coordinates coordinates)
        {
            _abscissa = coordinates.Abscissa;
            _ordinate = coordinates.Ordinate;
        }

        public void Left() { _abscissa--; }
        public void Up() { _ordinate--; }
        public void Right() { _abscissa++; }
        public void Down() { _ordinate++; }

        public Coordinates NextLeft { get { return new Coordinates(_abscissa - 1, _ordinate); } }
        public Coordinates NextUp { get { return new Coordinates(_abscissa, _ordinate - 1); } }
        public Coordinates NextRight { get { return new Coordinates(_abscissa + 1, _ordinate); } }
        public Coordinates NextDown { get { return new Coordinates(_abscissa, _ordinate + 1); } }
    }
}

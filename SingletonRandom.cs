using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    class SingletonRandom : Random
    {
        private static SingletonRandom _instance;

        public static SingletonRandom Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SingletonRandom();
                }
                return _instance;
            }
        }

        private SingletonRandom() : base()
        {
        }
    }
}

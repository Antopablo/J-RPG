using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace J_RPG
{
    class Camera
    {
        public bool Stop { get; set; }

        private List<StringBuilder> _lens;

        private int lensPlayerAbscissa;
        private int lensPlayerOrdinate;
        private int lensMapAbscissa;
        private int lensMapOrdinate;
        private int lensMapWidth;
        private int lensMapHeight;

        private int _width;
        private int _height;

        private int _horizontalOffset;
        private int _verticalOffset;

        private StringBuilder _horizontalMargin;
        private StringBuilder _verticalMargin;

        private WorldMap _map;
        public WorldMap Map
        {
            get { return _map; }
            private set
            {
                _map = value;
                _horizontalOffset = 0;
                _verticalOffset = 0;
                _horizontalMargin = null;
                _verticalMargin = null;
                if (_map.Width < _width)
                {
                    _horizontalOffset = (_width - _map.Width) / 2;
                    _horizontalMargin = new StringBuilder();
                    for (int i = 0; i < _horizontalOffset; i++)
                    {
                        _horizontalMargin.Append(" ");
                    }
                }
                if (_map.Height < _height)
                {
                    _verticalOffset = (_height - _map.Height) / 2;
                    _verticalMargin = new StringBuilder();
                    for (int i = 0; i < _width; i++)
                    {
                        _verticalMargin.Append(" ");
                    }
                }
            }
        }

        private Personnage _player;
        public Personnage Player { get { return _player; } set { _player = value; } }

        public Camera(int width, int height)
        {
            _width = width - 2;
            _height = height - 2;
            _lens = new List<StringBuilder>();
            _map = new WorldMap();
            Stop = false;
        }

        public void NonDeMethodePourSetLaMap(WorldMap map)
        {
            lock (_map)
            {
                Map = map;
            }
        }

        // méthode d'assignations de la carte, du player, des quêtes, et autres (?) ...
        // Methode de mise à jour de la carte en fonction des quêtes et éléments de quêtes
        // liste dynamique de "Displayable" en fonction des Abscisses et Ordonnées de
        //   la carte affichées par la camera

        public void Run()
        {
            while (!Stop)
            {
                if (Console.BufferWidth != Console.WindowWidth || Console.BufferHeight != Console.WindowHeight)
                {
                    Console.Clear();
                }
                GenerateLens();
                Display();
                Thread.Sleep(1);
            }
        }

        private void GenerateLens()
        {
            lock (_player)
            {
                lensMapWidth = (_map.Width < _width) ? _map.Width : _width;
                lensMapHeight = (_map.Height < _height) ? _map.Height : _height;
                lensPlayerAbscissa = (_map.Width < _width) ? _player.Abscissa : _width / 2;
                lensPlayerOrdinate = (_map.Height < _height) ? _player.Ordinate : _height / 2;
                lensMapAbscissa = (_map.Width < _width) ? 0 : _player.Abscissa - lensPlayerAbscissa;
                lensMapOrdinate = (_map.Height < _height) ? 0 : _player.Ordinate - lensPlayerOrdinate;
                lensPlayerAbscissa = (_map.Width < _width) ? lensPlayerAbscissa : (_player.Abscissa < _map.Width / 2) ? ((lensMapAbscissa < 0) ? lensPlayerAbscissa + lensMapAbscissa : lensPlayerAbscissa) : ((lensMapAbscissa > _map.Width - _width) ? lensPlayerAbscissa + (lensMapAbscissa - (_map.Width - _width)) : lensPlayerAbscissa);
                lensPlayerOrdinate = (_map.Height < _height) ? lensPlayerOrdinate : (_player.Ordinate < _map.Height / 2) ? ((lensMapOrdinate < 0) ? lensPlayerOrdinate + lensMapOrdinate : lensPlayerOrdinate) : ((lensMapOrdinate > _map.Height - _height) ? lensPlayerOrdinate + (lensMapOrdinate - (_map.Height - _height)) : lensPlayerOrdinate);
                lensMapAbscissa = (_map.Width < _width) ? lensMapAbscissa : (_player.Abscissa < _map.Width / 2) ? ((lensMapAbscissa < 0) ? 0 : lensMapAbscissa) : ((lensMapAbscissa > _map.Width - _width) ? _map.Width - _width : lensMapAbscissa);
                lensMapOrdinate = (_map.Height < _height) ? lensMapOrdinate : (_player.Ordinate < _map.Height / 2) ? ((lensMapOrdinate < 0) ? 0 : lensMapOrdinate) : ((lensMapOrdinate > _map.Height - _height) ? _map.Height - _height : lensMapOrdinate);
                lock (_map)
                {
                    _lens.Clear();
                    _lens = _map.GetSubPart(lensMapAbscissa, lensMapOrdinate, lensMapWidth, lensMapHeight);
                    _lens[lensPlayerOrdinate][lensPlayerAbscissa] = _player.Avatar;
                }
            }
        }

        private void Display()
        {
            string cameraLens = "";
            for (int j = 0; j < _height; j++)
            {
                if (_verticalOffset > 0 && (j < _verticalOffset || j > _height - (_verticalOffset + 1)))
                {
                    cameraLens += (j > 0) ? "\r\n " + _verticalMargin : " " + _verticalMargin;
                }
                else
                {
                    cameraLens += (_horizontalOffset > 0) ? ((j > 0) ? "\r\n " + _horizontalMargin + _lens[j - _verticalOffset] + _horizontalMargin : " " + _horizontalMargin + _lens[j - _verticalOffset] + _horizontalMargin) : ((j > 0) ? "\r\n " + _lens[j - _verticalOffset] : " " + _lens[j - _verticalOffset]);
                }
            }
            Console.SetCursorPosition(0, 1);
            Console.Write(cameraLens);
        }
    }
}

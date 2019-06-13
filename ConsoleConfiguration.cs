using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    static class ConsoleConfiguration
    {
        static private Encoding _encoding;

        static private int _largestWindowWidth;
        static private int _largestWindowHeight;

        static private int _bufferWidth;
        static private int _bufferHeight;
        static private int _windowWidth;
        static private int _windowHeight;

        static private int _availableConsoleWidth;

        static public int AvailableConsoleWidth
        {
            get { return _availableConsoleWidth; }
            private set { _availableConsoleWidth = value; }
        }

        static private int _availableconsoleHeight;
        
        static public int AvailableConsoleHeight
        {
            get { return _availableconsoleHeight; }
            private set { _availableconsoleHeight = value; }
        }

        static private void Initialize()
        {
            _encoding = Encoding.UTF8;
            _largestWindowWidth = Console.LargestWindowWidth;
            _largestWindowHeight = Console.LargestWindowHeight;
            _bufferWidth = _largestWindowWidth;
            _bufferHeight = _largestWindowHeight;
            _windowWidth = _largestWindowWidth;
            _windowHeight = _largestWindowHeight;
            _availableConsoleWidth = (_largestWindowWidth % 2 == 0) ? _largestWindowWidth - 1 : _largestWindowWidth;
            _availableconsoleHeight = (_largestWindowHeight % 2 == 0) ? _largestWindowHeight - 1 : _largestWindowHeight;
        }

        static private void SetLayout()
        {
            Console.OutputEncoding = _encoding;
            Console.CursorVisible = false;
            Console.SetWindowPosition(0, 0);
            Console.SetBufferSize(_bufferWidth, _bufferHeight);
            Console.SetWindowSize(_windowWidth, _windowHeight);
            //Console.BufferWidth = _bufferWidth;
            //Console.BufferHeight = _bufferHeight;
            //Console.WindowWidth = _windowWidth;
            //Console.WindowHeight = _windowHeight;
        }

        static public void Setup()
        {
            Initialize();
            SetLayout();
        }
    }
}

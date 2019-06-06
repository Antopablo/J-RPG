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

        static private int _consoleWidth;

        //static public int ConsoleWidth
        //{
        //    get { return _consoleWidth; }
        //    set { _consoleWidth = value; }
        //}

        static private int _consoleHeight;

        //static public int ConsoleHeight
        //{
        //    get { return _consoleHeight; }
        //    set { _consoleHeight = value; }
        //}

        static private int _windowWidth;

        //static public int WindowWidth
        //{
        //    get { return _windowWidth; }
        //    private set { _windowWidth = value; }
        //}

        static private int _windowHeight;

        //static public int WindowHeight
        //{
        //    get { return _windowHeight; }
        //    private set { _windowHeight = value; }
        //}

        static private int _bufferWidth;

        //static public int BufferWidth
        //{
        //    get { return _bufferWidth; }
        //    private set { _bufferWidth = value; }
        //}

        static private int _bufferHeight;

        //static public int BufferHeight
        //{
        //    get { return _bufferHeight; }
        //    private set { _bufferHeight = value; }
        //}

        static private void Initialize()
        {
            int rate = 100;
            _encoding = Encoding.UTF8;
            _largestWindowWidth = Console.LargestWindowWidth * rate / 100;
            _largestWindowHeight = Console.LargestWindowHeight * rate / 100;

            

            // Sans Camera
            _consoleWidth = (_largestWindowWidth % 2 == 0) ? _largestWindowWidth - 1 : _largestWindowWidth;
            _consoleHeight = (_largestWindowHeight % 2 == 0) ? _largestWindowHeight - 1 : _largestWindowHeight;
            _bufferWidth = _consoleWidth;
            _bufferHeight = _consoleHeight;
            _windowWidth = _bufferWidth;
            _windowHeight = _bufferHeight;
        }

        static private void SetLayout()
        {
            Console.SetWindowPosition(0, 0);
            Console.BufferWidth = _bufferWidth;
            Console.BufferHeight = _bufferHeight;
            Console.WindowWidth = _windowWidth;
            Console.WindowHeight = _windowHeight;
        }

        static public void Setup()
        {
            Initialize();
            SetLayout();
        }
    }
}

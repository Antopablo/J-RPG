using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;

namespace J_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo consoleKey;
            int consoleWidth = 81;
            int consoleHeight = 41;
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(200 + consoleWidth, 100 + consoleHeight);
            Console.SetWindowSize(consoleWidth, consoleHeight);

            char[,] test = new char[201, 101];
            for (int j = 0; j < test.GetLength(1); j++)
            {
                for (int i = 0; i < test.GetLength(0); i++)
                {
                    test[i, j] = ((j + 1)%2 == 1) ? '-' : '°';
                }
            }
            
            StringBuilder mapStringBuilder = new StringBuilder();
            for (int j = 0; j < Console.BufferHeight; j++)
            {
                for (int i = 0; i < Console.BufferWidth; i++)
                {
                    if (!(i < consoleWidth / 2) && (i < Console.BufferWidth - consoleWidth / 2) && (!(j < consoleHeight / 2) && (j < Console.BufferHeight - consoleHeight / 2)))
                    {
                        mapStringBuilder.Append(test[i - (consoleWidth / 2), j - (consoleHeight / 2)]);
                    }
                    else
                    {
                        if (!(i == Console.BufferWidth - 1 && j == Console.BufferHeight - 1))
                        {
                            mapStringBuilder.Append(' ');
                        }
                    }
                }
            }

            Console.Write(mapStringBuilder.ToString());
            /*
            for (int i = 0; i < 65535; i++)
            {
                Console.Write("{0, 4:x4} : {1, -2}", i, Convert.ToChar(i));
                if (i % 13 < 1)
                {
                    Console.WriteLine();
                }
            }
            for (int i = 0; i < 65535; i++)
            {
                Console.Write("{0, 4:x4} : {1, -2}", i, Convert.ToChar(i));
                if (i % 8 < 1)
                {
                    Console.WriteLine();
                }
            }
            // 0021 -> 007e, 00a0 -> 0131, 0134 -> 0137, 0139 -> 013e, 0141 -> 0148, 014c -> 017e,
            // 0180, 0189, 0191, 0192, 0197, 019a, 019f -> 01a1, 01a9, 01ab, 01ae -> 01b0, 01b6,
            // 01c0, 01c3, 01cd -> 01dc, 01de, 01df, 01e4 -> 01ed, 01f0, 0261, 0278, 02b9, 02ba,
            // 02bc, 02c4, 02c6, 02c8 -> 02cb, 02cd, 02da, 02dc, 0300 -> 0305, 0308, 030a, 030e,
            // 0327, 0331, 0332, 037e, 0393, 0398, 03a3, 03a6, 03a9, 03b1, 03b2, 03b4, 03b5, 03bc,
            // 03c0, 03c3, 03c4, 03c6, 
            string s = "This string contains two characters " +
                       "with codes outside the ASCII code range: " +
                       "Pi (\u03A0) and Sigma (\u03A3) (\u03C8) (\u263A) (\u0239).";
            Console.WriteLine("Original string:");
            Console.WriteLine("   {0}", s);
            Console.ReadKey();
            Console.Clear();
            */

            //Console.BackgroundColor = ConsoleColor.Black;
            //Console.ForegroundColor = ConsoleColor.Red;
            /*
            for (int j = 0 + consoleHeight / 2; j < Console.BufferHeight - consoleHeight / 2; j++)
            {
                for (int i = 0 + consoleWidth / 2; i < Console.BufferWidth - consoleWidth / 2; i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(test[i - consoleWidth / 2, j - consoleHeight / 2]);
                    
                    //if (j % 2 < 1 && i % 2 < 1)
                    //{
                    //    Console.SetCursorPosition(j, i);
                        //Console.ForegroundColor = (ConsoleColor)SingletonRandom.Instance.Next(0, Enum.GetValues(typeof(ConsoleColor)).Length);
                        //Console.BackgroundColor = (ConsoleColor)SingletonRandom.Instance.Next(0, Enum.GetValues(typeof(ConsoleColor)).Length);
                    //    Console.Write(test[i - consoleHeight / 2, j - consoleWidth / 2]);
                        //Console.Write("\u24c8");
                    //}
                    
                }
            }
            */
            Console.SetWindowPosition((Console.BufferWidth - Console.WindowWidth) / 2, (Console.BufferHeight - Console.WindowHeight) / 2);
            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
            Console.Write("@");
            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
            Console.CursorVisible = false;
            do
            {
                consoleKey = Console.ReadKey(true);
                switch (consoleKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (Console.WindowLeft > 0)
                        {
                            Console.Write(test[Console.CursorLeft - Console.WindowWidth / 2, Console.CursorTop - Console.WindowHeight / 2].ToString());
                            //Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                            Console.SetWindowPosition(Console.WindowLeft - 1, Console.WindowTop);
                            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                            Console.Write("@");
                            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (Console.WindowTop > 0)
                        {
                            Console.Write(test[Console.CursorLeft - Console.WindowWidth / 2, Console.CursorTop - Console.WindowHeight / 2].ToString());
                            //Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                            Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop - 1);
                            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                            Console.Write("@");
                            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (Console.WindowLeft < (Console.BufferWidth - Console.WindowWidth))
                        {
                            Console.Write(test[Console.CursorLeft - Console.WindowWidth / 2, Console.CursorTop - Console.WindowHeight / 2].ToString());
                            //Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                            Console.SetWindowPosition(Console.WindowLeft + 1, Console.WindowTop);
                            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                            Console.Write("@");
                            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (Console.WindowTop < (Console.BufferHeight - Console.WindowHeight))
                        {
                            Console.Write(test[Console.CursorLeft - Console.WindowWidth / 2, Console.CursorTop - Console.WindowHeight / 2].ToString());
                            //Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                            Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop + 1);
                            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                            Console.Write("@");
                            Console.SetCursorPosition(Console.WindowLeft + Console.WindowWidth / 2, Console.WindowTop + Console.WindowHeight / 2);
                        }
                        break;
                }
            }
            while (consoleKey.Key != ConsoleKey.Escape);  // end do-while
        }
    }
}
/*
using System;
using System.Text;

public class Example
{
    public static void Main()
    {
        // The encoding.
        var enc = new UTF32Encoding();

        // Create a string.
        String s = "This string contains two characters " +
                   "with codes outside the ASCII code range: " +
                   "Pi (\u03A0) and Sigma (\u03A3).";
        Console.WriteLine("Original string:");
        Console.WriteLine("   {0}", s);

        // Encode the string.
        Byte[] encodedBytes = enc.GetBytes(s);
        Console.WriteLine();
        Console.WriteLine("Encoded bytes:");
        for (int ctr = 0; ctr < encodedBytes.Length; ctr++)
        {
            Console.Write("[{0:X2}]{1}", encodedBytes[ctr],
                                         (ctr + 1) % 4 == 0 ? " " : "");
            if ((ctr + 1) % 16 == 0) Console.WriteLine();
        }
        Console.WriteLine();

        // Decode bytes back to string.
        // Notice Pi and Sigma characters are still present.
        String decodedString = enc.GetString(encodedBytes);
        Console.WriteLine();
        Console.WriteLine("Decoded string:");
        Console.WriteLine("   {0}", decodedString);
    }
}
*/
/*
using System;
using System.Text;

public class Example
{
    public static void Main()
    {
        // Get an encoding for code page 1252 (Western Europe character set).
        Encoding cp1252 = Encoding.GetEncoding(1252);

        // Define and display a string.
        string str = "\u24c8 \u2075 \u221e";
        Console.WriteLine("Original string: " + str);
        Console.Write("Code points in string: ");
        foreach (var ch in str)
            Console.Write("{0} ", Convert.ToUInt16(ch).ToString("X4"));

        Console.WriteLine("\n");

        // Encode a Unicode string.
        Byte[] bytes = cp1252.GetBytes(str);
        Console.Write("Encoded bytes: ");
        foreach (byte byt in bytes)
            Console.Write("{0:X2} ", byt);
        Console.WriteLine("\n");

        // Decode the string.
        string str2 = cp1252.GetString(bytes);
        Console.WriteLine("String round-tripped: {0}", str.Equals(str2));
        if (!str.Equals(str2))
        {
            Console.WriteLine(str2);
            foreach (var ch in str2)
                Console.Write("{0} ", Convert.ToUInt16(ch).ToString("X4"));
        }
    }
}
*/
// The example displays the following output:
//       Original string: Ⓢ ⁵ ∞
//       Code points in string: 24C8 0020 2075 0020 221E
//       
//       Encoded bytes: 3F 20 35 20 38
//       
//       String round-tripped: False
//       ? 5 8
//       003F 0020 0035 0020 0038
/*
// This example demonstrates the Console.WindowLeft and
//                               Console.WindowTop properties.
using System;
using System.Text;
using System.IO;
//
class Sample
{
    public static int saveBufferWidth;
    public static int saveBufferHeight;
    public static int saveWindowHeight;
    public static int saveWindowWidth;
    public static bool saveCursorVisible;
    //
    public static void Main()
    {
        string m1 = "1) Press the cursor keys to move the console window.\n" +
                    "2) Press any key to begin. When you're finished...\n" +
                    "3) Press the Escape key to quit.";
        string g1 = "+----";
        string g2 = "|    ";
        string grid1;
        string grid2;
        StringBuilder sbG1 = new StringBuilder();
        StringBuilder sbG2 = new StringBuilder();
        ConsoleKeyInfo cki;
        int y;
        //
        try
        {
            saveBufferWidth = Console.BufferWidth;
            saveBufferHeight = Console.BufferHeight;
            saveWindowHeight = Console.WindowHeight;
            saveWindowWidth = Console.WindowWidth;
            saveCursorVisible = Console.CursorVisible;
            //
            Console.Clear();
            Console.WriteLine(m1);
            Console.ReadKey(true);

            // Set the smallest possible window size before setting the buffer size.
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(80, 80);
            Console.SetWindowSize(40, 20);

            // Create grid lines to fit the buffer. (The buffer width is 80, but
            // this same technique could be used with an arbitrary buffer width.)
            for (y = 0; y < Console.BufferWidth / g1.Length; y++)
            {
                sbG1.Append(g1);
                sbG2.Append(g2);
            }
            sbG1.Append(g1, 0, Console.BufferWidth % g1.Length);
            sbG2.Append(g2, 0, Console.BufferWidth % g2.Length);
            grid1 = sbG1.ToString();
            grid2 = sbG2.ToString();

            Console.CursorVisible = false;
            Console.Clear();
            for (y = 0; y < Console.BufferHeight - 1; y++)
            {
                if (y % 3 == 0)
                    Console.Write(grid1);
                else
                    Console.Write(grid2);
            }

            Console.SetWindowPosition(0, 0);
            do
            {
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (Console.WindowLeft > 0)
                            Console.SetWindowPosition(
                                    Console.WindowLeft - 1, Console.WindowTop);
                        break;
                    case ConsoleKey.UpArrow:
                        if (Console.WindowTop > 0)
                            Console.SetWindowPosition(
                                    Console.WindowLeft, Console.WindowTop - 1);
                        break;
                    case ConsoleKey.RightArrow:
                        if (Console.WindowLeft < (Console.BufferWidth - Console.WindowWidth))
                            Console.SetWindowPosition(
                                    Console.WindowLeft + 1, Console.WindowTop);
                        break;
                    case ConsoleKey.DownArrow:
                        if (Console.WindowTop < (Console.BufferHeight - Console.WindowHeight))
                            Console.SetWindowPosition(
                                    Console.WindowLeft, Console.WindowTop + 1);
                        break;
                }
            }
            while (cki.Key != ConsoleKey.Escape);  // end do-while
        } // end try
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.Clear();
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(saveBufferWidth, saveBufferHeight);
            Console.SetWindowSize(saveWindowWidth, saveWindowHeight);
            Console.CursorVisible = saveCursorVisible;
        }
    } // end Main
} // end Sample
*/
/*
This example produces results similar to the following:

1) Press the cursor keys to move the console window.
2) Press any key to begin. When you're finished...
3) Press the Escape key to quit.

...

+----+----+----+-
|    |    |    |
|    |    |    |
+----+----+----+-
|    |    |    |
|    |    |    |
+----+----+----+-

*/

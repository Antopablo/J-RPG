using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
//using System.Diagnostics;

namespace J_RPG
{
    static class ConsoleWindowConfiguration
    {
        /***************************************************************************/
        /*                       Positionnement de la fenêtre                      */
        /***************************************************************************/

        // P/Invoke declarations.

        [DllImport("kernel32.dll")]
        static private extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static private extern IntPtr MonitorFromWindow(IntPtr handleWindow, uint dwFlags);

        private const int MONITOR_DEFAULTTOPRIMARY = 1;

        [DllImport("user32.dll")]
        static private extern bool GetMonitorInfo(IntPtr handleMonitor, ref MonitorInfo lpMonitorInfo);

        [StructLayout(LayoutKind.Sequential)]
        struct MonitorInfo
        {
            public uint cbSize;
            public Rect rcMonitor;
            public Rect rcWork;
            public uint dwFlags;
            static public MonitorInfo Default
            {
                get
                {
                    var inst = new MonitorInfo();
                    inst.cbSize = (uint)Marshal.SizeOf(inst);
                    return inst;
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        struct Rect
        {
            public int Left, Top, Right, Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct Point
        {
            public int x, y;
        }

        [DllImport("user32.dll", SetLastError = true)]
        static private extern bool GetWindowPlacement(IntPtr handleWindow, ref WindowPlacement lpWindowPlacement);

        [DllImport("user32.dll", SetLastError = true)]
        static private extern bool SetWindowPlacement(IntPtr handleWindow, [In] ref WindowPlacement lpWindowPlacement);

        const uint SW_RESTORE = 9;

        [StructLayout(LayoutKind.Sequential)]
        struct WindowPlacement
        {
            public uint Length;
            public uint Flags;
            public uint ShowCmd;
            public Point MinPosition;
            public Point MaxPosition;
            public Rect NormalPosition;
            static public WindowPlacement Default
            {
                get
                {
                    var instance = new WindowPlacement();
                    instance.Length = (uint)Marshal.SizeOf(instance);
                    return instance;
                }
            }
        }

        /***************************************************************************/
        /*                     Suppression du redimensionnement                    */
        /***************************************************************************/

        [DllImport("user32.dll")]
        static private extern IntPtr GetSystemMenu(IntPtr handleWindow, bool bRevert);

        [DllImport("user32.dll")]
        static private extern bool EnableMenuItem(IntPtr handleMenu, uint uIDEnableItem, uint uEnable);

        [DllImport("user32.dll")]
        static extern IntPtr RemoveMenu(IntPtr handleMenu, uint nPosition, uint wFlags);

        [DllImport("user32.dll")]
        static extern bool DrawMenuBar(IntPtr handleWindow);

        [DllImport("user32.dll")]
        static extern bool DeleteMenu(IntPtr handleMenu, uint uPosition, uint uFlags);

        private const int MF_BYCOMMAND = 0x00000000;
        private const int MF_BYPOSITION = 0x00000400;
        private const int MF_REMOVE = 0x1000;
        private const int MF_ENABLED = 0x0;
        private const int MF_GRAYED = 0x00000001;
        private const int MF_DISABLED = 0x00000002;

        private const int SC_SIZE = 0xF000;
        private const int SC_MOVE = 0xF010;
        private const int SC_MINIMIZE = 0xF020;
        private const int SC_MAXIMIZE = 0xF030;
        private const int SC_NEXTWINDOW = 0xF040;
        private const int SC_PREVWINDOW = 0xF050;
        private const int SC_CLOSE = 0xF060;
        private const int SC_VSCROLL = 0xF070;
        private const int SC_HSCROLL = 0xF080;
        private const int SC_MOUSEMENU = 0xF090;
        private const int SC_KEYMENU = 0xF100;
        private const int SC_ARRANGE = 0xF110;
        private const int SC_RESTORE = 0xF120;
        private const int SC_TASKLIST = 0xF130;
        private const int SC_SCREENSAVE = 0xF140;
        private const int SC_HOTKEY = 0xF150;
        private const int SC_DEFAULT = 0xF160;
        private const int SC_MONITORPOWER = 0xF170;
        private const int SC_CONTEXTHELP = 0xF180;
        private const int SC_SEPARATOR = 0xF00F;

        static private void PlaceWindow(IntPtr handleWindow)
        {
            // Get information about the monitor (display) that the window is (mostly) displayed on.
            // The .rcWork field contains the monitor's work area, i.e., the usable space excluding
            // the taskbar (and "application desktop toolbars" - see https://msdn.microsoft.com/en-us/library/windows/desktop/ms724947(v=vs.85).aspx)
            MonitorInfo monitorInfo = MonitorInfo.Default;
            GetMonitorInfo(MonitorFromWindow(handleWindow, MONITOR_DEFAULTTOPRIMARY), ref monitorInfo);

            // Get information about this window's current placement.
            WindowPlacement windowPlacement = WindowPlacement.Default;
            GetWindowPlacement(handleWindow, ref windowPlacement);

            // Calculate the window's new position: lower left corner.
            // !! Inexplicably, on W10, work-area coordinates (0,0) appear to be (7,7) pixels 
            // !! away from the true edge of the screen / taskbar.
            int fudgeOffset = 7;
            windowPlacement.NormalPosition = new Rect()
            {
                Left = -fudgeOffset,
                //Top = mi.rcWork.Bottom - (wp.NormalPosition.Bottom - wp.NormalPosition.Top),
                Top = monitorInfo.rcWork.Top,
                Right = (windowPlacement.NormalPosition.Right - windowPlacement.NormalPosition.Left),
                Bottom = -fudgeOffset + (windowPlacement.NormalPosition.Bottom - windowPlacement.NormalPosition.Top)
            };

            // Place the window at the new position.
            SetWindowPlacement(handleWindow, ref windowPlacement);
        }

        static private void SetupSystemMenu(IntPtr handleWindow)
        {
            IntPtr handleSystemMenu = GetSystemMenu(handleWindow, false);
            DeleteMenu(handleSystemMenu, SC_SIZE, MF_BYCOMMAND);
            DeleteMenu(handleSystemMenu, SC_MAXIMIZE, MF_BYCOMMAND);

        }

        static public void Setup()
        {
            // Get this console window's handleWindow (window handle).
            IntPtr handleWindow = GetConsoleWindow();
            SetupSystemMenu(handleWindow);
            PlaceWindow(handleWindow);
        }
    }
}

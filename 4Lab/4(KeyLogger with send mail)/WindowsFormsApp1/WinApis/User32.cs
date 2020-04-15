using System;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowsFormsApp1.WinApis
{
    class User32
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);


        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
    }
}

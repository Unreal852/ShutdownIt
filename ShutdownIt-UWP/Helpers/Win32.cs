using System.Runtime.InteropServices;

namespace ShutdownIt
{
    public static class Win32
    {
        [DllImport("user32.dll")]
        public static extern void LockWorkStation();

        [DllImport("user32.dll")]
        public static extern int ExitWindowsEx(int uFlags, int dwReason);
    }
}

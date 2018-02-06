using System.Diagnostics;

namespace ShutdownIt.Computer_Actions
{
    public class ShutdownAction : IAction
    {
        public ShutdownAction()
        {

        }

        /// <summary>
        /// Execute given action
        /// </summary>
        public void Execute()
        {
            Win32.ExitWindowsEx(1, 0);
        }

        public override string ToString()
        {
            return "Shutdown";
        }
    }
}

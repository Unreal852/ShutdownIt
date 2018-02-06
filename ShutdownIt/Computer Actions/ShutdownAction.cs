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
            Process.Start("shutdown", "/s /t 0");
        }

        public override string ToString()
        {
            return "Shutdown";
        }
    }
}

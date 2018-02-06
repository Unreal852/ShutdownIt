using System.Diagnostics;

namespace ShutdownIt.Computer_Actions
{
    public class RebootAction : IAction
    {
        public RebootAction()
        {

        }

        /// <summary>
        /// Execute given action
        /// </summary>
        public void Execute()
        {
            Process.Start("shutdown", "/r /t 0");
        }

        public override string ToString()
        {
            return "Reboot";
        }
    }
}

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
            Win32.ExitWindowsEx(2, 0);
        }

        public override string ToString()
        {
            return "Reboot";
        }
    }
}

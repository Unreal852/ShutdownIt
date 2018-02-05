namespace ShutdownIt.Computer_Actions
{
    public class LogOffAction : IAction
    {
        public LogOffAction()
        {

        }

        /// <summary>
        /// Execute given action
        /// </summary>
        public void Execute()
        {
            Win32.ExitWindowsEx(0, 0);
        }

        public override string ToString()
        {
            return "LogOff";
        }
    }
}

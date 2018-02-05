namespace ShutdownIt.Computer_Actions
{
    public class LockAction : IAction
    {
        public LockAction()
        {

        }

        /// <summary>
        /// Execute given action
        /// </summary>
        public void Execute()
        {
            Win32.LockWorkStation();
        }

        public override string ToString()
        {
            return "Lock";
        }
    }
}

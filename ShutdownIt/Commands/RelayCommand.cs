using System;
using System.Windows.Input;

namespace ShutdownIt.Commands
{
    public class RelayCommand : ICommand
    {
        private Action<object> m_action;

        public RelayCommand(Action<object> action)
        {
            m_action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            m_action(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}

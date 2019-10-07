using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Samples
{
    class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action m_Action = null;

        public RelayCommand(Action action)
        {
            m_Action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            m_Action?.Invoke();
        }
    }
}

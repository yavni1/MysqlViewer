using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MySqlProject.Command
{
    class Command : ICommand
    {
        private Action _execute;
        public event EventHandler CanExecuteChanged;

        public Command(Action action)
        {
            this._execute = action;
        }
        public bool CanExecute(object parameter)
        {
            //if (parameter == null) return false;
            return true;
        }

        public void Execute(object parameter)
        {
            _execute() ;
        }
    }
}

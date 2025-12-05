using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RandomNumberGenerator.ViewModel.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private Action<object> _executeMethod { get; set;  }
        private Predicate<object> _canExecute { get; set; }
        public RelayCommand(Action<object> executeMethod, Predicate<object> canExecute)
        {
            _executeMethod = executeMethod;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _executeMethod(parameter);
        }
    }
}

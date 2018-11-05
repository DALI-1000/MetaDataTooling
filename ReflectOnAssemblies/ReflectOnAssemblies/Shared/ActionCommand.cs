using System;
using System.Windows.Input;

namespace ReflectOnAssemblies.Shared
{
    public class ActionCommand : ICommand
    {
        #region ICommand
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _Execute(parameter);
        }
        #endregion ICommand

        #region private fields
        Func<object, bool> _CanExecute;
        Action<object> _Execute;
        #endregion private fields

        #region constructors
        public ActionCommand(Func<object, bool> canExecute, Action<object> execute)
        {
            _CanExecute = canExecute;
            _Execute = execute;
        }
        #endregion constructors
    }
}

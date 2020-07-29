using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KozyrevDenis_WpfApplication.Commands
{
    public class Command<TArg> : ICommand
    {
        #region Constructors

        public Command(Action<TArg> execute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            _execute = execute;
        }

        public Command(Action<TArg> execute, Func<TArg, bool> canexecute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            if (canexecute == null)
                throw new ArgumentNullException(nameof(canexecute));

            _execute = execute;
            _canexecute = canexecute;
        }

        #endregion

        #region ICommand

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
             => _canexecute == null || _canexecute((TArg)parameter);

        public void Execute(object parameter)
            => _execute((TArg)parameter);

        #endregion

        #region Fields

        private readonly Action<TArg> _execute;
        private readonly Func<TArg, bool> _canexecute;

        #endregion
    }
    //public class Command : ICommand
    //{
    //    #region Constructor

    //    public Command(Action<object> action)
    //    {
    //        ExecuteDelegate = action;
    //    }

    //    #endregion


    //    #region Properties

    //    public Predicate<object> CanExecuteDelegate { get; set; }
    //    public Action<object> ExecuteDelegate { get; set; }

    //    #endregion


    //    #region ICommand Members

    //    public bool CanExecute(object parameter)
    //    {
    //        if (CanExecuteDelegate != null)
    //        {
    //            return CanExecuteDelegate(parameter);
    //        }

    //        return true;
    //    }

    //    public event EventHandler CanExecuteChanged
    //    {
    //        add { CommandManager.RequerySuggested += value; }
    //        remove { CommandManager.RequerySuggested -= value; }
    //    }

    //    public void Execute(object parameter)
    //    {
    //        if (ExecuteDelegate != null)
    //        {
    //            ExecuteDelegate(parameter);
    //        }
    //    }

    //    #endregion
    //}
}

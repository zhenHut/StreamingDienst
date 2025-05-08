using System.Windows.Input;

namespace StreamingDienst.Commands
{
    public class RelayCommand : ICommand
    {
        #region Constructor

        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        #endregion

        #region Fields

        private readonly Action<object?> _execute;
        private readonly Predicate<object?>? _canExecute;

        #endregion

        #region event

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value!;
            remove => CommandManager.RequerySuggested -= value!;
        }

        #endregion

        #region Methods

        public bool CanExecute(object? parameter)
        => _canExecute?.Invoke(parameter) ?? true;


        public void Execute(object? parameter) => _execute(parameter!);

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        

        #endregion
    }

    public class RelayCommand<T> : ICommand
    {
        #region Constructor

        public RelayCommand(Action<T> execute, Predicate<T>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        #endregion

        #region Fields

        private readonly Action<T> _execute;
        private readonly Predicate<T>? _canExecute;

        #endregion

        #region event

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value!;
            remove => CommandManager.RequerySuggested -= value!;
        }

        #endregion

        #region Methods

        public bool CanExecute(object? parameter)
        {
            if (_canExecute == null)
                return true;

            return parameter is T t && _canExecute(t);
        }


        public void Execute(object? parameter)
        {
            if(parameter is T t) 
                _execute(t);
        } 

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }



        #endregion
    }

}

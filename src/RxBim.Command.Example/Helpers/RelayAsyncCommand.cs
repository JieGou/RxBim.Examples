namespace RxBim.CommandExample.Helpers
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;

    /// <summary>
    /// Асинхронная команда
    /// </summary>
    public class RelayAsyncCommand : IAsyncCommand
    {
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;

        private bool _isExecuting;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="execute">Метод выполнения команды</param>
        /// <param name="canExecute">Метод проверки возможности выполнения команды</param>
        public RelayAsyncCommand(
            Func<Task> execute,
            Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Событие на проверку возможности выполнения команды
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Возможность выполнения команды
        /// </summary>
        /// <returns>true - возможно, иначе - false</returns>
        public bool CanExecute()
        {
            return !_isExecuting
                && (_canExecute?.Invoke() ?? true);
        }

        /// <summary>
        /// Выполнение асинхронной команды
        /// </summary>
        public async Task ExecuteAsync()
        {
            if (CanExecute())
            {
                try
                {
                    _isExecuting = true;
                    await _execute();
                }
                finally
                {
                    _isExecuting = false;
                }
            }
        }

        /// <inheritdoc/>
        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        /// <inheritdoc/>
        async void ICommand.Execute(object parameter)
        {
            await ExecuteAsync();
        }
    }
}

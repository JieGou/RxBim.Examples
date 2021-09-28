namespace RxBim.Command.Autocad.Example.ViewModels
{
    using System.Windows.Input;
    using Abstractions;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using Application = Autodesk.AutoCAD.ApplicationServices.Core.Application;

    /// <summary>
    /// Основная модель представления
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IMyService _myService;

        /// <inheritdoc/>
        public MainWindowViewModel(
            IMyService myService)
        {
            _myService = myService;
        }

        /// <summary>
        /// Команда выполнения
        /// </summary>
        public ICommand DoCommand => new RelayCommand(DoCommandExecute);

        private void DoCommandExecute()
        {
            _myService.Go();
            Application.ShowAlertDialog("Готово");
        }
    }
}
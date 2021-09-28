namespace RxBim.CommandExample.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Abstractions;
    using Autodesk.Revit.UI;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using Helpers;
    using Tools.Revit.Abstractions;

    /// <summary>
    /// Основная модель представления
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IScopedElementsCollector _scopedElementsCollector;
        private readonly IMyService _myService;

        private ScopeType _scope = ScopeType.ActiveView;
        private int _intValue;

        private List<string> _selectedChoises
            = new List<string>();

        /// <inheritdoc/>
        public MainWindowViewModel(
            IScopedElementsCollector scopedElementsCollector,
            IMyService myService,
            RevitTask revitTask)
        {
            _scopedElementsCollector = scopedElementsCollector;
            _myService = myService;

            InitializeCommand = new RelayCommand(InitializeCommandExecute);
        }

        /// <summary>
        /// Выбранный тип обработки
        /// </summary>
        public ScopeType Scope
        {
            get => _scope;
            set
            {
                _scope = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Числовое значение от пользователя
        /// </summary>
        public int IntValue
        {
            get => _intValue;
            set
            {
                _intValue = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Индексы для доступного выбора
        /// </summary>
        public ObservableCollection<int> Indexes { get; }
            = new ObservableCollection<int>();

        /// <summary>
        /// Доступный выбор
        /// </summary>
        public ObservableCollection<string> AvailableChoises { get; }
            = new ObservableCollection<string>();

        /// <summary>
        /// Выбранные значения
        /// </summary>
        public List<string> SelectedChoises
        {
            get => _selectedChoises;
            set
            {
                _selectedChoises = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Инициализирует контекст
        /// </summary>
        public ICommand InitializeCommand { get; }

        /// <summary>
        /// Команда выполнения
        /// </summary>
        public ICommand DoCommand => new RelayAsyncCommand(DoCommandExecute);

        private void InitializeCommandExecute()
        {
            for (var i = 1; i <= 5; i++)
            {
                Indexes.Add(i);
                AvailableChoises.Add($"Choise {i}");
            }
        }

        private async Task DoCommandExecute()
        {
            try
            {
                _scopedElementsCollector.SetScope(Scope);

                if (IntValue < 0
                    || IntValue > 10)
                {
                    TaskDialog.Show("Внимание!", "Введите число от 0 до 10!");
                    return;
                }

                var goResult = await _myService.Go();
                if (goResult.IsFailure)
                    TaskDialog.Show("Внимание!", goResult.Error);
            }
            catch (Exception exception)
            {
                TaskDialog.Show("Внимание!", exception.ToString());
            }
            finally
            {
                _scopedElementsCollector.SetBackSelectedElements();
            }
        }
    }
}
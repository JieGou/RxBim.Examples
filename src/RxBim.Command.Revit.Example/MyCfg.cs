namespace RxBim.CommandExample
{
    using Abstractions;
    using Di;
    using Services;
    using Shared;
    using Tools.Revit;
    using ViewModels;
    using Views;

    /// <inheritdoc />
    public class MyCfg : ICommandConfiguration
    {
        /// <inheritdoc />
        public void Configure(IContainer container)
        {
            container.AddTransient<IMyService, MyService>();
            container.AddRevitHelpers();
            container.AddSharedTools();

            container.AddTransient<MainWindowViewModel>();
            container.AddTransient<MainWindow>();
        }
    }
}
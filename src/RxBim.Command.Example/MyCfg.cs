namespace RxBim.CommandExample
{
    using Abstractions;
    using Di;
    using Microsoft.Extensions.Configuration;
    using Services;
    using Shared;
    using Shared.FmHelpers;
    using Shared.RevitExtensions;
    using Shared.Ui;
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
            container.AddUi();
            container.AddSharedTools();
            container.AddFmHelpers(container.GetService<IConfiguration>);

            container.AddTransient<MainWindowViewModel>();
            container.AddTransient<MainWindow>();
        }
    }
}
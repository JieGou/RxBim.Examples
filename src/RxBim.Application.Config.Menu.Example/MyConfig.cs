namespace RxBim.Application.Config.Menu.Example
{
    using Di;
    using RxBim.Application.Ui.Revit.Api.Extensions;

    /// <inheritdoc />
    public class MyConfig : IApplicationConfiguration
    {
        /// <inheritdoc />
        public void Configure(IContainer container)
        {
            container.AddMenu();
        }
    }
}
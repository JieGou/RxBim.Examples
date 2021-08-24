namespace RxBim.Application.Menu.Config.Autocad.Example
{
    using Di;
    using Ui.Autocad.Api.Extensions;

    /// <inheritdoc />
    public class Config : IApplicationConfiguration
    {
        /// <inheritdoc />
        public void Configure(IContainer container)
        {
            container.AddMenu();
        }
    }
}
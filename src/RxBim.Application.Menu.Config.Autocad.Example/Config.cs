namespace RxBim.Application.Menu.Config.Autocad.Example
{
    using Di;
    using Ribbon.Autocad.Extensions;

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
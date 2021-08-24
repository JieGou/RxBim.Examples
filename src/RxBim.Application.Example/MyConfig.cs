namespace RxBim.Application.Example
{
    using Di;
    using Logs.Revit;

    /// <inheritdoc />
    public class MyConfig : IApplicationConfiguration
    {
        /// <inheritdoc />
        public void Configure(IContainer container)
        {
            container.AddTransient<IService, Service>();

            /*container.AddConfiguration(builder => builder
                .SetBasePath(Path.GetDirectoryName(GetType().Assembly.Location))
                .AddJsonFile("application.settings.json")
                .Build());*/

            container.AddLogs();
        }
    }
}
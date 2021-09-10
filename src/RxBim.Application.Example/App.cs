namespace RxBim.Application.Example
{
    using Autodesk.Revit.UI;
    using Revit;
    using Shared;

    /// <summary>
    /// app
    /// </summary>
    public class App : RxBimApplication
    {
        /// <summary>
        /// start
        /// </summary>
        /// <param name="service">service</param>
        public PluginResult Start(IService service)
        {
            service.Go();
            return PluginResult.Succeeded;
        }

        /// <summary>
        /// shutdown
        /// </summary>
        public PluginResult Shutdown()
        {
            TaskDialog.Show("RxBim.Application.Example", "App finished");
            return PluginResult.Succeeded;
        }
    }
}
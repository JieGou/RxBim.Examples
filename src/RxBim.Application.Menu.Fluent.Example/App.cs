namespace RxBim.Application.Menu.Fluent.Example
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
        public PluginResult Start()
        {
            TaskDialog.Show("RxBim.Application.Menu.Fluent.Example", "App started");
            return PluginResult.Succeeded;
        }

        /// <summary>
        /// shutdown
        /// </summary>
        public PluginResult Shutdown()
        {
            TaskDialog.Show("RxBim.Application.Menu.Fluent.Example", "App finished");
            return PluginResult.Succeeded;
        }
    }
}
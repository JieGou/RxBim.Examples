using Autodesk.AutoCAD.Runtime;
using RxBim.Application.Menu.Fluent.Autocad.Example;

[assembly: ExtensionApplication(typeof(App))]

namespace RxBim.Application.Menu.Fluent.Autocad.Example
{
    using Application.Autocad;
    using Autodesk.AutoCAD.ApplicationServices.Core;
    using Shared;

    /// <inheritdoc />
    public class App : RxBimApplication
    {
        /// <summary>
        /// start
        /// </summary>
        public PluginResult Start()
        {
            Application.ShowAlertDialog("RxBim.Application.Menu.Fluent.Autocad.Example started!");
            return PluginResult.Succeeded;
        }

        /// <summary>
        /// shutdown
        /// </summary>
        public PluginResult Shutdown()
        {
            Application.ShowAlertDialog("RxBim.Application.Menu.Fluent.Autocad.Example finished!");
            return PluginResult.Succeeded;
        }
    }
}
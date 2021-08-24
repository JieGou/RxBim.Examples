namespace RxBim.Application.Menu.Fluent.Autocad.Example.Commands
{
    using Autodesk.AutoCAD.ApplicationServices.Core;
    using Command.Autocad.Api;
    using Shared;

    /// <summary>
    /// Команда
    /// </summary>
    [RxBimCommandClass("HelloCmd8Example")]
    public class Cmd8 : RxBimCommand
    {
        /// <summary>
        /// Метод запуска команды
        /// </summary>
        public PluginResult ExecuteCommand()
        {
            Application.ShowAlertDialog("Hello #8");
            return PluginResult.Succeeded;
        }
    }
}
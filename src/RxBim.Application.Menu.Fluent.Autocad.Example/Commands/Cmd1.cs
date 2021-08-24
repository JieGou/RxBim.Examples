namespace RxBim.Application.Menu.Fluent.Autocad.Example.Commands
{
    using Autodesk.AutoCAD.ApplicationServices.Core;
    using Command.Autocad.Api;
    using Shared;

    /// <summary>
    /// Команда
    /// </summary>
    [RxBimCommandClass("HelloCmd1Example")]
    public class Cmd1 : RxBimCommand
    {
        /// <summary>
        /// Метод запуска команды
        /// </summary>
        public PluginResult ExecuteCommand()
        {
            Application.ShowAlertDialog("Hello #1");
            return PluginResult.Succeeded;
        }
    }
}
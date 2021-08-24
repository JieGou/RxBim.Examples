namespace RxBim.Application.Menu.Fluent.Autocad.Example.Commands
{
    using Autodesk.AutoCAD.ApplicationServices.Core;
    using Command.Autocad.Api;
    using Shared;

    /// <summary>
    /// Команда
    /// </summary>
    [RxBimCommandClass("HelloCmd4Example")]
    public class Cmd4 : RxBimCommand
    {
        /// <summary>
        /// Метод запуска команды
        /// </summary>
        public PluginResult ExecuteCommand()
        {
            Application.ShowAlertDialog("Hello #4");
            return PluginResult.Succeeded;
        }
    }
}
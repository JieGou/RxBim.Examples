namespace RxBim.Application.Menu.Fluent.Autocad.Example.Commands
{
    using Autodesk.AutoCAD.ApplicationServices.Core;
    using Command.Autocad;
    using Shared;

    /// <summary>
    /// Команда
    /// </summary>
    [RxBimCommandClass("HelloCmd6Example")]
    public class Cmd6 : RxBimCommand
    {
        /// <summary>
        /// Метод запуска команды
        /// </summary>
        public PluginResult ExecuteCommand()
        {
            Application.ShowAlertDialog("Hello #6");
            return PluginResult.Succeeded;
        }
    }
}
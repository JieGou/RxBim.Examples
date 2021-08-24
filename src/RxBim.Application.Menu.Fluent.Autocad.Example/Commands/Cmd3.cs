namespace RxBim.Application.Menu.Fluent.Autocad.Example.Commands
{
    using Autodesk.AutoCAD.ApplicationServices.Core;
    using Command.Autocad.Api;
    using Shared;

    /// <summary>
    /// Команда
    /// </summary>
    [RxBimCommandClass("HelloCmd3Example")]
    public class Cmd3 : RxBimCommand
    {
        /// <summary>
        /// Метод запуска команды
        /// </summary>
        public PluginResult ExecuteCommand()
        {
            Application.ShowAlertDialog("Hello #3");
            return PluginResult.Succeeded;
        }
    }
}
namespace RxBim.CommandExample
{
    using Autodesk.Revit.Attributes;
    using Command.Revit;
    using Shared;
    using Views;

    /// <inheritdoc />
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Cmd : RxBimCommand
    {
        /// <summary>
        /// cmd
        /// </summary>
        /// <param name="mainWindow">main window</param>
        public PluginResult ExecuteCommand(MainWindow mainWindow)
        {
            mainWindow.Show();
            return PluginResult.Succeeded;
        }
    }
}
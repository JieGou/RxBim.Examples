namespace RxBim.LoggedCommand.Example
{
    using Autodesk.Revit.Attributes;
    using Command.Revit;
    using Shared;

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Cmd : RxBimCommand
    {
        public PluginResult ExecuteCommand()
        {
            return PluginResult.Succeeded;
        }
    }
}
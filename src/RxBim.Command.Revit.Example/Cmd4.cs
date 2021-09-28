namespace RxBim.CommandExample
{
    using Autodesk.Revit.Attributes;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    using Command.Revit;
    using Shared;
    using Tools.Revit.Abstractions;

    /// <summary>
    /// Тестовая команда проверки работы <see cref="IScopedElementsCollector"/>
    /// </summary>
    [Regeneration(RegenerationOption.Manual)]
    [Transaction(TransactionMode.Manual)]
    public class Cmd4 : RxBimCommand
    {
        /// <summary>
        /// Запуск тестовой команды
        /// </summary>
        /// <param name="doc">Revit document</param>
        /// <param name="scopedElementsCollector">Сервис коллектора части элементов</param>
        public PluginResult ExecuteCommand(
            Document doc,
            IScopedElementsCollector scopedElementsCollector)
        {
            scopedElementsCollector.SetScope(ScopeType.ActiveView);
            TaskDialog.Show(nameof(Cmd4), "Установили Scope в ActiveView");

            scopedElementsCollector.GetFilteredElementCollector(doc);
            TaskDialog.Show(nameof(Cmd4),
                "Использовали метод GetFilteredElementCollector. Выделение должно сброситься");

            scopedElementsCollector.SetBackSelectedElements();
            TaskDialog.Show(nameof(Cmd4),
                "Вызвали метод SetBackSelectedElements. Выделение должно вернуться");

            return PluginResult.Succeeded;
        }
    }
}
namespace RxBim.CommandExample
{
    using System.Linq;
    using Autodesk.Revit.Attributes;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.DB.Architecture;
    using Autodesk.Revit.UI;
    using Command.Revit;
    using Shared;
    using Tools.Revit.Abstractions;

    /// <summary>
    /// Тестовая команда проверки работы методов работы со связанными файлами в <see cref="IScopedElementsCollector"/>
    /// </summary>
    [Regeneration(RegenerationOption.Manual)]
    [Transaction(TransactionMode.Manual)]
    public class Cmd6 : RxBimCommand
    {
        /// <summary>
        /// Запуск тестовой команды
        /// </summary>
        /// <param name="elementsCollector">Коллектор элементов</param>
        public PluginResult ExecuteCommand(
            IScopedElementsCollector elementsCollector)
        {
            var title = nameof(Cmd6);

            var pickedElement = elementsCollector.PickLinkedElement(element => element is Room, "Pick room");

            TaskDialog.Show(
                title,
                $"Выбран тип: {pickedElement.Element.GetType().Name} из связи {pickedElement.LinkInstance.Name}");

            var peckedElements =
                elementsCollector.PickLinkedElements(element => element is Room, "Pick rooms");

            TaskDialog.Show(
                title,
                $"Выбрано элементов: {peckedElements.Count} типов: {string.Join(", ", peckedElements.Select(e => e.Element.GetType().Name).Distinct())}");

            return PluginResult.Succeeded;
        }
    }
}
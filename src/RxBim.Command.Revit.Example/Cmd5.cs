namespace RxBim.CommandExample
{
    using System;
    using System.Collections.Generic;
    using Autodesk.Revit.Attributes;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    using Command.Revit;
    using Shared;
    using Tools.Revit.Abstractions;
    using Tools.Revit.Models;

    /// <summary>
    /// Тестовая команда проверки работы <see cref="ISharedParameterService"/>
    /// </summary>
    [Regeneration(RegenerationOption.Manual)]
    [Transaction(TransactionMode.Manual)]
    public class Cmd5 : RxBimCommand
    {
        /// <summary>
        /// Запуск тестовой команды
        /// </summary>
        /// <param name="sharedParameterService">Сервис по работе с общими параметрами</param>
        public PluginResult ExecuteCommand(
            ISharedParameterService sharedParameterService)
        {
            //// Тестовая команда создана для тестирования на ФОП ПИК:
            //// \\picompany.ru\pikp\lib\_CadSettings\02_Revit\04. Shared Parameters\BDS.txt

            var title = nameof(Cmd5);

            var sharedParameterInfo = new SharedParameterInfo
            {
                Definition = new SharedParameterDefinition
                {
                    ParameterName = "BDS_Mark",
                    Guid = Guid.Parse("91173747-10c0-436c-87d6-8be53634c723"),
                    OwnerGroupName = "Идентификация",
                    DataType = ParameterType.Text
                },
                CreateData = new SharedParameterCreateData
                {
                    ParameterGroup = BuiltInParameterGroup.PG_IDENTITY_DATA,
                    CategoriesForBind = new List<BuiltInCategory>
                    {
                        BuiltInCategory.OST_Walls
                    },
                    AllowVaryBetweenGroups = true,
                    IsCreateForInstance = true
                }
            };

            var definitionFileResult = sharedParameterService.GetDefinitionFile();
            if (definitionFileResult.IsFailure)
            {
                TaskDialog.Show(title, definitionFileResult.Error);
                return PluginResult.Failed;
            }

            var definitionFile = definitionFileResult.Value;

            TaskDialog.Show(
                title,
                $"Проверка параметра BDS_Mark в ФОП только по имени: {sharedParameterService.ParameterExistsInDefinitionFile(definitionFile, sharedParameterInfo, false)}");

            TaskDialog.Show(
                title,
                $"Проверка параметра BDS_Mark в ФОП по всем данным: {sharedParameterService.ParameterExistsInDefinitionFile(definitionFile, sharedParameterInfo, true)}");

            TaskDialog.Show(title, "Создаем параметр BDS_Mark для стен. Проверяем по всем данным");

            sharedParameterService.AddSharedParameter(definitionFile, sharedParameterInfo, true);

            sharedParameterInfo.Definition.Guid = Guid.NewGuid();

            TaskDialog.Show(
                title,
                $"Проверка параметра BDS_Mark в ФОП по всем данным с неверным GUID: {sharedParameterService.ParameterExistsInDefinitionFile(definitionFile, sharedParameterInfo, true)}");

            return PluginResult.Succeeded;
        }
    }
}
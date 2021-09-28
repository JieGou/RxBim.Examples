namespace RxBim.CommandExample
{
    using System.Collections.Generic;
    using Autodesk.Revit.Attributes;
    using Autodesk.Revit.UI;
    using Command.Revit;
    using Models;
    using Shared;
    using Shared.Abstractions;

    /// <summary>
    /// Тестовая команда проверки работы с сервисом пользовательских настроек
    /// </summary>
    [Regeneration(RegenerationOption.Manual)]
    [Transaction(TransactionMode.Manual)]
    public class Cmd3 : RxBimCommand
    {
        /// <summary>
        /// Запуск тестовой команды
        /// </summary>
        /// <param name="userSettings">Сервис работы с пользовательскими настройками</param>
        public PluginResult ExecuteCommand(IUserSettings userSettings)
        {
            var mySettings = new MySettings
            {
                StringValue = "Hello world",
                IntValue = 12,
                DoubleValue = 0.144
            };

            userSettings.Set(mySettings);

            var loaded = userSettings.Get<MySettings>();
            TaskDialog.Show(nameof(Cmd3),
                $"Настройки загружены со значениями: {nameof(loaded.StringValue)}: {loaded.StringValue}; {nameof(loaded.IntValue)} : {loaded.IntValue}; {nameof(loaded.DoubleValue)}: {loaded.DoubleValue}");

            var list = new List<string>
            {
                "Value 1", "Value 2", "Value 3"
            };

            userSettings.Set(list, nodeName: "MyList");
            TaskDialog.Show(nameof(Cmd3), "В настройки сохранена коллекция строк с именем MyList");

            var loadedList = userSettings.Get<List<string>>("MyList");
            TaskDialog.Show(nameof(Cmd3),
                $"Из настроек загружена коллекция со значениями: {string.Join(", ", loadedList)}");

            return PluginResult.Succeeded;
        }
    }
}
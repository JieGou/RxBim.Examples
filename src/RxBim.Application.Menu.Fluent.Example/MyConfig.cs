namespace RxBim.Application.Menu.Fluent.Example
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Di;
    using Shared;
    using Ui.About;
    using Ui.Revit.Api.Extensions;

    /// <inheritdoc />
    public class MyConfig : IApplicationConfiguration
    {
        /// <inheritdoc />
        public void Configure(IContainer container)
        {
            container.AddAbout();
            container.AddMenu(ribbon => ribbon
                .Tab("First")
                .AboutButton(
                    "О программе",
                    button => button
                        .SetContent(new AboutBoxContent(
                            "RxBim4Revit",
                            "21.1",
                            $"ПИК-АР - Модуль продукта RxBim, автоматизирующий процесс проектирования для архитекторов{Environment.NewLine}Разработано для Autodesk Revit 2019",
                            GetType().Assembly.GetName().Version,
                            "ПИК-Digital",
                            new Dictionary<string, string>
                            {
                                {
                                    "Скачать актуальные версии плагинов",
                                    "https://drive.google.com/drive/folders/1v-KbQEKv7roJctcWSCodsFQy3KwSz_rt"
                                },
                                { "Сайт", "https://pikipedia.pik.ru/wiki/PIK_Tools" },
                                { "Канал в Telegram", "https://t.me/RxBim_News" }
                            }))
                        .SetSmallImage(
                            new Uri(Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), @"img\small.png"),
                                UriKind.Absolute))
                        .SetLargeImage(
                            new Uri(Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), @"img\large.png"),
                                UriKind.Absolute)))
                .Panel("Panel1")
                .PullDownButton("PullDown", "Кнопка-контейнер", null)
                .Button(
                    "Button1",
                    "Go",
                    typeof(MyCmd),
                    button => button
                        .SetSmallImage(
                            new Uri(Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), @"img\small.png"),
                                UriKind.Absolute))
                        .SetLargeImage(
                            new Uri(Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), @"img\large.png"),
                                UriKind.Absolute))
                        .SetLongDescription("Button1 description")
                        .SetToolTip("Example button")
                        .SetHelpUrl("https://pikipedia.pik.ru/wiki/PIK_Tools")));
        }
    }
}
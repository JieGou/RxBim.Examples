namespace RxBim.Application.Menu.Fluent.Revit.Example
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Di;
    using Ribbon.Revit.Extensions;
    using Shared;

    /// <inheritdoc />
    public class MyConfig : IApplicationConfiguration
    {
        /// <inheritdoc />
        public void Configure(IContainer container)
        {
            container.AddMenu(ribbon => ribbon
                .Tab("First")
                .AboutButton(
                    "О программе",
                    button => button
                        .SetContent(new AboutBoxContent(
                            "RxBim4Revit",
                            "21.1",
                            $"RxBim-Example - Модуль продукта RxBim, автоматизирующий процесс проектирования{Environment.NewLine}Разработано для Autodesk Revit 2019",
                            GetType().Assembly.GetName().Version,
                            "Reactive BIM",
                            new Dictionary<string, string>
                            {
                                {
                                    "Скачать актуальные версии примеров",
                                    "https://github.com/ReactiveBIM/RxBim.Examples"
                                },
                                { "Сайт", "https://github.com/ReactiveBIM" },
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
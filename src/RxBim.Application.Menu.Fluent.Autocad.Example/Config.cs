namespace RxBim.Application.Menu.Fluent.Autocad.Example
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Commands;
    using Di;
    using Ribbon.Autocad.Extensions;
    using Shared;

    /// <inheritdoc />
    public class Config : IApplicationConfiguration
    {
        /// <inheritdoc />
        public void Configure(IContainer container)
        {
            var assemblyDir = Path.GetDirectoryName(GetType().Assembly.Location) ?? string.Empty;
            container.AddMenu(ribbon =>
                ribbon.Tab("FxExampleTab")
                    .AboutButton("О программе",
                        button => button
                            .SetContent(new AboutBoxContent(
                                "RxBim4AutoCAD",
                                "1.1",
                                $"RxBim-Example - Модуль продукта RxBim для демонстрации и проверки работы API{Environment.NewLine}Разработано для Autodesk Autocad 2019",
                                GetType().Assembly.GetName().Version,
                                "ReactiveBIM",
                                new Dictionary<string, string>
                                {
                                    {
                                        "Скачать актуальные версии примеров",
                                        "https://github.com/ReactiveBIM/RxBim.Examples"
                                    },
                                    { "Сайт", "https://github.com/ReactiveBIM" },
                                    { "Канал в Telegram", "https://t.me/RxBim_News" }
                                }))
                            .SetLargeImage(
                                new Uri(Path.Combine(assemblyDir, @"img\large.png"), UriKind.Absolute))
                            .SetLongDescription("Выводит информацию о программе"))
                    .Panel("FxExamplePanel")
                    .Button(nameof(Cmd1),
                        "Команда №1",
                        typeof(Cmd1),
                        button => button
                            .SetLongDescription("Выводит сообщение")
                            .SetToolTip("Нажми на меня!")
                            .SetSmallImage(
                                new Uri(Path.Combine(assemblyDir, @"img\small.png"), UriKind.Absolute))
                            .SetLargeImage(
                                new Uri(Path.Combine(assemblyDir, @"img\large.png"), UriKind.Absolute))
                            .SetHelpUrl("https://www.google.com/"))
                    .StackedItems(items => items
                        .Button(nameof(Cmd2),
                            "Команда №2",
                            typeof(Cmd2),
                            button => button
                                .SetLongDescription("Выводит сообщение")
                                .SetToolTip("Нажми на меня!")
                                .SetSmallImage(
                                    new Uri(Path.Combine(assemblyDir, @"img\small.png"), UriKind.Absolute))
                                .SetLargeImage(
                                    new Uri(Path.Combine(assemblyDir, @"img\large.png"), UriKind.Absolute))
                                .SetShowText(false))
                        .Button(nameof(Cmd3),
                            "Команда №3",
                            typeof(Cmd3),
                            button => button
                                .SetLongDescription("Выводит сообщение")
                                .SetToolTip("Нажми на меня!")
                                .SetSmallImage(
                                    new Uri(Path.Combine(assemblyDir, @"img\small.png"), UriKind.Absolute))
                                .SetLargeImage(
                                    new Uri(Path.Combine(assemblyDir, @"img\large.png"), UriKind.Absolute))
                                .SetShowText(false))
                        .Button(nameof(Cmd4),
                            "Команда №4",
                            typeof(Cmd4),
                            button => button
                                .SetLongDescription("Выводит сообщение")
                                .SetToolTip("Нажми на меня!")
                                .SetSmallImage(
                                    new Uri(Path.Combine(assemblyDir, @"img\small.png"), UriKind.Absolute))
                                .SetLargeImage(
                                    new Uri(Path.Combine(assemblyDir, @"img\large.png"), UriKind.Absolute))))
                    .PullDownButton("Pulldown",
                        "Выбор",
                        pulldown => pulldown
                            .Button(nameof(Cmd5),
                                "Команда №5",
                                typeof(Cmd5),
                                button => button
                                    .SetLongDescription("Выводит сообщение")
                                    .SetToolTip("Нажми на меня!")
                                    .SetSmallImage(
                                        new Uri(Path.Combine(assemblyDir, @"img\small.png"), UriKind.Absolute))
                                    .SetLargeImage(
                                        new Uri(Path.Combine(assemblyDir, @"img\large.png"), UriKind.Absolute)))
                            .Button(nameof(Cmd6),
                                "Команда №6",
                                typeof(Cmd6),
                                button => button
                                    .SetLongDescription("Выводит сообщение")
                                    .SetToolTip("Нажми на меня!")
                                    .SetSmallImage(
                                        new Uri(Path.Combine(assemblyDir, @"img\small.png"), UriKind.Absolute))
                                    .SetLargeImage(
                                        new Uri(Path.Combine(assemblyDir, @"img\large.png"), UriKind.Absolute))))
                    .SlideOut()
                    .StackedItems(items => items
                        .Button(nameof(Cmd7),
                            "Команда №7",
                            typeof(Cmd7),
                            button => button
                                .SetLongDescription("Выводит сообщение")
                                .SetToolTip("Нажми на меня!")
                                .SetSmallImage(
                                    new Uri(Path.Combine(assemblyDir, @"img\small.png"), UriKind.Absolute))
                                .SetLargeImage(
                                    new Uri(Path.Combine(assemblyDir, @"img\large.png"), UriKind.Absolute)))
                        .Button(nameof(Cmd8),
                            "Команда №8",
                            typeof(Cmd8),
                            button => button
                                .SetLongDescription("Выводит сообщение")
                                .SetToolTip("Нажми на меня!")
                                .SetSmallImage(
                                    new Uri(Path.Combine(assemblyDir, @"img\small.png"), UriKind.Absolute))
                                .SetLargeImage(
                                    new Uri(Path.Combine(assemblyDir, @"img\large.png"), UriKind.Absolute)))));
        }
    }
}
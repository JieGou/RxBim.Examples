﻿namespace RxBim.LoggedCommand.Example
{
    using Di;
    using RxBim.Logs.Revit;

    public class Config : ICommandConfiguration
    {
        public void Configure(IContainer container)
        {
            container.AddLogs();
        }
    }
}
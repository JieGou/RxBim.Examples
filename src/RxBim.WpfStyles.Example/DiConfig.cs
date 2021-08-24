using RxBim.Di;
using RxBim.Shared.Ui;

namespace RxBim.WpfStyles.Example
{
    public class DiConfig : DiConfigurator<ICommandConfiguration>
    {
        protected override void ConfigureBaseDependencies()
        {
            Container.AddUi();
        }
    }
}

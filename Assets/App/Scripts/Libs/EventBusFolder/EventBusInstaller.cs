using Zenject;

namespace Platformer.App.Scripts.Libs.EventBusFolder
{
    public class EventBusInstaller : Installer<EventBusInstaller>
    {
        #region Public methods

        public override void InstallBindings()
        {
            Container.Bind<EventBus>().AsSingle();
        }

        #endregion
    }
}

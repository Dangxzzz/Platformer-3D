using Platformer.App.Scripts.Libs.EventBusFolder;
using Platformer.Infrastructure.Installers;
using Platformer.Services.SoundServiceFolder;
using Zenject;

namespace Platformer.App.Scripts.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        #region Public methods

        public override void InstallBindings()
        {
            SceneLoaderServiceInstaller.Install(Container);
            GameServiceInstaller.Install(Container);
            SoundServiceInstaller.Install(Container);
            EventBusInstaller.Install(Container);
        }

        #endregion
    }
}
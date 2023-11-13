using Platformer.Services.SceneLoader;
using Zenject;

namespace Platformer.Infrastructure.Installers
{
    public class SceneLoaderServiceInstaller : Installer<SceneLoaderServiceInstaller>
    {
        #region Public methods

        public override void InstallBindings()
        {
            Container.Bind<SceneLoaderService>().AsSingle();
        }

        #endregion
    }
}

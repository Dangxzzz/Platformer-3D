using Platformer.Services.Bootstrap;
using Zenject;

namespace Platformer.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        #region Public methods

        public override void InstallBindings()
        {
            SceneLoaderServiceInstaller.Install(Container);
            GameServiceInstaller.Install(Container);
        }

        #endregion
    }
}
using Platformer.Services.Bootstrap;
using Platformer.Services.SoundServiceFolder;
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
            SoundServiceInstaller.Install(Container);
        }

        #endregion
    }
}
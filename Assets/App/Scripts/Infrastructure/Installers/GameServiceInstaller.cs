using Platformer.Services.Game;
using Platformer.Services.SoundServiceFolder;
using Zenject;

namespace Platformer.Infrastructure.Installers
{
    public class GameServiceInstaller : Installer<GameServiceInstaller>
    {
        #region Public methods

        public override void InstallBindings()
        {
            Container.Bind<GameService>().AsSingle();
        }

        #endregion
    }
}

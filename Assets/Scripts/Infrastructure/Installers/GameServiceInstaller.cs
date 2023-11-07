using Platformer.Services.Game;
using Platformer.Services.SoundService;
using Zenject;

namespace Platformer.Infrastructure.Installers
{
    public class GameServiceInstaller : Installer<GameServiceInstaller>
    {
        #region Public methods

        public override void InstallBindings()
        {
            Container.Bind<GameService>().AsSingle();
            Container.Bind<SoundService>().AsSingle();
        }

        #endregion
    }
}

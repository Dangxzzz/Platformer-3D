using Platformer.Services.InputService;
using Platformer.Services.LevelManagerService;
using Platformer.Services.SoundServiceFolder;
using Zenject;

namespace Platformer.Infrastructure.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        #region Public methods

        public override void InstallBindings()
        {
            InputServiceInstaller.Install(Container);
            LevelServiceInstaller.Install(Container);
            SoundServiceInstaller.Install(Container);
        }

        #endregion
    }
}

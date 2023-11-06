using Platformer.Services.InputService;
using Zenject;

namespace Platformer.Infrastructure.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        #region Public methods

        public override void InstallBindings()
        {
            InputServiceInstaller.Install(Container);
        }

        #endregion
    }
}

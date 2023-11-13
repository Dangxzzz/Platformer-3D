using Platformer.Services.InputService;
using UnityEngine;
using Zenject;

namespace Platformer.Services.LevelManagerService
{
    public class LevelServiceInstaller : Installer<LevelServiceInstaller>
    {
        
        public override void InstallBindings()
        {
            Container.Bind<LevelService>().AsSingle();
        }

    }
}

using System.ComponentModel;
using Zenject;

namespace Platformer.Services.Bootstrap
{
    public class BootstrapServiceInstaller : Installer<BootstrapServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<BootstrapService>().AsSingle();
        }
    }
}

using Zenject;

namespace Platformer.Services.SoundServiceFolder
{
    public class SoundServiceInstaller: Installer<SoundServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<SoundService>().AsSingle().WithArguments(Container.DefaultParent);
        }
    }
}
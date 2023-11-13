using Platformer.Services.Bootstrap;
using UnityEngine;
using Zenject;

namespace Platformer.Infrastructure.Installers
{
    public class BootstrapSceneInstaller : MonoInstaller
    {
        #region Public methods

        public override void InstallBindings()
        {
            BootstrapServiceInstaller.Install(Container);
        }

        #endregion
    }
}

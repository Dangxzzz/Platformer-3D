using Platformer.Services.Bootstrap;
using UnityEngine;
using Zenject;

namespace Platformer.Infrastructure.SceneController
{
    public class BootstrapSceneController : MonoBehaviour
    {
        #region Variables

        private BootstrapService _bootstrapService;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(BootstrapService bootstrapService)
        {
            _bootstrapService = bootstrapService;
        }

        #endregion

        #region Unity lifecycle

        private void Start()
        { 
            _bootstrapService.Bootstrap();
        }

        #endregion
    }
}
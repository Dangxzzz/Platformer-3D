using Platformer.App.Scripts.Services.SoundServiceFolder;
using Platformer.Services.SoundServiceFolder;
using UnityEngine;
using Zenject;

namespace Platformer.Infrastructure.SceneController
{
    public class GameSceneController : MonoBehaviour
    {
        #region Variables

        private SoundService _soundService;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(SoundService soundService)
        {
            _soundService = soundService;
        }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _soundService.Init();
        }

        #endregion
    }
}
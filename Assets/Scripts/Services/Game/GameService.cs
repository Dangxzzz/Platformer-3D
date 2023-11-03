using Cysharp.Threading.Tasks;
using Platformer.Services.SceneLoader;
using UnityEngine;

namespace Platformer.Services.Game
{
    public class GameService
    {
        #region Variables

        private readonly SceneLoaderService _sceneLoader;

        #endregion

        #region Setup/Teardown

        public GameService(SceneLoaderService sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        #endregion

        #region Public methods

        public void TransitionToGame()
        {
            _sceneLoader.LoadSceneAsync(SceneName.Game).Forget();
        }

        #endregion
    }
}

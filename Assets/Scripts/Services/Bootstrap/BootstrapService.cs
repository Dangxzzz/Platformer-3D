using Cysharp.Threading.Tasks;
using Platformer.Services.Game;

namespace Platformer.Services.Bootstrap
{
    public class BootstrapService
    {
        #region Variables

        private readonly GameService _gameService;

        #endregion

        #region Setup/Teardown

        public BootstrapService(GameService gameService)
        {
            _gameService = gameService;
        }

        #endregion

        #region Public methods

        public void Bootstrap()
        {
            BootstrapAsync().Forget();
        }

        #endregion

        #region Private methods

        private async UniTask BootstrapAsync()
        {
            _gameService.TransitionToGame();
        }

        #endregion
    }
}
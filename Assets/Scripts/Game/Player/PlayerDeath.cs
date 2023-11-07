
using Platformer.Services.LevelManagerService;
using Platformer.Services.SoundService;
using UnityEngine;
using Zenject;

namespace Platformer.Game.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private GameObject _deathEffect;
        private Vector3 _startPosition;
        private LevelService _levelService;
        private SoundService _soundService;
        private bool _isDeathHandled = false;

        [Inject]
        public void Construct(LevelService levelService,SoundService soundService)
        {
            _levelService = levelService;
            _soundService = soundService;
        }

        public void PlayDeath()
        {
                // _soundService.PlayLoseSound();
                _levelService.OnDeathHappened();
                transform.position = _startPosition;
                Instantiate(_deathEffect, transform.position, Quaternion.Euler(-90f, 0, 0));
                _levelService.RestartGame();
        }
        
    }
}


using System;
using Platformer.App.Scripts.Services.SoundServiceFolder;
using Platformer.Services.LevelManagerService;
using Platformer.Services.SoundServiceFolder;
using UnityEngine;
using Zenject;

namespace Platformer.Game.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private GameObject _deathEffect;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private Transform _startPoint;
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

        private void Start()
        {
            _startPosition = transform.position;
        }

        public void PlayDeath()
        {
                _soundService.PlaySound(SoundType.Lose);
                _levelService.OnDeathHappened();
                _playerMovement.Teleport(_startPoint);
                Instantiate(_deathEffect, transform.position, Quaternion.Euler(-90f, 0, 0));
                _levelService.RestartGame();
        }
        
    }
}

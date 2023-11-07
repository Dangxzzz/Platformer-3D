using System;
using Platformer.Services.LevelManagerService;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Platformer.Game.Player
{
    public class FallChecker : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private PlayerDeath _playerDeath;

        [SerializeField] private float _fallHeightThreshold = 10f;
        private float _groundedPosition;
        private float _differencePosition;
        private float _startPosition;
        private LevelService _levelService;
        private bool _isDead;

        [Inject]
        public void Construct(LevelService levelService)
        {
            _levelService = levelService;
        }
        private void Start()
        {
            _startPosition = transform.position.y;
            _groundedPosition = _startPosition;
        }

        private void Update()
        {
            if (!_levelService.IsDead)
            {
                CheckHeight();
            }
        }

        private void CheckHeight()
        {
            if (_movement.IsGrounded)
            {
                _differencePosition = _groundedPosition - transform.position.y;
                if (_differencePosition > _fallHeightThreshold)
                {
                    _playerDeath.PlayDeath();
                }
                else
                {
                    _groundedPosition = transform.position.y;
                }
            }
        }
    }
}

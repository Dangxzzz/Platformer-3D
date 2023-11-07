using System;
using DG.Tweening;
using Platformer.Game.Player;
using Unity.VisualScripting;
using UnityEngine;

namespace Platformer.Level
{
    public class Door : MonoBehaviour
    {
        #region Variables

        [Header("Config")]
        [SerializeField] private bool _isDamaged;
        
        [Header("Animation")]
        [SerializeField] private Vector3 _startPosition;
        [SerializeField] private Vector3 _endPosition;
        [SerializeField] private float _animationDuration;
        [SerializeField] private float _shakeDuration;
        [SerializeField] private float _shakeStrength;
        

        private Tween _tween;

        #endregion

        #region Public methods

        public void OnTriggerEnter(Collider other)
        {
            if (_isDamaged && other.TryGetComponent(out PlayerDeath playerDeath))
            {
               playerDeath.PlayDeath();
            }
        }

        private void OnDisable()
        {
            _tween?.Kill();
            _tween = null;
        }

        public void Close()
        {
            transform.DOShakePosition(_shakeDuration, _shakeStrength)
                .OnComplete(() =>
                {
                    _tween?.Kill();
                    _tween = transform
                        .DOMove(_startPosition, _animationDuration)
                        .SetUpdate(UpdateType.Fixed);
                });
        }

        public void Open()
        {
            _tween?.Kill();
            _tween = transform
                .DOMove(_endPosition, _animationDuration)
                .SetUpdate(UpdateType.Fixed);
        }

        #endregion
    }
}
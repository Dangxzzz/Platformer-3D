using System;
using DG.Tweening;
using UnityEngine;

namespace Platformer.Level
{
    public class FalledPlatform : MonoBehaviour
    {
        #region Variables
        
        [Header("Animation")]
        [SerializeField] private Vector3 _startPosition;
        [SerializeField] private Vector3 _endPosition;
        [SerializeField] private float _animationDuration;
        [SerializeField] private float _unclickDelay;
        [SerializeField] private float _shakeDuration;
        [SerializeField] private float _shakeStrength;
        
        private Tween _tween;

        #endregion

        #region Unity lifecycle

        private void OnDestroy()
        {
            _tween?.Kill();
            _tween = null;
        }

        private void OnTriggerEnter(Collider other)
        {
            PlayFallAnimation();
        }
        
        #endregion

        #region Private methods
        
        private void PlayFallAnimation()
        {
            _tween?.Kill();
            
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOShakePosition(_shakeDuration, _shakeStrength));
            sequence.Append(transform.DOMove(_endPosition, _animationDuration)
                .SetUpdate(UpdateType.Fixed));
            sequence.AppendCallback(() => PlayUnfallAnimation());

            _tween = sequence;
        }
        
        private void PlayUnfallAnimation()
        {
            _tween?.Kill();
            _tween = transform
                .DOMove(_startPosition, _animationDuration)
                .SetUpdate(UpdateType.Fixed)
                .SetDelay(_unclickDelay);
        }
        
        #endregion
    }
}

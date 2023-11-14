using System;
using DG.Tweening;
using UnityEngine;

namespace Platformer.App.Scripts.Level
{
    public class Hammer : MonoBehaviour
    {
        [SerializeField] private int swingDirection = 1;
        [SerializeField] private float swingAngle = 45f;
        [SerializeField] private float swingDuration = 2f;
        [SerializeField] private Transform _pivot;

        private Tween _tween;
        private float _startRotation;
        void Start()
        {
            _startRotation = transform.rotation.eulerAngles.x;
            SwingPendulum();
            Debug.Log(_startRotation);
        }

        private void OnDestroy()
        {
            _tween?.Kill();
            _tween = null;
        }

        void SwingPendulum()
        {
            float endRotation = swingDirection * swingAngle;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DORotate(new Vector3(_startRotation+endRotation,_startRotation, 0), swingDuration)
                .SetEase(Ease.InOutQuad));
            sequence.OnComplete(() =>
            {
                swingDirection *= -1;
                SwingPendulum();
            });
            _tween = sequence;
        }
    }
}

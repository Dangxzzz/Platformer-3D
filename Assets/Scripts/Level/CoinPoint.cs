using System;
using DG.Tweening;
using Platformer.Services.LevelManagerService;
using Platformer.Services.SoundService;
using UnityEngine;
using Zenject;

namespace Platformer.Level
{
    public class CoinPoint :MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 100f;
        [SerializeField] private float _bounceHeight = 0.1f;
       [SerializeField] private float _bounceDuration = 1.0f;
       private LevelService _levelService;
       private SoundService _soundService;
       private Tween _tween;
       
       [Inject]
       public void Construct(LevelService levelService,SoundService soundService)
       {
           _levelService = levelService;
           _soundService = soundService;
       }
  

       private void OnDestroy()
       {
           _tween?.Kill();
           _tween = null;
       }

       private void Start()
        {
            _levelService.OnCoinCreated(this);
            RotateCoin();
            BounceCoin();
        }
        
        private void RotateCoin()
        {
            _tween=transform.DORotate(new Vector3(0, 360, 0), _rotationSpeed, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
        }

        private void BounceCoin()
        {
            _tween=transform.DOMoveY(transform.position.y + _bounceHeight, _bounceDuration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutQuad);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                // _soundService.PlayCoinSound();
                gameObject.SetActive(false);
                _levelService.OnPickCoin(this);
            }
        }
    }
}
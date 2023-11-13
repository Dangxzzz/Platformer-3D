using System;
using DG.Tweening;
using Platformer.Services.LevelManagerService;
using Platformer.Services.SoundServiceFolder;
using UnityEngine;
using Zenject;

namespace Platformer.Level
{
    public class CoinPoint :MonoBehaviour
    {
        private const string Player = "Player";
        
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
            BounceCoin();
        }
        
     

        private void BounceCoin()
        {
            Sequence sequence = DOTween.Sequence();
            _tween = sequence;
            
            sequence.Append(transform.DOMoveY(transform.position.y + _bounceHeight, _bounceDuration)
                .SetLoops(int.MaxValue, LoopType.Yoyo)
                .SetEase(Ease.InOutQuad));

            sequence.Join(transform.DORotate(new Vector3(0, 360, 0), _rotationSpeed, RotateMode.FastBeyond360)
                .SetLoops(int.MaxValue, LoopType.Restart)
                .SetEase(Ease.Linear));
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Player))
            {
                _soundService.PlaySound(SoundType.Coin);
                gameObject.SetActive(false);
                _levelService.OnPickCoin(this);
            }
        }
    }
}
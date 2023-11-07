using System;
using System.Collections.Generic;
using Platformer.Level;
using Platformer.Services.SceneLoader;
using UnityEngine;
using Zenject;

namespace Platformer.Services.LevelManagerService
{
    public class LevelService
    {
        private SceneLoaderService _sceneLoaderService;
        private  List<CoinPoint> _coins = new();
        private List<CoinPoint> _deactivatedCoins = new List<CoinPoint>();
        private bool _isDead;

        public event Action OnLevelComplite;
        [Inject]
        public void Construct(SceneLoaderService sceneLoaderService)
        {
            _sceneLoaderService = sceneLoaderService;
        }
        public void OnCoinCreated(CoinPoint coin)
        {
            _coins.Add(coin);
        }
        public bool IsDead => _isDead;
        public void OnDeathHappened()
        {
            _isDead = true;
        }

        public void RestartGame()
        {
            SetStartParameters();
        }
        private void SetStartParameters()
        {
            _isDead = false;
            ReactivateDeactivatedCoins();
        }

        public void OnPickCoin(CoinPoint coin)
        {
            _coins.Remove(coin);
            if (_coins.Count <= 0)
            {
                Debug.Log("Complete");
                OnLevelComplite?.Invoke();
            }
            _deactivatedCoins.Add(coin);
        }
        private void ReactivateDeactivatedCoins()
        {
            foreach (CoinPoint coin in _deactivatedCoins)
            {
                coin.gameObject.SetActive(true);
            }
            _deactivatedCoins.Clear();
        }

        public void LoadNextLevel()
        {
            _sceneLoaderService.LoadNextSceneAsync();
        }
    }
}

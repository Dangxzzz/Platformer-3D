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
        #region Variables

        private readonly List<CoinPoint> _coins = new();
        private readonly List<CoinPoint> _deactivatedCoins = new();
        private bool _isDead;
        private SceneLoaderService _sceneLoaderService;

        #endregion

        #region Events

        public event Action OnLevelComplite;

        #endregion

        #region Properties

        public bool IsDead => _isDead;

        #endregion

        #region Public methods

        [Inject]
        public void Construct(SceneLoaderService sceneLoaderService)
        {
            _sceneLoaderService = sceneLoaderService;
        }
        public void OnCoinCreated(CoinPoint coin)
        {
            _coins.Add(coin);
        }

        public void OnDeathHappened()
        {
            _isDead = true;
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

        public void RestartGame()
        {
            SetStartParameters();
        }

        #endregion

        #region Private methods

        private void ReactivateDeactivatedCoins()
        {
            foreach (CoinPoint coin in _deactivatedCoins)
            {
                coin.gameObject.SetActive(true);
            }

            _deactivatedCoins.Clear();
        }

        private void SetStartParameters()
        {
            _isDead = false;
            ReactivateDeactivatedCoins();
        }

        #endregion
    }
}
using System;
using Platformer.Services.LevelManagerService;
using UnityEngine;
using Zenject;

namespace Platformer.Level
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private GameObject _portal;
        
        private LevelService _levelService;
        [Inject]
        public void Construct(LevelService levelService)
        {
            _levelService = levelService;
        }

        private void Start()
        {
            _levelService.OnLevelComplite += ActivatePortal;
        }

        private void OnDestroy()
        {
            _levelService.OnLevelComplite -= ActivatePortal;
        }

        private void ActivatePortal()
        {
           _portal.SetActive(true);
        }

        private void OnTriggerEnter(Collider other)
        {
            _levelService.LoadNextLevel();
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.App.Scripts.UI
{
    public class SettingsButtonController : MonoBehaviour
    {
        [SerializeField] private Button _settingsButton;
        [SerializeField] private GameObject _settingsScreen;

        private bool _isActive;

        private void Start()
        {
            _settingsButton.onClick.AddListener(OnSettingsButtonClick);
        }

        private void OnSettingsButtonClick()
        {
            _isActive = !_isActive;
            _settingsScreen.SetActive(_isActive);
        }
    }
}

using Platformer.Services.SoundServiceFolder;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Platformer.App.Scripts.UI
{
    public class SettingsScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Slider _soundSlider;

        private SoundService _soundService;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(SoundService soundService)
        {
            _soundService = soundService;
        }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _soundSlider.onValueChanged.AddListener(OnSoundSliderChanged);
        }

        private void OnEnable()
        {
            _soundSlider.value = _soundService.SoundVolume;
        }

        #endregion

        #region Private methods

        private void OnSoundSliderChanged(float value)
        {
            _soundService.SetSoundVolume(value);
        }

        #endregion
    }
}
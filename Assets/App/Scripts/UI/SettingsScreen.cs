using Platformer.App.Scripts.Services.SoundServiceFolder;
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
        [SerializeField] private Slider _musicSlider;

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
            _musicSlider.onValueChanged.AddListener(OnMusicSliderChanged);
        }

        private void OnMusicSliderChanged(float value)
        {
            _soundService.SetSoundVolume(value);
        }

        private void OnEnable()
        {
            _musicSlider.value = _soundService.MusicVolume;
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
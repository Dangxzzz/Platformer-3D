using UnityEngine;

namespace Platformer.Services.SoundService
{
    public class SoundService
    {
        private const string ConfigPath = "SoundConfig";
        
        private bool _isConfigLoaded;
        private SoundServiceConfig _config;
        private AudioSource _audioSource;
        public SoundService(AudioSource source)
        {
            _audioSource = source;
        }
        private void LoadConfig()
        {
            Debug.Log("Load");
            if (_isConfigLoaded)
            {
                return;
            }
            _config = Resources.Load<SoundServiceConfig>(ConfigPath);
            _isConfigLoaded = true;
        }
        public void PlayCoinSound()
        {
            PlaySfx(_config.coinSound);
        }

        public void PlayLoseSound()
        {
            PlaySfx(_config.loseSound);
        }

        public void PlayButtonSound()
        {
            PlaySfx(_config.buttonSound);
        }
        
        public void PlaySfx(AudioClip clip)
        {
            LoadConfig();
            _audioSource.PlayOneShot(clip);
        }
    }
}
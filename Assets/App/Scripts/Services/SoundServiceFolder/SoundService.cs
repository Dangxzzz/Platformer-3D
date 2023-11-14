using System.Collections;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using ModestTree;
using Platformer.Services.SoundServiceFolder;
using UnityEngine;

namespace Platformer.App.Scripts.Services.SoundServiceFolder
{
    public class SoundService
    {
        #region Variables

        private const string ConfigPath = "Configs/Audio/SoundConfig";
        private const string MusicConfigPath = "Configs/Audio/MusicConfig";
        private const string SoundPrefsKey = "Audio/SoundVolume";
        private const string MusicPrefsKey = "Audio/MusicVolume";

        private SoundServiceConfig _configSounds;
        private MusicSourseConfig _musicSourseConfig;
        private AudioSource _musicAudioSource;

        private readonly Transform _rootTransform;
        private Transform _serviceRootTransform;
        private AudioSource _soundAudioSource;
        
        AudioClip _prevMusic;

        #endregion

        #region Properties

        public float SoundVolume
        {
            get => PlayerPrefs.GetFloat(SoundPrefsKey, 1);
            private set => PlayerPrefs.SetFloat(SoundPrefsKey, value);
        }

        public float MusicVolume
        {
            get => PlayerPrefs.GetFloat(MusicPrefsKey, 1);
            private set => PlayerPrefs.SetFloat(MusicPrefsKey, value);
        }

        #endregion

        #region Setup/Teardown

        public SoundService(Transform rootTransform)
        {
            _rootTransform = rootTransform;
        }

        #endregion

        #region Public methods

        public void Init()
        {
            LoadConfig();
            CreateRootObject();
            CreateSoundSource();
            CreateMusicSource();
        }

        public void PlaySound(SoundType type)
        {
            AudioClip clip = _configSounds.GetSound(type);
            PlaySoundClip(clip);
        }

        public void SetSoundVolume(float value)
        {
            SoundVolume = value;
            MusicVolume = value;
            _soundAudioSource.volume = SoundVolume;
            _musicAudioSource.volume = MusicVolume;
        }

        #endregion

        #region Private methods

        private async void CreateMusicSource()
        {
            GameObject go = new("MusicSource");
            _musicAudioSource = go.AddComponent<AudioSource>();
            _musicAudioSource.volume = MusicVolume;
            go.transform.SetParent(_serviceRootTransform);
            _musicAudioSource.loop = false;
            
            await StartMusic().ConfigureAwait(false);
        }
        
        
        private async Task StartMusic()
        {
            if (_musicSourseConfig != null)
            {
                int randomIndex = Random.Range(0, _musicSourseConfig.AudioClips.Count);
                _musicAudioSource.clip = _musicSourseConfig.AudioClips[randomIndex];
                if (_musicAudioSource.clip == _prevMusic)
                {
                    await StartMusic();
                }
                _prevMusic = _musicAudioSource.clip;
            }
            
            _musicAudioSource.Play();
            
            await UniTask.Delay((int)(_musicAudioSource.clip.length * 1000));
            await StartMusic().ConfigureAwait(false);
            
        }
        
        
        private void CreateRootObject()
        {
            _serviceRootTransform = new GameObject($"[{nameof(SoundService)}]").transform;
            _serviceRootTransform.SetParent(_rootTransform);
        }

        private void CreateSoundSource()
        {
            GameObject go = new("SoundsSource");
            _soundAudioSource = go.AddComponent<AudioSource>();
            _soundAudioSource.volume = SoundVolume;
            go.transform.SetParent(_serviceRootTransform);
        }

        private void LoadConfig()
        {
            Debug.LogError("LoadConfig");
            _configSounds = Resources.Load<SoundServiceConfig>(ConfigPath);
            _musicSourseConfig = Resources.Load<MusicSourseConfig>(MusicConfigPath);
            Assert.IsNotNull(_configSounds, $"{nameof(SoundService)}: {nameof(SoundServiceConfig)} is null " +
                                      $"on path '{ConfigPath}'");
        }

        private void PlaySoundClip(AudioClip clip)
        {
            if (clip == null)
            {
                return;
            }

            _soundAudioSource.PlayOneShot(clip);
        }

        #endregion
    }
}
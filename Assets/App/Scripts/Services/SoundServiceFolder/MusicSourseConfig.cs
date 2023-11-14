using System.Collections.Generic;
using UnityEngine;

namespace Platformer.App.Scripts.Services.SoundServiceFolder
{    
    [CreateAssetMenu(fileName = nameof(MusicSourseConfig), menuName = "Platformer/Game/MusicConfig")]
    public class MusicSourseConfig:ScriptableObject
    {
        [SerializeField] private List<AudioClip> _audioClips;

        public List<AudioClip> AudioClips => _audioClips;
    }
}
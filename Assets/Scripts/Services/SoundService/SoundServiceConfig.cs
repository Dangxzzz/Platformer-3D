using UnityEngine;

namespace Platformer.Services.SoundService
{
    [CreateAssetMenu(fileName = nameof(SoundServiceConfig), menuName = "Platformer/Game/SoundConfig")]
    public class SoundServiceConfig :ScriptableObject 
    {
        public AudioClip loseSound;
        public AudioClip buttonSound;
        public  AudioClip coinSound;
    }
}
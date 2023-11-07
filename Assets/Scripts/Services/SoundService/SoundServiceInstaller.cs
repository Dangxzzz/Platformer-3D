using System.ComponentModel;
using Platformer.Services.InputService;
using UnityEngine;
using Zenject;

namespace Platformer.Services.SoundService
{
    public class SoundServiceInstaller: MonoInstaller
    {
        [SerializeField] private AudioSource audioSource;
        public override void InstallBindings()
        {
            Container.Bind<SoundService>().AsSingle().WithArguments(audioSource);
        }
    }
}
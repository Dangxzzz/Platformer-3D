using System;
using Platformer.Game.Player;
using UnityEngine;

namespace Platformer.App.Scripts.Level
{
    public class Teleport : MonoBehaviour
    {
        [SerializeField] private Transform _teleportPosition;
        [SerializeField] private GameObject _effect;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out PlayerMovement _))
            {
                other.GetComponent<PlayerMovement>().Teleport(_teleportPosition);
                SetEffect(_effect);
            }
        }

        private void SetEffect(GameObject effect)
        {
            Instantiate(effect, _teleportPosition.transform);
        }
    }
}

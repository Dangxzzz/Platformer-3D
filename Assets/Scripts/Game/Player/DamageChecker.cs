using UnityEngine;

namespace Platformer.Game.Player
{
    public class FallChecker : MonoBehaviour
    {
        #region Variables

        private const string DeathCollider = "DeathCollider";

        [SerializeField] private PlayerDeath _playerDeath;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(DeathCollider))
            {
                _playerDeath.PlayDeath();
            }
        }

        #endregion
    }
}
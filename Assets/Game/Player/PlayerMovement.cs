using Platformer.Services.InputService;
using UnityEngine;
using Zenject;

namespace Platformer.Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _gravityMultiplier = 1f;

        [Header("Ground")]
        [SerializeField] private Transform _checkGroundTransform;
        [SerializeField] private float _checkGroundRadius = 1f;
        [SerializeField] private LayerMask _checkGroundLayerMask;

        [Header("Jump")]
        [SerializeField] private float _jumpHeight = 2f;

        private Vector3 _fallVector;
        private IInputService _inputService;
        private bool _isGrounded;
        private bool _isTeleport;

        private Vector3 _moveVector;

        #endregion

        #region Properties

        public bool IsGrounded => _isGrounded;

        public Vector3 Velocity => _moveVector;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (!_isTeleport)
            {
                Vector2 axis = _inputService.Axes;
                _moveVector = transform.right * axis.x + transform.forward * axis.y;
                _moveVector *= _speed;

                // _characterController.Move(_moveVector * Time.deltaTime);

                _isGrounded =
                    Physics.CheckSphere(_checkGroundTransform.position, _checkGroundRadius, _checkGroundLayerMask);

                if (_isGrounded && _fallVector.y < 0)
                {
                    _fallVector.y = 0;
                }

                float gravity = Physics.gravity.y * _gravityMultiplier;

                if (_isGrounded && _inputService.IsJump)
                {
                    _fallVector.y = Mathf.Sqrt(_jumpHeight * -3f * gravity);
                }

                _fallVector.y += gravity * Time.deltaTime;
                // _characterController.Move(_fallVector * Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            if (!_isTeleport)
            {
                _characterController.Move(_moveVector * Time.fixedDeltaTime);
                _characterController.Move(_fallVector * Time.fixedDeltaTime);
            }
        }

        private void OnDrawGizmos()
        {
            if (_checkGroundTransform != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(_checkGroundTransform.position, _checkGroundRadius);
            }
        }

        #endregion

        #region Public methods

        public void Teleport(Transform teleportPosition)
        {
            _characterController.enabled = false;
            transform.position = teleportPosition.position;
            _characterController.Move(teleportPosition.position);
            transform.position = teleportPosition.position;
            _characterController.enabled = true;
        }

        #endregion
    }
}
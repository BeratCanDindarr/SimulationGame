using SimulationGame.Interface;
using SimulationGame.Settings;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace SimulationGame.View
{
    public class PlayerView : BaseView
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Rigidbody _rigidbody;
        private bool _isGrounded;
        private bool _isReadyToJump;
        private float _xRotation;
        private float _yRotation;
        #region Injection

        private PlayerSettings _playerSettings;

        [Inject]
        public void Construct(PlayerSettings playerSettings)
        {
            _playerSettings = playerSettings;
        }

        #endregion

        public void Init()
        {
            _rigidbody.freezeRotation = true;
            _signalBus.Subscribe<JumpButtonClickedSignal>(Jump);
        }

        public void GroundCheck()
        {
            _isGrounded = Physics.Raycast(transform.position, Vector3.down,_playerSettings.PlayerHeight*0.5f +0.2f, _playerSettings.GroundLayer);
            if (_isGrounded)
            {
                _rigidbody.linearDamping = _playerSettings.GroundDrag;
                _isReadyToJump = true;
            }
            else _rigidbody.linearDamping = 0;
        }
        public void Move(Vector2 move)
        {
            if(move is { x: 0, y: 0 }) return;
            
            var moveDirection = transform.forward * move.y + transform.right * move.x;
            _rigidbody.AddForce(moveDirection.normalized * _playerSettings.PlayerSpeed * Time.deltaTime,ForceMode.Force);
        }

        public void SpeedControl()
        {
            Vector3 flatVel = new Vector3(_rigidbody.linearVelocity.x, 0, _rigidbody.linearVelocity.z);
            if (flatVel.magnitude > _playerSettings.PlayerSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * _playerSettings.PlayerSpeed;
                _rigidbody.linearVelocity = limitedVel;
            }
        }

        private void Jump()
        {
            _rigidbody.linearVelocity = new Vector3(_rigidbody.linearVelocity.x, 0, _rigidbody.linearVelocity.z);
            _rigidbody.AddForce(transform.up * _playerSettings.PlayerJumpForce, ForceMode.Impulse);
            _isReadyToJump = false;
        }

        public void Look(Vector2 look)
        {
            Debug.Log("x:" + look.x + " y:" + look.y);
            if(look is { x: 0, y: 0 }) return;
            
            var mouseX = look.x * Time.fixedDeltaTime * _playerSettings.PlayerLookSensitivity;
            var mouseY = look.y * Time.fixedDeltaTime * _playerSettings.PlayerLookSensitivity;
            _yRotation += mouseX;
            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90, 90);
            
            _camera.transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
            transform.rotation = Quaternion.Euler(0,_yRotation,0);
        }

        protected override void Dispose()
        {
            _signalBus.Unsubscribe<JumpButtonClickedSignal>(Jump);
        }
    }
}
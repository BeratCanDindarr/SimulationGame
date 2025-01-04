using SimulationGame.Settings;
using UnityEngine;
using Zenject;

namespace SimulationGame.View
{
    public class PlayerView : BaseView
    {
        [SerializeField] private Camera _camera;
        private float _pitch;
        #region Injection

        private PlayerSettings _playerSettings;

        [Inject]
        public void Construct(PlayerSettings playerSettings)
        {
            _playerSettings = playerSettings;
        }

        #endregion
        public void Move(Vector2 move)
        {
            if(move is { x: 0, y: 0 }) return;
            transform.position += new Vector3(move.x,0,move.y)* _playerSettings.PlayerSpeed * Time.deltaTime;
        }

        public void Look(Vector2 look)
        {
            Debug.Log("x:" + look.x + " y:" + look.y);
            if(look is { x: 0, y: 0 }) return;
            transform.Rotate(Vector3.up * look.x * _playerSettings.PlayerLookSensitivity * Time.fixedDeltaTime);
            
            _pitch -= look.y * _playerSettings.PlayerLookSensitivity * Time.deltaTime;
            _pitch = Mathf.Clamp(_pitch, -90, 90);
            _camera.transform.localEulerAngles = new Vector3(_pitch,_camera.transform.localEulerAngles.y, 0);
        }

    }
}
using SimulationGame.Settings;
using UnityEngine;
using Zenject;

namespace SimulationGame.View
{
    public class PlayerView : BaseView
    {
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
            if(look is { x: 0, y: 0 }) return;
            
        }

    }
}
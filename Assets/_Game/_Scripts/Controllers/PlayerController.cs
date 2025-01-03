using SimulationGame.Interface;
using SimulationGame.View;
using SimulationGame.Settings;
using UnityEngine;
using Zenject;

namespace SimulationGame.Controller
{
    public class PlayerController : IUpdate
    {
        private PlayerView _playerView;
        #region Injection

        private InputController _inputController;
        private GameLoopView _gameLoopView;
        private PlayerSettings _playerSettings;
        private DiContainer _diContainer;
        [Inject]
        public void Construct(InputController inputController
            , GameLoopView gameLoopView
            , PlayerSettings playerSettings
            , DiContainer diContainer)
        {
            _inputController = inputController;
            _gameLoopView = gameLoopView;
            _playerSettings = playerSettings;
            _diContainer = diContainer;
        }

        #endregion
        
        public void Init()
        {
            CreatePlayer();
            _gameLoopView.Subscribe(this);
        }

        private void CreatePlayer()
        {
            _playerView = _diContainer.InstantiatePrefabForComponent<PlayerView>(_playerSettings.playerReference);
        }

        public void Update()
        {
            //Debug.Log("Input Control:" + _inputController.GetMovementInput());
            _playerView.Move(_inputController.GetMovementInput());
            _playerView.Look(_inputController.GetLookInput());
        }

     

        public void Dispose()
        {
            _gameLoopView.Unsubscribe(this);
        }
    }
}
using SimulationGame.Interface;
using SimulationGame.View;
using SimulationGame.Settings;
using UnityEngine;
using Zenject;

namespace SimulationGame.Controller
{
    public class PlayerController : IUpdate,IFixedUpdate
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
            _gameLoopView.Subscribe((IUpdate)this);
            _gameLoopView.Subscribe((IFixedUpdate)this);
        }

        private void CreatePlayer()
        {
            _playerView = _diContainer.InstantiatePrefabForComponent<PlayerView>(_playerSettings.playerReference);
        }

        public void Update()
        {
            _playerView.Move(_inputController.GetMovementInput());
        }
        public void FixedUpdate()
        {
            _playerView.Look(_inputController.GetLookInput());
        }

     

        public void Dispose()
        {
            _gameLoopView.Unsubscribe((IUpdate)this);
            _gameLoopView.Unsubscribe((IFixedUpdate)this);
        }

        
    }
}
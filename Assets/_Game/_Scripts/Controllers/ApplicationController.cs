using SimulationGame.Settings;
using UnityEngine;

namespace SimulationGame.Controller
{
    public class ApplicationController: BaseController
    {

        #region Injection

        private readonly GameSettings _gameSettings;
        private readonly PlayerMovementController _playerMovementController;
        private readonly InputController _inputController;
        public ApplicationController(GameSettings gameSettings
            , PlayerMovementController playerMovementController
            , InputController inputController)
        {
            _gameSettings = gameSettings;
            _playerMovementController = playerMovementController;
            _inputController = inputController;
        }

        #endregion

        public override void Initialize()
        {
            Debug.Log("Application Initialized");
            Debug.Log(_gameSettings.ID);
            _inputController.Init();
            _playerMovementController.Init();
        }

        public override void Dispose()
        {
            
        }
    }
}
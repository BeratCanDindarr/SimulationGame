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
        private readonly DataController _dataController;
        public ApplicationController(GameSettings gameSettings
            , PlayerMovementController playerMovementController
            , InputController inputController
            , DataController dataController)
        {
            _gameSettings = gameSettings;
            _playerMovementController = playerMovementController;
            _inputController = inputController;
            _dataController = dataController;
        }

        #endregion

        public override void Initialize()
        {
            //Load Data
            _dataController.Init();
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
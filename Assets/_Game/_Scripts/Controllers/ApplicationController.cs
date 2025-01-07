using SimulationGame.Settings;
using UnityEngine;

namespace SimulationGame.Controller
{
    public class ApplicationController: BaseController
    {

        #region Injection

        private readonly GameSettings _gameSettings;
        private readonly PlayerController _playerController;
        private readonly InputController _inputController;
        private readonly DataController _dataController;
        private readonly TimerController _timerController;
        private readonly DailyCycleController _dailyCycleController;
        
        public ApplicationController(GameSettings gameSettings
            , PlayerController playerController
            , InputController inputController
            , DataController dataController
            , TimerController timerController
            , DailyCycleController dailyCycleController)
        {
            _gameSettings = gameSettings;
            _playerController = playerController;
            _inputController = inputController;
            _dataController = dataController;
            _timerController = timerController;
            _dailyCycleController = dailyCycleController;
        }

        #endregion

        public override void Initialize()
        {
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
            //Load Data
            _timerController.Init();
            _dataController.Init();
            Debug.Log("Application Initialized");
            Debug.Log(_gameSettings.ID);
            _inputController.Init();
            _playerController.Init();
            _dailyCycleController.Init();
            
        }

        public override void Dispose()
        {
            
        }
    }
}
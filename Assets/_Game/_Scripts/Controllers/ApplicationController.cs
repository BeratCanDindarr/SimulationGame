using SimulationGame.Settings;
using SimulationGame.View;
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
        private readonly SkyBoxView _skyBoxView;
        
        public ApplicationController(GameSettings gameSettings
            , PlayerController playerController
            , InputController inputController
            , DataController dataController
            , TimerController timerController
            , DailyCycleController dailyCycleController
            , SkyBoxView skyBoxView)
        {
            _gameSettings = gameSettings;
            _playerController = playerController;
            _inputController = inputController;
            _dataController = dataController;
            _timerController = timerController;
            _dailyCycleController = dailyCycleController;
            _skyBoxView = skyBoxView;
        }

        #endregion

        public override void Initialize()
        {
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
            //Load Data
            _skyBoxView.Init();
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
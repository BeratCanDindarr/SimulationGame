using SimulationGame.Settings;
using UnityEngine;

namespace SimulationGame.Controller
{
    public class ApplicationController: BaseController
    {

        #region Injection

        private readonly GameSettings _gameSettings;
        public ApplicationController(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }

        #endregion

        public override void Initialize()
        {
            Debug.Log("Application Initialized");
            Debug.Log(_gameSettings.ID);
        }

        public override void Dispose()
        {
            
        }
    }
}
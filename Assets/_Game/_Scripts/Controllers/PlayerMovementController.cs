using SimulationGame.Interface;
using SimulationGame.View;
using UnityEngine;
using Zenject;

namespace SimulationGame.Controller
{
    public class PlayerMovementController : IUpdate
    {
        #region Injection

        private InputController _inputController;
        private GameLoopView _gameLoopView;
        [Inject]
        public void Construct(InputController inputController
            , GameLoopView gameLoopView)
        {
            _inputController = inputController;
            _gameLoopView = gameLoopView;
        }

        #endregion

        public void Init()
        {
            _gameLoopView.Subscribe(this);
        }
        
        public void Update()
        {
            Debug.Log("Input Control:" + _inputController.GetMovementInput());
        }


        public void Dispose()
        {
            _gameLoopView.Unsubscribe(this);
        }
    }
}
using SimulationGame.Interface;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace SimulationGame.Controller
{
    public class InputController
    {
        private InputSystem_Actions _inputSystemActions;

        #region Inject

        private SignalBus _signalBus;

        public InputController(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        #endregion
        public void Init()
        {
            _inputSystemActions = new InputSystem_Actions();
            _inputSystemActions.Player.Enable();
            MouseLeftClickSubscribe();
            JumpButtonClickSubscribe();
        }

        private void JumpButtonClickSubscribe()
        {
            _inputSystemActions.Player.Jump.started += context => _signalBus.Fire<JumpButtonClickedSignal>();
        }

        private void MouseLeftClickSubscribe()
        {
            _inputSystemActions.Player.Attack.Enable();
            _inputSystemActions.Player.Attack.started += context => _signalBus.Fire<LeftClickDownSignal>();
            _inputSystemActions.Player.Attack.performed += context => Debug.Log("Left Click Pressed");
            _inputSystemActions.Player.Attack.canceled += context => _signalBus.Fire<LeftClickUpSignal>();
        }

        public Vector2 GetMovementInput() => _inputSystemActions.Player.Move.ReadValue<Vector2>();
        public Vector2 GetLookInput() => _inputSystemActions.Player.Look.ReadValue<Vector2>();
        
    }
}

using UnityEngine;

namespace SimulationGame.Controller
{
    public class InputController
    {
        private InputSystem_Actions _inputSystemActions;

        public void Init()
        {
            _inputSystemActions = new InputSystem_Actions();
            _inputSystemActions.Player.Enable();
        }
        
        public Vector2 GetMovementInput() => _inputSystemActions.Player.Move.ReadValue<Vector2>();
    }
}

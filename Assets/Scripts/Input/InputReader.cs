using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Input
{
    [CreateAssetMenu]
    public class InputReader : ScriptableObject, GameInputActions.IPlayerActions
    {
        public event UnityAction<Vector2> MoveEvent = delegate { };
        public event UnityAction<Vector2> LookEvent = delegate { };

        public event UnityAction FireEvent = delegate { };
        public event UnityAction FireCancelEvent = delegate { };

        private GameInputActions _gameInputActions;

        private void OnEnable()
        {
            if (_gameInputActions == null)
            {
                _gameInputActions = new GameInputActions();
            }

            _gameInputActions.Player.SetCallbacks(this);
            _gameInputActions.Player.Enable();
        }

        private void OnDisable()
        {
            _gameInputActions.Player.RemoveCallbacks(this);
            _gameInputActions.Player.Disable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveEvent.Invoke(context.ReadValue<Vector2>());
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            LookEvent.Invoke(context.ReadValue<Vector2>());
        }

        public void OnFire(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                FireEvent.Invoke();
            }

            if (context.phase == InputActionPhase.Canceled)
            {
                FireCancelEvent.Invoke();
            }
        }
    }
}

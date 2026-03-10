using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(PlayerControls))]
    public class PlayerInput : MonoBehaviour
    {
            [SerializeField] PlayerControls playerControls;
        #region Inputs
        void OnMove(InputValue value)
        {
            playerControls.Movement(value.Get<Vector2>().x);
        }
        void OnSprint(InputValue value)
        {
            playerControls.walkSpeed(value.isPressed);
        }
        #endregion
    }

}

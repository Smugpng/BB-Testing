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
            playerControls.moveInput = value.Get<Vector2>();
        }
        #endregion
    }

}

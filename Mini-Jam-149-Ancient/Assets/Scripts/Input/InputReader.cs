using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ancient.Input
{
    public class InputReader : MonoBehaviour, Controls.IPlayerActions
    {
        public Vector2 MovementValue { get; private set; }

        Controls controls;

        public event Action jumpEvent;
        public event Action jumpCanceledEvent;
        public event Action pickupEvent;

        void Start()
        {
            controls = new Controls();

            controls.Player.SetCallbacks(this);

            controls.Player.Enable();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                jumpEvent?.Invoke();
            }
            else if (context.canceled)
            {
                jumpCanceledEvent?.Invoke();
            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MovementValue = context.ReadValue<Vector2>();
        }

        public void OnPickup(InputAction.CallbackContext context)
        {
            if (!context.performed) return;

            pickupEvent?.Invoke();
        }
    }
}

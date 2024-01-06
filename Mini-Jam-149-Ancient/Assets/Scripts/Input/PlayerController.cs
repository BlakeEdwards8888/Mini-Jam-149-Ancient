using Ancient.Movement;
using Ancient.Pickup;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ancient.Input
{
    public class PlayerController : MonoBehaviour
    {
        InputReader inputReader;
        JumpScript jumpScript;
        Move_1D moveScript;
        PickupGrabber pickupGrabber;

        private void Awake()
        {
            inputReader = GetComponent<InputReader>();
            jumpScript = GetComponent<JumpScript>();
            moveScript = GetComponent<Move_1D>();
            pickupGrabber = GetComponent<PickupGrabber>();
        }

        private void OnEnable()
        {
            inputReader.jumpEvent += jumpScript.Jump;
            inputReader.jumpCanceledEvent += jumpScript.CancelJump;
            inputReader.pickupEvent += () => pickupGrabber.Pickup(inputReader.MovementValue);
        }

        private void Update()
        {
            moveScript.Move(inputReader.MovementValue.x);
        }

        private void OnDisable()
        {
            inputReader.jumpEvent -= jumpScript.Jump;
            inputReader.jumpCanceledEvent -= jumpScript.CancelJump;
            inputReader.pickupEvent -= () => pickupGrabber.Pickup(inputReader.MovementValue);
        }
    }
}

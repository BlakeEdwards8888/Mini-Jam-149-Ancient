using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ancient.Pickup
{
    public class PickupObject : MonoBehaviour
    {
        public event Action onPickedUp;
        public event Action onDropped;

        public void OnPickedUp()
        {
            onPickedUp?.Invoke();
        }

        public void OnDropped()
        {
            onDropped?.Invoke();
        }
    }
}

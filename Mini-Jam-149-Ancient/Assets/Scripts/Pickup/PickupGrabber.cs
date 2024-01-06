using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ancient.Pickup
{
    public class PickupGrabber : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] Transform pickupHolder;

        [Header("Settings")]
        [SerializeField] float pickupRange = 1;
        [SerializeField] float throwForce;

        public void Pickup(Vector2 movementValue)
        {
            if (pickupHolder.childCount > 0)
            {
                ThrowHeldObject(movementValue);
                return;
            }

            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, pickupRange, Vector2.up, 0);

            foreach(RaycastHit2D hit in hits)
            {
                if (!hit.transform.TryGetComponent(out PickupObject pickup)) continue;

                pickup.GetComponent<Rigidbody2D>().isKinematic = true;
                pickup.transform.position = pickupHolder.position;
                pickup.transform.SetParent(pickupHolder);
                pickup.OnPickedUp();
                return;
            }
        }

        private void ThrowHeldObject(Vector2 movementValue)
        {
            PickupObject pickup = pickupHolder.GetComponentInChildren<PickupObject>();
            Rigidbody2D pickupRb = pickup.GetComponent<Rigidbody2D>();

            pickupRb.isKinematic = false;
            pickup.transform.parent = null;
            pickup.OnDropped();

            if (movementValue.x != 0)
            {
                pickupRb.velocity += movementValue.x > 0 ? new Vector2(throwForce, 1f) : new Vector2(-throwForce, 1f);
                
            }else if(movementValue.y > 0)
            {
                pickupRb.velocity += new Vector2(0, throwForce);
            }
        }
    }
}

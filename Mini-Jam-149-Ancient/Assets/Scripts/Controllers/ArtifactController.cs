using Ancient.Cleanup;
using Ancient.Pickup;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ancient.Controllers {
    public class ArtifactController : MonoBehaviour
    {
        PickupObject pickup;
        TimedSelfDestroyer selfDestroyer;

        private void Awake()
        {
            pickup = GetComponent<PickupObject>();
            selfDestroyer = GetComponent<TimedSelfDestroyer>();
        }

        private void OnEnable()
        {
            pickup.onPickedUp += selfDestroyer.StopTimer;
            pickup.onDropped += selfDestroyer.StartTimer;
        }

        private void OnDisable()
        {
            pickup.onPickedUp -= selfDestroyer.StopTimer;
            pickup.onDropped -= selfDestroyer.StartTimer;
        }
    }
}

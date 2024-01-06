using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ancient.Cleanup
{
    public class TimedSelfDestroyer : MonoBehaviour
    {
        [SerializeField] float destroyTime;

        float accumulatedTime;
        public bool IsTimerActive { get; private set; }

        private void Update()
        {
            if (!IsTimerActive) return;

            accumulatedTime += Time.deltaTime;
            
            if(accumulatedTime >= destroyTime)
            {
                Destroy(gameObject);
            }
        }

        public void StartTimer()
        {
            accumulatedTime = 0;
            IsTimerActive = true;
        }

        public void StopTimer()
        {
            IsTimerActive = false;
        }

        public float GetTimeRemaining()
        {
            if (!IsTimerActive) return 0;

            return destroyTime - accumulatedTime;
        }
    }
}

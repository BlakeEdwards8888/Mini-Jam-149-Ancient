using Ancient.Cleanup;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Ancient.UI
{
    public class TimerPresenter : MonoBehaviour
    {
        [SerializeField] TMP_Text displayText;
        [SerializeField] TimedSelfDestroyer timer;

        private void Update()
        {
            if (!timer.IsTimerActive)
            {
                displayText.text = "";
                return;
            }

            UpdateText();
        }

        void UpdateText()
        {
            displayText.text = Mathf.Ceil(timer.GetTimeRemaining()).ToString();
        }
    }
}

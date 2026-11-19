using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Collections;

namespace Unity.VRTemplate
{
    /// <summary>
    /// Controls the steps in the in coaching card.
    /// </summary>
    public class StepManager : MonoBehaviour
    {
        public bool Timer_started = false;
        public int minuts;
        public float seconds;

        [Serializable]
        class Step
        {
            [SerializeField]
            public GameObject stepObject;

            [SerializeField]
            public string buttonText;
        }

        [SerializeField]
        public TextMeshProUGUI m_StepButtonTextField;
        public TextMeshProUGUI m_TextFieldTimer;

        [SerializeField]
        List<Step> m_StepList = new List<Step>();

        int m_CurrentStepIndex = 0;

        private void Update()
        {
            if (Timer_started == true)
            {
                seconds += Time.deltaTime;

                if (seconds >= 60)
                {
                    seconds = 0;
                    minuts += 1;
                }

                if (Mathf.Round(seconds) >= 10)
                {
                    m_TextFieldTimer.text = minuts.ToString() + ":" + Mathf.Round(seconds).ToString();
                }
                else
                {
                    m_TextFieldTimer.text = minuts.ToString() + ":0" + Mathf.Round(seconds).ToString();
                }
                    
            }
        }

        public void Next()
        {
            m_StepList[m_CurrentStepIndex].stepObject.SetActive(false);
            m_CurrentStepIndex = (m_CurrentStepIndex + 1) % m_StepList.Count;
            m_StepList[m_CurrentStepIndex].stepObject.SetActive(true);
            m_StepButtonTextField.text = m_StepList[m_CurrentStepIndex].buttonText;
        }

        public void Start_timer()
        {
            //Changes the timer
            Timer_started = !Timer_started;

            //Goes to next step
            m_CurrentStepIndex = (m_CurrentStepIndex + 1) % m_StepList.Count;
            m_StepButtonTextField.text = m_StepList[m_CurrentStepIndex].buttonText;
        }
    }
}

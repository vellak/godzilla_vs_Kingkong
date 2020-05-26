using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace components
{
    public class UiTrigger : MonoBehaviour
    {
        public Image healthGz;
        public Image healthKk;
        private float timerTime;
        [SerializeField] private Text timerText;

        private WinnerClass wc;
        private bool timerActive = true;

        private void Start()
        {
            GameEventSystem.current.OnRoundStart += OnRoundStart;
            GameEventSystem.current.OnWinnerFound += OnWinnerfound;
            GameEventSystem.current.OnAnimationFinished += OnFadeOutBlack;
            GameEventSystem.current.OnAnimationStarted += OnFadeInBlack;
        }

        private void OnFadeInBlack()
        {
            print("Fade In UI " + timerTime);
            timerTime = GameLogic.current.timerLength;
            switch (wc.winNumb)
            {
                case 0:
                    healthKk.fillAmount = GetHealthValue();
                    healthGz.fillAmount = GetHealthValue();
                    break;
                case 1:
                    healthGz.fillAmount = GetHealthValue();
                    break;
                case 2:
                    healthGz.fillAmount = GetHealthValue();
                    break;
            }
        }

        private void OnFadeOutBlack()
        {
            print("Fade OUT UI " + timerTime);
            timerActive = true;
        }

        private void OnRoundStart()
        {
            timerTime = GameLogic.current.timerLength;
        }

        private void Update()
        {
            timerTime -= Time.deltaTime;
            timerText.text = timerTime.ToString("F1");
        }

        private static float GetHealthValue()
        {
            var t = 1 - (float) GameLogic.current.CurrentRound / GameLogic.current.turnAmount;
            return t;
        }

        public void OnWinnerfound(WinnerClass winClass)
        {
            timerActive = false;
            wc = winClass;
        }
    }
}
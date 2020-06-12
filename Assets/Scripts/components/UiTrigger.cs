using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace components
{
    public class UiTrigger : MonoBehaviour
    {
        public Health gzHealth;
        public Health kkHealth;
        public Score kkScore;
        public Score gzScore;
        public Image gzImage;
        public Image kkImage;

        public Text currentRound;
        [SerializeField] private Text gzScoreText;
        [SerializeField] private Text kkScoreText;
        private float timerTime;
        [SerializeField] private Text timerText;
        [SerializeField] private GameObject panel;
        private bool activate;

        private void Start()
        {
            GameEventSystem.current.OnRoundStart += OnRoundStart;
            GameEventSystem.current.OnAnimationStarted += OnFadeInBlack;
            GameEventSystem.current.OnWinnerFound += OnWinnerfound;
        }

        private void OnFadeInBlack()
        {
            timerTime = GameLogic.current.timerLength;
            if (activate)
            {
                if (kkImage != null) kkImage.fillAmount = kkHealth.lifePoints;
                if (gzHealth != null) gzImage.fillAmount = gzHealth.lifePoints;

                if (kkScoreText != null) kkScoreText.text = kkScore.wins.ToString();
                if (gzScore != null) gzScoreText.text = gzScore.wins.ToString();

                timerText.enabled = false;
                panel.SetActive(false);
            }
        }

        private void OnRoundStart()
        {
            panel.SetActive(true);
            if (currentRound != null) currentRound.text = GameLogic.current.CurrentRound.ToString();
            timerText.enabled = true;
            timerTime = GameLogic.current.timerLength;
            activate = false;
        }

        private void Update()
        {
            timerTime -= Time.smoothDeltaTime;
            if (timerText.enabled)
            {
                timerText.text = ((int) timerTime).ToString();
            }
        }

        public void OnWinnerfound(WinnerClass winClass)
        {
            activate = true;
        }
    }
}
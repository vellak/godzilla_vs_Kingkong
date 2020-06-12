using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace components
{
    // ReSharper disable once InconsistentNaming
    public class UIMoveTextTrigger : MonoBehaviour
    {
        private WinnerClass wc;
        public List<TextMeshProUGUI> kkWords;
        public List<TextMeshProUGUI> gzWords;
        private bool activate;

        public TextMeshProUGUI thingtoDisable;

        private void Start()
        {
            GameEventSystem.current.OnRoundStart += OnRoundStart;
            GameEventSystem.current.OnAnimationStarted += OnFadeIn;
            GameEventSystem.current.OnWinnerFound += OnWinnerfound;
        }

        private void OnRoundStart()
        {
            if (thingtoDisable)
            {
                thingtoDisable.enabled = false;
                thingtoDisable = null;
            }
            activate = false;
        }

        private void OnFadeIn()
        {
            var move = wc.move;
            print(wc.winNumb);
            if (wc.winNumb == 0)
            {
                // gzWords[2].enabled = true;
                // kkWords[2].enabled = true;
                //draw
            }
            else
            {
                if (activate)
                {
                    if (wc.winNumb == 1)
                    {
                        gzWords[move - 1].enabled = true;
                        thingtoDisable = gzWords[move - 1];
                    }
                    else if (wc.winNumb == 2)
                    {
                        kkWords[move - 1].enabled = true;
                        thingtoDisable = kkWords[move - 1];
                    }
                }
            }
        }

        public void OnWinnerfound(WinnerClass winClass)
        {
            activate = true;
            wc = winClass;
        }
    }
}
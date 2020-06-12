using System;
using UnityEngine;

namespace components
{
    public class AnimationTrigger : MonoBehaviour
    {
        private WinnerClass t;
        private WinnerClass wc;
        private void Start()
        {
            GameEventSystem.current.OnWinnerFound += OnWinnerfound;
            GameEventSystem.current.OnAnimationFinished += OnAnimationFinished;
            GameEventSystem.current.OnPlayerWinGame += OnPlayerWinGame;
        }

        private void OnAnimationFinished()
        {
            
            // ReSharper disable once ConvertIfStatementToSwitchStatement
                        if (wc.winNumb == 0)
                        {
                            return;
                        }
                        
                        if (wc.winNumb.Equals(2))
                        {
                            // then for godzilla
                            foreach (var rigidbodyTail in wc.l.gameObject.GetComponentsInChildren<Rigidbody>())
                                rigidbodyTail.isKinematic = true;
                        }
                        
                        print("Animations");
                        try
                        {
                            
                            wc.l.SetTrigger(wc.a1);
                            wc.w.SetTrigger(wc.a2);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
        }

        private void OnPlayerWinGame()
        {
            
        }

        public void OnWinnerfound(WinnerClass winClass)
        {
            wc = winClass;
            
                            
            // if the winner is King kong
            
        }
    }
}
using System;
using UnityEngine;

namespace components
{
    public class AnimationTrigger : MonoBehaviour, IWinnerTrigger
    {
        private WinnerClass t;
        private void Start()
        {
            GameEventSystem.current.OnWinnerFound += OnWinnerfound;
        }

        public void OnWinnerfound(WinnerClass winClass)
        {
            winClass.l.SetTrigger(winClass.a1);
            winClass.w.SetTrigger(winClass.a2);
            
            // if the winner is King kong
            if (winClass.winNumb.Equals(2))
            {
                // then for godzilla
                foreach (var rigidbodyTail in winClass.l.gameObject.GetComponentsInChildren<Rigidbody>())
                    rigidbodyTail.isKinematic = true;
            }
            
        }
    }
}
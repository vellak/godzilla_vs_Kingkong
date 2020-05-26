using UnityEngine;

namespace components
{
    public class AnimationTrigger : MonoBehaviour
    {
        private WinnerClass t;
        
        private void Start()
        {
            GameEventSystem.current.OnWinnerFound += OnWinnerfound;
            GameEventSystem.current.OnCharacterDie += OnCharacterDie;
        }

        private void OnCharacterDie()
        {
            
        }

        public static void OnWinnerfound(WinnerClass winClass)
        {
            // ReSharper disable once ConvertIfStatementToSwitchStatement
            if (winClass.winNumb == 0)
            {
                return;
            }
            
            if (winClass.winNumb.Equals(2))
            {
                // then for godzilla
                foreach (var rigidbodyTail in winClass.l.gameObject.GetComponentsInChildren<Rigidbody>())
                    rigidbodyTail.isKinematic = true;
            }
            
            print("Animations");
            winClass.l.SetTrigger(winClass.a1);
            winClass.w.SetTrigger(winClass.a2);
                            
            // if the winner is King kong
            
        }
    }
}
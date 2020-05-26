using System.Collections;
using UnityEngine;

namespace components
{
    public class CameraTrigger : MonoBehaviour
    {
        public Camera kingKongFront;
        public Camera godzillaFront;
        public Camera kingKong;
        public Camera godzilla;

        public Animator imageAnimator;
        private static readonly int FadeIn = Animator.StringToHash("fade in");
        private static readonly int FadeOut = Animator.StringToHash("fade out");
        private bool isFirstRound = true;
        
        private void Start()
        {
            GameEventSystem.current.OnWinnerFound += OnWinnerfound;
            GameEventSystem.current.OnRoundStart += OnRoundStart;
        }
        public void OnWinnerfound(WinnerClass winClass)
        {
            var switchCameraAnimated = SwitchCameraAnimated(kingKong, kingKongFront, godzilla, godzillaFront);
            StartCoroutine(switchCameraAnimated);
        }

        public void OnRoundStart()
        {
            var switchCameraAnimated = SwitchCameraAnimated(kingKongFront, kingKong, godzillaFront, godzilla);
            if (!isFirstRound)
            {
                StartCoroutine(switchCameraAnimated);
            }
            else
            {
                isFirstRound = false;
            }
        }
        private static void SwitchCamera(Behaviour a, Behaviour b)
        {
            a.enabled = false;
            b.enabled = true;
        }
        private IEnumerator SwitchCameraAnimated(Behaviour a, Behaviour a2, Behaviour b, Behaviour b2)
        {
            imageAnimator.SetTrigger(FadeIn);
            yield return new WaitForSeconds(imageAnimator.GetCurrentAnimatorClipInfo(0).Length);
            GameEventSystem.current.TriggerAnimationStarted();
            SwitchCamera(a,a2);
            SwitchCamera(b,b2);
            imageAnimator.SetTrigger(FadeOut);
            yield return new WaitForSeconds(imageAnimator.GetCurrentAnimatorClipInfo(0).Length);
            GameEventSystem.current.TriggerAnimationFinished();
        }
        
    }
}
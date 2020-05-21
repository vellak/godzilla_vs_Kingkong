using UnityEngine;

namespace components
{
    public class UiTrigger : MonoBehaviour,  IWinnerTrigger
    {
        private void Start()
        {
            GameEventSystem.current.OnWinnerFound += OnWinnerfound;
            GameEventSystem.current.OnUpdateTimer += OnUpdateTimer;
        }

        private void OnUpdateTimer(int time)
        {
            
        }

        public void OnWinnerfound(WinnerClass winClass)
        {
            throw new System.NotImplementedException();
        }
    }
}
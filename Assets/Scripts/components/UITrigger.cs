using UnityEngine;

namespace components
{
    public class UiTrigger : MonoBehaviour,  IWinnerTrigger
    {
        public void OnWinnerfound(WinnerClass winClass)
        {
            throw new System.NotImplementedException();
        }
    }
}
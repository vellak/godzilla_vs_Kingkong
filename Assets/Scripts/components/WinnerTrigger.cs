using UnityEngine;

namespace components
{
    public interface IWinnerTrigger
    {
        void OnWinnerfound(WinnerClass winClass);
    }
}
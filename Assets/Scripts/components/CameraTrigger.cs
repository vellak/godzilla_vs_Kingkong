using UnityEngine;

namespace components
{
    public class CameraTrigger : MonoBehaviour,  IWinnerTrigger
    {
        public Camera kingKongFront;
        public Camera godzillaFront;
        public Camera kingKong;
        public Camera godzilla;
        
        public void OnWinnerfound(WinnerClass winClass)
        {
            kingKong.enabled = false;
            kingKongFront.enabled = true;

            godzilla.enabled = false;
            godzillaFront.enabled = true;
        }
    }
}
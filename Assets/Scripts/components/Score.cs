using UnityEngine;

namespace components
{
    public class Score : MonoBehaviour
    {
        public int score;
        public int character;
        private void Start()
        {
            GameEventSystem.current.OnWinnerFound += OnWinnerfound;
        }

        private void OnWinnerfound(WinnerClass obj)
        {
            if (obj.winNumb == character)
            {
                score += 1;
                CheckIfWinner();
            }
        }

        private void CheckIfWinner()
        {
            if (score ==  (GameLogic.current.turnAmount + 1)/2)
            {
                
            }
        }
    }
}
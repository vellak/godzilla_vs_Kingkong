using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace components
{
    public class Score : MonoBehaviour
    {
        public int wins;
        public int losses;
        public int character;
        
        private void Start()
        {
            GameEventSystem.current.OnWinnerFound += OnWinnerfound;
        }
        // on the Winner found event, add the given score to the total amount of point to the desired player
        private void OnWinnerfound(WinnerClass obj)
        {
            if (obj.winNumb != 0)
            {
                if (obj.winNumb == character)
                {
                    wins += obj.score;
                }
                if (obj.winNumb != character)
                {
                    losses += obj.score;
                }
                GameEventSystem.current.TriggerScoreUpdate();
            }
            if (GameLogic.current.bestOutOf <= wins)
            {
                StartCoroutine(Winner());
                GameEventSystem.current.TriggerPlayerWinGame();
            }
        }

        private IEnumerator Winner()
        {
            yield return new WaitForSeconds(3);
        }
    }
}
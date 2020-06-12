using UnityEngine;

namespace components
{
    public class Health : MonoBehaviour
    {
        [Range(0,1)]
        internal float lifePoints;
        public Score playerScore;
        
        private void Start()
        {
            lifePoints = 1f;
            GameEventSystem.current.OnScoreUpdate += OnWinnerFound;
        }
        private void OnWinnerFound()
        {
            lifePoints = 1f * (GameLogic.current.bestOutOf - playerScore.losses) / GameLogic.current.bestOutOf;
        }
    }
}
using UnityEngine;

namespace components
{
    public class Health : MonoBehaviour
    {
        private float lifePoints;
        public int character;
        private float maxHealth = 100;
        private void Start()
        {
            maxHealth = lifePoints;
            GameEventSystem.current.OnWinnerFound += OnWinnerfound;
        }
        private void OnWinnerfound(WinnerClass obj)
        {
            if (obj.winNumb != character /* && obj.winNumb != 0*/)
            { 
                ReduceHealth(obj.damage);  
            }
        }
        public void ReduceHealth(int damage)
        {
            lifePoints -=damage;
            if (lifePoints <= 1)
            {
                lifePoints = 0;
                GameEventSystem.current.TriggerCharacterDie();
            }
        }
    }
}
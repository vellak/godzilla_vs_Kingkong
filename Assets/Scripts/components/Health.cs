using UnityEngine;

public class Health : MonoBehaviour
{
    public int lifePoints;


    public void ReduceHealth(int damage)
    {
        lifePoints = -damage;
        if (lifePoints <= 0)
        {
            //run death animation
            // lose game
        }
    }
}
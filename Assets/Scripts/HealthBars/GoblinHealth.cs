using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;

    // private int MAX_HEALTH = 100;


    public void Damage(int amount)
    {
        MapRotater enemyLeft = FindObjectOfType<MapRotater>();
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount;

        if(this.health <= 0)
        {
            enemyLeft.EnemyKilled();
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}

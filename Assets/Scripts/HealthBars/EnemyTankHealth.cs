using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;
    public int armor = 1;

    // private int MAX_HEALTH = 100;


    public void Damage(int amount)
    {
        MapRotater enemyLeft = FindObjectOfType<MapRotater>();
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount - armor;

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

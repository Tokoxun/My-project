using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;
    public MapRotater enemyLeft;

    // private int MAX_HEALTH = 100;


    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount;
        Debug.Log(this.health);

        if(this.health <= 0)
        {
            enemyLeft.EnemyKilled();
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("I am Dead!");
        Destroy(gameObject);
    }
}

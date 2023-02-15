using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    // Start is called before the first frame update
    private int damage = 3;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            var check = GetComponentInParent<EnemyAttack>();
            health.Damage(damage);
            check.EnemyAction();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : Singleton<Difficulty>
{
    protected Difficulty()
    {}
    public float diff = 1.0f;
    private GameObject enem;
    public void Buff(float dmg)
    {
        EnemyAttackArea enemAtk = FindObjectOfType<EnemyAttackArea>();
        Projectile arrowDmg = FindObjectOfType<Projectile>();
        if(enemAtk != null)
        {
            enemAtk.damage = dmg *= diff;
        }
        if(arrowDmg != null)
        {
            arrowDmg.damage = dmg *= diff;
        }
        
    }
}

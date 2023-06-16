using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : Singleton<Difficulty>
{
    protected Difficulty()
    {}
    public float diff = 1f;
    private GameObject enem;
    public void Buff(float dmg)
    {
        EnemyAttackArea enemAtk = FindObjectOfType<EnemyAttackArea>();
        Projectile arrowDmg = FindObjectOfType<Projectile>();
        enemAtk.damage = dmg *= diff;
        arrowDmg.damage = dmg *= diff;
    }
}

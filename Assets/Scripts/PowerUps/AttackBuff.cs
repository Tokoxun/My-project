using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBuff : MonoBehaviour
{
    public int dmgUp = 2;

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ally")
        {
            AttackArea attack = col.GetComponent<AttackArea>();
            attack.damage += dmgUp;
            Destroy(gameObject);
        }
    }
}

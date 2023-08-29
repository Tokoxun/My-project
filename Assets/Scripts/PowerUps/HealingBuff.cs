using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingBuff : MonoBehaviour
{
    public int healing = 5;

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ally")
        {
            Health healUp = col.GetComponent<Health>();
            healUp.Heal(healing);
            Destroy(gameObject);
        }
    }
}

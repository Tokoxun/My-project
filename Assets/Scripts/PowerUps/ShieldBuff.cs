using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBuff : MonoBehaviour
{
    public int Shields = 10;

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ally")
        {
            Health ShieldUp = col.GetComponent<Health>();
            ShieldUp.Armor(Shields);
            Destroy(gameObject);
        }
    }
}

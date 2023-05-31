using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallReinforcements : MonoBehaviour
{
    public SpawningTrigger enemyTrigger;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ally")
        {
            enemyTrigger.RandomPoints();
        }
    }
}

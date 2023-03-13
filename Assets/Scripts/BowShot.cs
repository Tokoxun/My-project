using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowShot : MonoBehaviour
{
    public ProjectileBehaviour ProjectilePrefab;
    public Transform Bow;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<Collider2D>().tag == "Ally")
        {
            Instantiate(ProjectilePrefab, Bow.position, transform.rotation);
        }
    }
}

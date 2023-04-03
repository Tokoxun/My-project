using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed = 5f;
    private float timeBeforeDespawn;
    private float despawnTime = 2f;

    private void Update()
    {
        timeBeforeDespawn += Time.deltaTime;
        transform.position += -transform.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ally")
        {
            Destroy(gameObject);
            timeBeforeDespawn = 0;
            Debug.Log("Hit");
        }
        if(timeBeforeDespawn >= despawnTime)
        {
            Destroy(gameObject);
            timeBeforeDespawn = 0;
        }
    }
}

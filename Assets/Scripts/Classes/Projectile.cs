using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed = 5f;
    private float timeBeforeDespawn;
    private float despawnTime = 2f;
    public int damage = 5;
    public Health health;

    private void Update()
    {
        timeBeforeDespawn += Time.deltaTime;
        transform.position += -transform.right * Time.deltaTime * speed;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ally")
        {
            health.Damage(damage);
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

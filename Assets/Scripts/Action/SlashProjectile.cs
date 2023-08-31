using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashProjectile : MonoBehaviour
{
    private float speed = 5f;
    private float timeBeforeDespawn;
    private float despawnTime = 2f;

    // Update is called once per frame
    private void Update()
    {
        timeBeforeDespawn += Time.deltaTime;
        transform.position += -transform.right * Time.deltaTime * speed;
        if(timeBeforeDespawn >= despawnTime)
        {
            Destroy(gameObject);
            timeBeforeDespawn = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "enemy")
        {
            // Calculate the direction from this object to the moving object
            Vector3 pushDirection = col.transform.position - transform.position;

            // Get the Rigidbody of the moving object
            Rigidbody2D movingObjectRb = col.GetComponent<Rigidbody2D>();

            // Apply a force to the moving object to simulate pushing
            float pushForce = 1.5f; // Adjust as needed
            movingObjectRb.AddForce(pushDirection.normalized * pushForce, ForceMode2D.Impulse);
        }
        if(col.gameObject.tag == "Projectile")
        {
            Destroy(col);
        }
    }
}

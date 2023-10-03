using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashProjectile : MonoBehaviour
{
    public float pushForce = 10f; // Adjust this value to control the strength of the push.
    private Rigidbody2D rb;
    private float speed = 5f;
    private float timeBeforeDespawn;
    private float despawnTime = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void Update()
    {
        timeBeforeDespawn += Time.deltaTime;
        transform.position += transform.right * Time.deltaTime * speed;
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
            // Get the Rigidbody of the moving object
            Rigidbody2D movingObjectRb = col.GetComponent<Rigidbody2D>();

            // Calculate the direction from this object to the moving object
            Vector2 pushDirection = (movingObjectRb.position - rb.position).normalized;

            // Apply a force to the moving object to simulate pushing
            movingObjectRb.AddForce(pushDirection.normalized * pushForce, ForceMode2D.Impulse);
        }
        if(col.gameObject.tag == "Projectile")
        {
            Destroy(col);
        }
    }
}

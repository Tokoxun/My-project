using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private float speed = 2f;
    private void Update()
    {
        transform.position += -transform.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Ally")
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowShot : MonoBehaviour
{
    public Projectile ProjectilePrefab;
    public Transform Bow;
    private float readyingShot;
    private float ShotCooldown = 2f;
    private bool hadFired = false;
    public Animator AIAnim;
    private float animTrigger = 1f;
    private float triggerCooldown;

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.CompareTag("Ally"))
        {
            hadFired = true;
        }
    }

    void Update()
    {
        readyingShot += Time.deltaTime;
        if(readyingShot >= ShotCooldown)
        {
            triggerCooldown += Time.deltaTime;
            AIAnim.SetBool("attacking", true);
            if(hadFired && triggerCooldown >= animTrigger)
            {
                Instantiate(ProjectilePrefab, Bow.position, transform.rotation);
                AIAnim.SetBool("attacking", false);
                readyingShot = 0;
                triggerCooldown = 0;
                hadFired = false;
            }
        }
    }
}


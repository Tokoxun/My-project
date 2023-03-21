using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowShot : MonoBehaviour
{
    public ProjectileBehaviour ProjectilePrefab;
    public Transform Bow;
    private float readyingShot;
    private float ShotCooldown = 2f;
    private bool hadFired = false;

    private void OnTriggerStay2D(Collider2D col)
    {
        var AIAnim = GetComponentInParent<Animator>();
        readyingShot += Time.deltaTime;
        AIAnim.SetBool("attacking", true);
        if(col.CompareTag("Ally") && readyingShot >= ShotCooldown)
        {
            Instantiate(ProjectilePrefab, Bow.position, transform.rotation);
            hadFired = true;
            AIAnim.SetBool("attacking", false);
        }
        if(hadFired == true && readyingShot >= ShotCooldown)
        {
            readyingShot = 0;
        }
    }
}


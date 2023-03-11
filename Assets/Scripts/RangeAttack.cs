using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    public Transform LaunchOffset;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Ally"))
        {
            var Arrows = GetComponentInChild<ProjectileBehaviour>();
            Arrows()
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public GoblinMovement goblinMove;
    private GameObject detection = default;
    public GameObject patrolType;

    void Start()
    {
        detection = this.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ally")
        {
            if (patrolType.GetComponentInParent<SquarePatrol>() != null)
            {
                SquarePatrol stopPatrol = GetComponentInParent<SquarePatrol>();
                stopPatrol.enabled = false;
            }
            if (patrolType.GetComponentInParent<TrianglePatrol>() != null)
            {
                TrianglePatrol stopPatrol = GetComponentInParent<TrianglePatrol>();
                stopPatrol.enabled = false;
            }
            goblinMove.professor = collider.transform;
            goblinMove.ChasingPlayer = true;
            goblinMove.playerSpotted = true;
            detection.SetActive(false);
        }
    }
}
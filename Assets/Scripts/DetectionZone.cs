using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public GoblinMovement goblinMove;
    private GameObject detection = default;

    void Start()
    {
        detection = this.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ally")
        {
            goblinMove.professor = collider.transform;
            goblinMove.ChasingPlayer = true;
            goblinMove.playerSpotted = true;
            detection.SetActive(false);
            SquarePatrol stopPatrol = GetComponentInParent<SquarePatrol>();
            stopPatrol.enabled = false;
        }
    }
}
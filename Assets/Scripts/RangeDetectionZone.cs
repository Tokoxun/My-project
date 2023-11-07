using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDetectionZone : MonoBehaviour
{
    public RangeMovement rangeMove;
    private GameObject detection;

    void Start()
    {
        detection = this.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ally")
        {
            TrianglePatrol stopPatrol = GetComponentInParent<TrianglePatrol>();
            stopPatrol.enabled = false;
            rangeMove.professor = collider.transform;
            rangeMove.ChasingPlayer = true;
            rangeMove.playerSpotted = true;
            rangeMove.range.SetActive(true);
            detection.SetActive(false);
        }
    }
}

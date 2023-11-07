using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone2 : MonoBehaviour
{
    public TankMovement tankMove;
    private GameObject detection = default;

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
            tankMove.professor = collider.transform;
            tankMove.ChasingPlayer = true;
            tankMove.playerSpotted = true;
            detection.SetActive(false);
        }
    }
}

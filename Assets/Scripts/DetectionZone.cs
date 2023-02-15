using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    private bool playerNotDetected = true;

    private GameObject detection = default;


    void Start()
    {
        detection = transform.GetChild(1).gameObject;
        detection.SetActive(playerNotDetected);
    }

    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        playerNotDetected = false;
        detection.SetActive(playerNotDetected);
    }
}

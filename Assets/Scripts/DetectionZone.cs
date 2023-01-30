using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    private bool Awareness = false;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        Awareness = true;
        Debug.Log(Awareness);
    }
}

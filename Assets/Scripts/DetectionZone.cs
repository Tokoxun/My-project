using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
<<<<<<< HEAD
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Alerted");
=======
    private bool Awareness = false;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        Awareness = true;
        Debug.Log(Awareness);
>>>>>>> experiment2
    }
}

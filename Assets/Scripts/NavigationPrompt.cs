using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationPrompt : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Borders"))
        {
            Debug.Log("Leave Town");
        }
    }
}

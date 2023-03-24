using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderRotation : MonoBehaviour
{
    public Transform playerTransform;

    private void Update()
    {
        transform.LookAt(playerTransform);
        transform.rotation *= Quaternion.Euler(0, 90, 0);
    }
}

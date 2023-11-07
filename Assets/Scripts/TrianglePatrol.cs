using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrianglePatrol : MonoBehaviour
{
    static public float sideDuration = 3.0f; 

    private Rigidbody2D playerRigidBody2D; 
    //Sprite renderer for the player 
    private SpriteRenderer playerSpriteImage;
    // Animator component for the player 
    private Animator playerAnim;
    public Transform DetectionColliderRotate;

    // Compute the translation vector for the next frame
    private int indexer() {
        return (int)(Time.timeSinceLevelLoad/sideDuration) % 3;
    }

    void Awake() {
        playerRigidBody2D = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
        playerAnim = (Animator)GetComponent(typeof(Animator));
        playerSpriteImage =(SpriteRenderer)GetComponent(typeof(SpriteRenderer));
    }

    void Update() {
        int idx = indexer();
        if (idx == 0) {
            transform.Translate(-1 * Time.deltaTime, -1 * Time.deltaTime, 0.0f);
            DetectionColliderRotate.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (idx == 1) {
            transform.Translate(2 * Time.deltaTime, 0.0f, 0.0f);
            DetectionColliderRotate.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (idx == 2) {
            transform.Translate(-1 * Time.deltaTime, Time.deltaTime, 0.0f);
            DetectionColliderRotate.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
}

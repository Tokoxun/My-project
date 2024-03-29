using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquarePatrol : MonoBehaviour{
    static public float sideDuration = 3.0f; 

    private Rigidbody2D playerRigidBody2D; 
    //Sprite renderer for the player 
    private SpriteRenderer playerSpriteImage;
    // Animator component for the player 
    private Animator playerAnim;
    public Transform DetectionColliderRotate;


    // Compute the translation vector for the next frame
    private int indexer() {
        return (int)(Time.timeSinceLevelLoad/sideDuration) % 4;
    }

    void Awake() {
        playerRigidBody2D = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
        playerAnim = (Animator)GetComponent(typeof(Animator));
        playerSpriteImage =(SpriteRenderer)GetComponent(typeof(SpriteRenderer));
    }

    void Update() {
        int idx = indexer();
        if (idx == 0) {
            transform.Translate(0.0f, -1 * Time.deltaTime, 0.0f);
            playerAnim.SetBool("walkDown", true);
            playerAnim.SetBool("walkUp", false);
            playerAnim.SetBool("walkHorizontal", false);
            DetectionColliderRotate.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (idx == 1) {
            transform.Translate(Time.deltaTime, 0.0f, 0.0f);
            playerAnim.SetBool("walkDown", false);
            playerAnim.SetBool("walkUp", false);
            playerAnim.SetBool("walkHorizontal", true);
            playerSpriteImage.flipX=true; 
            DetectionColliderRotate.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (idx == 2) {
            transform.Translate(0.0f, Time.deltaTime, 0.0f);
            playerAnim.SetBool("walkDown", false);
            playerAnim.SetBool("walkUp", true);
            playerAnim.SetBool("walkHorizontal", false);
            DetectionColliderRotate.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else {
            transform.Translate(-1 * Time.deltaTime, 0.0f, 0.0f);
            playerAnim.SetBool("walkDown", false);
            playerAnim.SetBool("walkUp", false);
            playerAnim.SetBool("walkHorizontal", true);
            playerSpriteImage.flipX=false; 
            DetectionColliderRotate.transform.rotation = Quaternion.Euler(0, 0, 270);
        }
    }
}

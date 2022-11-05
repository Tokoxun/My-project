using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D playerRigidBody2D; 

    private SpriteRenderer profSpriteImage;

    private Animator profAnim;

    public float jumpForce=5;

    public float gravity = -9.81f;

    public float gravityScale = 1;

    float velocity;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody2D = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
        profAnim = (Animator)GetComponent(typeof(Animator));
        profSpriteImage =(SpriteRenderer)GetComponent(typeof(SpriteRenderer));
    }


    void Update()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        velocity = jumpForce;
    }
}
    void FixedUpdate()
    {
        float vPos = playerRigidBody2D.position.y + velocity * Time.fixedDeltaTime;
        playerRigidBody2D.MovePosition(new Vector2(playerRigidBody2D.position.x, vPos));
    }
}



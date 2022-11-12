using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading;


public class CharacterJump : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer profSpriteImage;
    private Animator profAnim;

    public float jumpForce=20;
    public float gravity = -9.81f;
    public float gravityScale = 5;
    private bool isJump = false;
    float velocity;

    private Vector3 jumpPos;
    static private float timeToJump = 0.10f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        profAnim = (Animator)GetComponent(typeof(Animator));
        profSpriteImage =(SpriteRenderer)GetComponent(typeof(SpriteRenderer));
    }


    void Update()
    {
        velocity += gravity * gravityScale * Time.deltaTime;
        if (isJump && timer >= timeToJump)
        {
            velocity = 0;
            timer = 0;
            isJump = false;
            transform.position = jumpPos;
        }
        else if (isJump && timer < timeToJump)
        {
            timer += Time.deltaTime;
            transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                isJump = true;
                timer += Time.deltaTime;

                velocity = jumpForce;
                transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
            }
        }
    }
}



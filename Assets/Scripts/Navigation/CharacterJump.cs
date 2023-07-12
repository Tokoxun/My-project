using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyJoystick;

public class CharacterJump : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer profSpriteImage;
    private Animator profAnim;

    public float jumpForce=20;
    public float gravity = -9.81f;
    public float gravityScale = 5;
    private bool isJump = false;
    private bool jumped = false;
    float velocity;
    private Vector2 jumpPos;
    static private float timeToJump = 0.10f;
    private float timer = 0f;
    public float xspeed = 0.1f;
    public float movePlayerHorizontal;
    public float xvelocity;
    public float xdistance = 0f;
    public float timeToDrop = 0.10f;
    private float droptimer = 0f;
    public Joystick joystick;


    // Start is called before the first frame update
    void Start()
    {
        profAnim = (Animator)GetComponent(typeof(Animator));
        profSpriteImage =(SpriteRenderer)GetComponent(typeof(SpriteRenderer));
    }

    void Update()
    {
        if(jumped)
        {
            timer += Time.deltaTime;
            if (isJump && timer >= timeToJump)
            {
                droptimer += Time.deltaTime;
                if (droptimer < timeToDrop)
                {
                    velocity = 20;
                    transform.Translate(new Vector2(xvelocity, -velocity) * Time.deltaTime);
                    xdistance += xvelocity;
                }
                else
                {
                    jumpPos += new Vector2(xdistance, 0);
                    transform.position = jumpPos;
                    xdistance = 0f;
                    isJump = false;
                    timer = 0;
                    velocity = 0;
                    droptimer = 0;
                    jumped = false;
                }
            
            }
            else if (isJump && timer < timeToJump)
            {
                timer += Time.deltaTime;
                transform.Translate(new Vector2(xvelocity, velocity) * Time.deltaTime);
                xdistance += xvelocity;
            }
        }
    }


    public void jumpButton()
    {
        velocity += gravity * gravityScale * Time.deltaTime;
        movePlayerHorizontal = joystick.Horizontal();
        xvelocity = xspeed * movePlayerHorizontal;
        
        jumpPos = new Vector2(transform.position.x, transform.position.y);
        isJump = true;

        velocity = jumpForce;
        transform.Translate(new Vector2(xvelocity, velocity) * Time.deltaTime);
        jumped = true;
    }
}



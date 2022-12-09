using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLunge : MonoBehaviour
{
    private SpriteRenderer profSpriteImage;
    private Animator profAnim;
    private float movePlayerHorizontal; 

    // The speed at which the character moves
    public float speed = 10.0f;

    // The distance the character moves position during the lunge
    public float lungeDistance = 2.0f;

    // The amount of time the lunge lasts
    public float lungeDuration = 0.5f;

    // Variables to track the lunge state
    private bool isLunging = false;
    private float lungeTimer = 0.0f;

    void Start()
    {
        profAnim = (Animator)GetComponent(typeof(Animator));
        profSpriteImage =(SpriteRenderer)GetComponent(typeof(SpriteRenderer));
    }


    void Update()
    {
        movePlayerHorizontal = Input.GetAxis("Horizontal");
        // Check if the lunge is still active
        if (isLunging && lungeTimer >= lungeDuration)
        {
            // Stop the lunge and reset the timer
            isLunging = false;
            lungeTimer = 0.0f;
            profAnim.SetBool("Lunging", false);
        }

        else if (isLunging && lungeTimer < lungeDuration)
        {
            lungeTimer += Time.deltaTime;
            profAnim.SetBool("Readying", false);
            profAnim.SetBool("Lunging", true);
            if (movePlayerHorizontal>0)
            {
                transform.Translate(new Vector2(lungeDistance, 0) * Time.deltaTime);
            }
            else if (movePlayerHorizontal<0)
            {
                transform.Translate(new Vector2(-lungeDistance, 0) * Time.deltaTime);
            }
        }

        else
        {
            if (Input.GetButtonDown("Fire2"))
            {
                // Update the lunge interval timer
                isLunging = true;
                lungeTimer += Time.deltaTime;
                profAnim.SetBool("Readying", true);
            }
        }
    }
}


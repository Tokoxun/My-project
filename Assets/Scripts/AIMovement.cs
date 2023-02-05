using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
  private Rigidbody2D AIRigidBody2D; 

  // Animator component for the player 
  private Animator AIAnim;
  private Vector2 movement;
  private float movePlayerHorizontal = 0;
  private float movePlayerVertical = 0; 
  private float moveUpY = 2f;
  private bool movingUp = false;
  private float moveDownY = 2f;
  private bool movingDown = false;
  private float moveLeftX = 2f;
  private bool movingLeft = false;
  private float moveRightX = 2f;
  private bool movingRight = false;
  private float moveTime = 0f;
  private float movingTime = 0.50f;
  // private float timeFraction = 2f;
  //Sprite renderer for the player 
  private SpriteRenderer AISpriteImage;

  public float speed = 4.0f; 
  void Awake()
    {
        AIRigidBody2D = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
        AIAnim=(Animator)GetComponent(typeof(Animator));
        AISpriteImage =(SpriteRenderer)GetComponent(typeof(SpriteRenderer));
        movingDown = true;
    }

  void Update ()
    { 
      movement = new Vector2(movePlayerHorizontal,movePlayerVertical); 

      AIRigidBody2D.velocity=movement*speed;
      AIAnim.SetBool("moving",true); 

        if(movingDown == true && moveTime < movingTime)
          { 
            moveTime += Time.deltaTime;
            AIAnim.SetBool("xMove",false); 
            AISpriteImage.flipX=false;
            AIAnim.SetBool("yMove", true);
            transform.Translate(new Vector2(0, -moveDownY) * Time.deltaTime); 
            if (moveTime > movingTime)
            {
                movingDown = false;
                movingRight = true;
                moveTime = 0f;

            }
          }
        if(movingRight = true && moveTime < movingTime)
        {
          moveTime += Time.deltaTime;
          AIAnim.SetBool("yMove", false); 
          AIAnim.SetBool("xMove",true); 
          AISpriteImage.flipX=true; 
          transform.Translate(new Vector2(moveRightX, 0) * Time.deltaTime);
          if (moveTime > movingTime)
          {
            movingRight = false;
            movingUp = true;
            moveTime = 0f;
          }
        }        
        if(movingUp == true && moveTime < movingTime)
          {
            moveTime += Time.deltaTime;
            AIAnim.SetBool("xMove",false); 
            AISpriteImage.flipX=false;
            AIAnim.SetBool("yMove", true); 
            transform.Translate(new Vector2(0, moveUpY) * Time.deltaTime);
            if (moveTime > movingTime)
            {
                movingUp = false;
                movingLeft = true;
                moveTime = 0f;
            }
          }        
        if(movingLeft == true && moveTime < movingTime)
        { 
          moveTime += Time.deltaTime;
          AIAnim.SetBool("yMove",false); 
          AIAnim.SetBool("xMove",true); 
          AISpriteImage.flipX=false; 
          transform.Translate(new Vector2(-moveLeftX, 0) * Time.deltaTime);
          if (moveTime > movingTime)
          {
            movingLeft = false;
            moveTime = 0f;
          }
        }

    //   if(movingUp && movingDown = false && movingLeft && movingRight = false)
    //   { 
    //       AIAnim.SetBool("moving",false); 
    //   }
      
    }
}

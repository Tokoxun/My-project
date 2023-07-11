using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyJoystick;

public class CharacterMovement : MonoBehaviour{ 
  private Rigidbody2D playerRigidBody2D; 

  // Animator component for the player 
  private Animator playerAnim;
  private float movePlayerHorizontal; 
  private float movePlayerVertical; 
  private Vector2 movement; 
  //Sprite renderer for the player 
  private SpriteRenderer playerSpriteImage;
  public Transform colliderRotate;

  public float speed = 4.0f; 
  // [SerializeField] private Joystick joystick;
  public Joystick joystick;
  void Awake(){
        playerRigidBody2D = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
        playerAnim=(Animator)GetComponent(typeof(Animator));
        playerSpriteImage =(SpriteRenderer)GetComponent(typeof(SpriteRenderer));
  }

  void Update (){
      movePlayerHorizontal = joystick.Horizontal(); 
      movePlayerVertical = joystick.Vertical(); 
      movement = new Vector2(movePlayerHorizontal,movePlayerVertical); 

      playerRigidBody2D.velocity=movement*speed;
      if(movePlayerVertical!=0){ 
        playerAnim.SetBool("xMove",false); 
        playerSpriteImage.flipX=false; 

        if(movePlayerVertical>0){ 
        playerAnim.SetInteger("yMove",1);
        colliderRotate.transform.rotation = Quaternion.Euler(0, 0, 180); 
        }
        else if(movePlayerVertical<0){ 
        playerAnim.SetInteger("yMove",-1);
        colliderRotate.transform.rotation = Quaternion.Euler(0, 0, 0); 
        }

        }

      else{ 
        playerAnim.SetInteger("yMove",0); 

        if(movePlayerHorizontal>0){ 
        playerAnim.SetBool("xMove",true); 
        playerSpriteImage.flipX=false; 
        colliderRotate.transform.rotation = Quaternion.Euler(0, 0, 90);
        }

      else if(movePlayerHorizontal<0){ 
        playerAnim.SetBool("xMove",true); 
        playerSpriteImage.flipX=true; 
        colliderRotate.transform.rotation = Quaternion.Euler(0, 0, 270);
        }
      else{ 
        playerAnim.SetBool("xMove",false); 
      }
      }

      if(movePlayerVertical==0 && movePlayerHorizontal==0){ 
            playerAnim.SetBool("moving",false); 
      }
      else{ 
            playerAnim.SetBool("moving",true); 
      }
  }
}

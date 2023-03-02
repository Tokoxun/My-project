using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    private Animator AIAnim;
    private SpriteRenderer AISpriteImage;
    public float AIspeed = 2f;
    private float ProfAndAIDistx;
    private float ProfAndAIDisty;
    private float moveAIHorizontal;
    private float moveAIVertical;
    private bool playerNotDetected = true;
    private GameObject detection = default;
    public Transform professor;


    void Start()
    {
        detection = transform.GetChild(1).gameObject;
        AIAnim=(Animator)GetComponent(typeof(Animator));
        AISpriteImage =(SpriteRenderer)GetComponent(typeof(SpriteRenderer));
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ally")
        {
            playerNotDetected = false;
            detection.SetActive(playerNotDetected);
        }
    }

    void Update()
    {
        ProfAndAIDistx = professor.transform.position.x - transform.position.x;
        ProfAndAIDisty = professor.transform.position.y - transform.position.y;
        moveAIHorizontal = Input.GetAxis("Horizontal"); 
        moveAIVertical = Input.GetAxis("Vertical"); 
        if(playerNotDetected == false)
        {
            transform.Translate(new Vector2(ProfAndAIDistx * AIspeed, ProfAndAIDisty * AIspeed) * Time.deltaTime);
            if(moveAIVertical != 0)
            {
                AIAnim.SetBool("enemyMovex", false);
                AISpriteImage.flipX = false;
            
                if(moveAIVertical > 0)
                {
                    AIAnim.SetInteger("enemyMovey",1);
                }
                else if(moveAIVertical < 0)
                {
                    AIAnim.SetInteger("enemyMovey",-1);
                }
            }

            else
            {
                AIAnim.SetInteger("enemyMovey",0);

                if(moveAIHorizontal > 0)
                {
                    AIAnim.SetBool("enemyMovex", true);
                    AISpriteImage.flipX = true;
                }
                else if (moveAIHorizontal < 0)
                {
                    AIAnim.SetBool("enemyMovex", true);
                    AISpriteImage.flipX = false;
                }
                else
                {
                    AIAnim.SetBool("enemyMovex", false);
                }
            }
        }
    }




}

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
    private bool playerNotDetected = true;
    private GameObject detection = default;
    public Transform professor;
    private Vector2 previouslocation;
    private float distlocationx;
    private float distlocationy;


    void Start()
    {
        detection = transform.GetChild(1).gameObject;
        detection.SetActive(playerNotDetected);
        AIAnim=(Animator)GetComponent(typeof(Animator));
        AISpriteImage =(SpriteRenderer)GetComponent(typeof(SpriteRenderer));
        previouslocation = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        playerNotDetected = false;
        detection.SetActive(playerNotDetected);
    }

    void Update()
    {
        ProfAndAIDistx = professor.transform.position.x - transform.position.x;
        ProfAndAIDisty = professor.transform.position.y - transform.position.y;
        distlocationx = transform.position.x - previouslocation.x;
        distlocationy = transform.position.y - previouslocation.y;
        if(playerNotDetected == false)
        {
            transform.Translate(new Vector2(ProfAndAIDistx * AIspeed, ProfAndAIDisty * AIspeed) * Time.deltaTime);
            if(distlocationy != 0)
            {
                AIAnim.SetBool("walkHorizontal", false);
                AISpriteImage.flipX = false;
            
                if(distlocationy > 0)
                {
                    AIAnim.SetBool("walkUp", true);
                    AIAnim.SetBool("walkDown", false);
                }
                else if(distlocationy < 0)
                {
                    AIAnim.SetBool("walkDown", true);
                    AIAnim.SetBool("walkUp", false);
                }
            }

            else
            {
                AIAnim.SetBool("walkUp", false);
                AIAnim.SetBool("walkDown", false);

                if(distlocationx > 0)
                {
                    AIAnim.SetBool("walkHorizontal", true);
                    AISpriteImage.flipX = true;
                }
                else if (distlocationx < 0)
                {
                    AIAnim.SetBool("walkHorizontal", true);
                    AISpriteImage.flipX = false;
                }
                else
                {
                    AIAnim.SetBool("walkHorizontal", false);
                }
            }
        }
    }




}

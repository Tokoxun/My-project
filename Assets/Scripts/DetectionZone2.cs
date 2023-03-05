using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone2 : MonoBehaviour
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
    private float distlocation;


    void Start()
    {
        detection = transform.GetChild(1).gameObject;
        detection.SetActive(playerNotDetected);
        AIAnim=(Animator)GetComponent(typeof(Animator));
        AISpriteImage =(SpriteRenderer)GetComponent(typeof(SpriteRenderer));

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        playerNotDetected = false;
        detection.SetActive(playerNotDetected);
        previouslocation = transform.position;
    }

    void Update()
    {
        ProfAndAIDistx = professor.transform.position.x - transform.position.x;
        ProfAndAIDisty = professor.transform.position.y - transform.position.y;
        distlocation = transform.position.x - previouslocation.x; 
        if(playerNotDetected == false)
        {
            transform.Translate(new Vector2(ProfAndAIDistx * AIspeed, ProfAndAIDisty * AIspeed) * Time.deltaTime);
            if(previouslocation.x != transform.position.x)
            {
                AIAnim.SetBool("walkHorizontal", true);  

                if(distlocation > 0)
                {
                    AISpriteImage.flipX = false;
                }
                else if(distlocation < 0)
                {
                    AISpriteImage.flipX = true;
                }
            }

            else if (distlocation == 0)
            {
                AIAnim.SetBool("walkHorizontal", false);
            }
        }

    }
}

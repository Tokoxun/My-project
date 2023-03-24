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
    public Transform colliderRotate;


    void Start()
    {
        detection = transform.GetChild(1).gameObject;
        detection.SetActive(playerNotDetected);
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
        if(playerNotDetected == false)
        {
            transform.Translate(new Vector2(ProfAndAIDistx * AIspeed, ProfAndAIDisty * AIspeed) * Time.deltaTime);
            if(ProfAndAIDistx != 0)
            {
                AIAnim.SetBool("walkHorizontal", true);  

                if(ProfAndAIDistx > 0)
                {
                    colliderRotate.transform.rotation = Quaternion.Euler(0, 0, 90);
                    AISpriteImage.flipX = false;
                }
                else if(ProfAndAIDistx < 0)
                {
                    colliderRotate.transform.rotation = Quaternion.Euler(0, 0, 270);
                    AISpriteImage.flipX = true;
                }
            }

            else if (ProfAndAIDistx == 0)
            {
                AIAnim.SetBool("walkHorizontal", false);
            }
        }

    }
}

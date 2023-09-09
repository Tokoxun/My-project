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
    private Transform professor;
    public Transform AttackAreaColliderRotate;
    public Transform DetectionColliderRotate;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        detection = transform.GetChild(1).gameObject;
        detection.SetActive(playerNotDetected);
        AIAnim=(Animator)GetComponent(typeof(Animator));
        AISpriteImage =(SpriteRenderer)GetComponent(typeof(SpriteRenderer));

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ally")
        {
            professor = collider.transform;
            playerNotDetected = false;
            detection.SetActive(playerNotDetected);
        }
    }
    void FixedUpdate()
    { 
        if(playerNotDetected == false)
        {
            ProfAndAIDistx = professor.transform.position.x - transform.position.x;
            ProfAndAIDisty = professor.transform.position.y - transform.position.y;
            float distanceToPlayer = Vector2.Distance(transform.position, professor.position);
            // transform.Translate(new Vector2(ProfAndAIDistx * AIspeed, ProfAndAIDisty * AIspeed) * Time.deltaTime);
            Vector2 directionToPlayer = (professor.position - transform.position).normalized;
            
            // Move the enemy towards the player.
            rb.velocity = directionToPlayer * AIspeed;
            if(ProfAndAIDistx != 0)
            {
                AIAnim.SetBool("walkHorizontal", true);  

                if(ProfAndAIDistx > 0)
                {
                    AttackAreaColliderRotate.transform.rotation = Quaternion.Euler(0, 0, 90);
                    DetectionColliderRotate.transform.rotation = Quaternion.Euler(0, 0, 90);
                    AISpriteImage.flipX = false;
                }
                else if(ProfAndAIDistx < 0)
                {
                    AttackAreaColliderRotate.transform.rotation = Quaternion.Euler(0, 0, 270);
                    DetectionColliderRotate.transform.rotation = Quaternion.Euler(0, 0, 270);
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

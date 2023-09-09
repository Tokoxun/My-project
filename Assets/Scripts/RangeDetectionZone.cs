using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDetectionZone : MonoBehaviour
{
    private Animator AIAnim;
    private SpriteRenderer AISpriteImage;
    private float ProfAndAIDist;
    private float ProfAndAIDisty;
    private bool playerNotDetected = true;
    private GameObject detection;
    private bool attacks = false;
    private GameObject range;
    private Transform professor;
    public float AIspeed = 2f;
    private float timeToAvoid;
    private float AvoidCooldown = 3f;
    private float AvoidDist = 3f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        range = transform.GetChild(0).gameObject;
        detection = transform.GetChild(1).gameObject;
        range.SetActive(attacks);
        detection.SetActive(playerNotDetected);
        AIAnim=(Animator)GetComponent(typeof(Animator));
        AISpriteImage =(SpriteRenderer)GetComponent(typeof(SpriteRenderer));
        timeToAvoid = AvoidCooldown;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ally")
        {
            professor = collider.transform;
            playerNotDetected = false;
            detection.SetActive(playerNotDetected);
            attacks = true;
            range.SetActive(attacks);
        }
    }

    void FixedUpdate()
    {
        if(playerNotDetected == false)
        {
            ProfAndAIDist = Vector2.Distance(professor.transform.position, transform.position);
            Vector2 directionToPlayer = (professor.position - transform.position).normalized;
            ProfAndAIDisty = professor.transform.position.y - transform.position.y;
            timeToAvoid += Time.deltaTime;
            if(ProfAndAIDist <= 5 && timeToAvoid >= AvoidCooldown)
            {    
                if(professor.transform.position.x > transform.position.x)
                {
                    rb.velocity = -directionToPlayer * AvoidDist;
                    // AISpriteImage.flipX = true;
                    transform.rotation = Quaternion.Euler(0, 550, 0);
                    // AIAnim.SetBool("walking", true);
                }

                else if(professor.transform.position.x < transform.position.x)
                {
                    rb.velocity = -directionToPlayer * AvoidDist;
                    // AISpriteImage.flipX = false;
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    // AIAnim.SetBool("walking", true);
                }
            }
            if(ProfAndAIDist > 5 && timeToAvoid >= AvoidCooldown)
            {
                if(professor.transform.position.x > transform.position.x)
                {
                    // AISpriteImage.flipX = false;
                    transform.rotation = Quaternion.Euler(0, 550, 0);
                    // AIAnim.SetBool("walking", false);
                    timeToAvoid = 0;
                }
                else if(professor.transform.position.x < transform.position.x)
                {
                    // AISpriteImage.flipX = true;
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    // AIAnim.SetBool("walking", false);
                    timeToAvoid = 0;
                }
            }
            if(timeToAvoid <= AvoidCooldown)
            {
                rb.velocity = directionToPlayer * AIspeed;
            }

            transform.Translate(new Vector2(0, ProfAndAIDisty) * Time.deltaTime);
        }
    }
}

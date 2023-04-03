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
    public Transform professor;
    private float timeToAvoid;
    private float AvoidCooldown = 3f;
    private float AvoidDist = 6f;
    public Transform bowPos;

    void Start()
    {
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
            playerNotDetected = false;
            detection.SetActive(playerNotDetected);
            attacks = true;
            range.SetActive(attacks);
        }
    }

    void Update()
    {
        int profposy = Mathf.RoundToInt(professor.transform.position.y);
        int AIposy = Mathf.RoundToInt(transform.position.y);
        ProfAndAIDist = Vector2.Distance(professor.transform.position, transform.position);
        ProfAndAIDisty = professor.transform.position.y - transform.position.y;
        if(playerNotDetected == false)
        {
            timeToAvoid += Time.deltaTime;
            if(ProfAndAIDist <= 5 && timeToAvoid >= AvoidCooldown)
            {    
                if(professor.transform.position.x > transform.position.x)
                {
                    transform.Translate(new Vector2(transform.position.x - AvoidDist, 0) * Time.deltaTime);
                    AISpriteImage.flipX = true;
                    bowPos.transform.rotation = Quaternion.Euler(0, 0, 180);
                    AIAnim.SetBool("walking", true);
                }

                else if(professor.transform.position.x < transform.position.x)
                {
                    transform.Translate(new Vector2(transform.position.x + AvoidDist, 0) * Time.deltaTime);
                    AISpriteImage.flipX = false;
                    bowPos.transform.rotation = Quaternion.Euler(0, 0, 0);
                    AIAnim.SetBool("walking", true);
                }
            }
            if(ProfAndAIDist > 5 && timeToAvoid >= AvoidCooldown)
            {
                if(professor.transform.position.x > transform.position.x)
                {
                    AISpriteImage.flipX = false;
                    bowPos.transform.rotation = Quaternion.Euler(0, 0, 180);
                    AIAnim.SetBool("walking", false);
                    timeToAvoid = 0;
                }
                else if(professor.transform.position.x < transform.position.x)
                {
                    AISpriteImage.flipX = true;
                    bowPos.transform.rotation = Quaternion.Euler(0, 0, 0);
                    AIAnim.SetBool("walking", false);
                    timeToAvoid = 0;
                }
            }

            transform.Translate(new Vector2(0, ProfAndAIDisty) * Time.deltaTime);
        }
    }
}

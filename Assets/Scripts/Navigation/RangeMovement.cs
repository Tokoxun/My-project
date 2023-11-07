using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeMovement : MonoBehaviour
{
    private Animator AIAnim;
    private SpriteRenderer AISpriteImage;
    private float ProfAndAIDist;
    private float ProfAndAIDisty;
    public bool playerSpotted = false;
    public bool ChasingPlayer = false;
    public GameObject range;
    public Transform professor;
    public float AIspeed = 2f;
    private float timeToAvoid;
    private float AvoidCooldown = 3f;
    private float AvoidDist = 3f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        range = transform.GetChild(0).gameObject;
        range.SetActive(false);
        AIAnim=(Animator)GetComponent(typeof(Animator));
        AISpriteImage =(SpriteRenderer)GetComponent(typeof(SpriteRenderer));
        timeToAvoid = AvoidCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(ChasingPlayer == true)
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

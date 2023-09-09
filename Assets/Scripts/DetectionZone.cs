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
    public bool playerNotDetected = true;
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
            int profposy = Mathf.RoundToInt(professor.transform.position.y);
            int AIposy = Mathf.RoundToInt(transform.position.y);
            // transform.Translate(new Vector2(ProfAndAIDistx * AIspeed, ProfAndAIDisty * AIspeed) * Time.deltaTime);
            Vector2 directionToPlayer = (professor.position - transform.position).normalized;
            
            // Move the enemy towards the player.
            rb.velocity = directionToPlayer * AIspeed;
            if(AIposy != profposy)
            {
                AIAnim.SetBool("walkHorizontal", false);
                AISpriteImage.flipX = false;
            
                if(ProfAndAIDisty > 0)
                {
                    AIAnim.SetBool("walkUp", true);
                    AIAnim.SetBool("walkDown", false);
                    AttackAreaColliderRotate.transform.rotation = Quaternion.Euler(0, 0, 180);
                    DetectionColliderRotate.transform.rotation = Quaternion.Euler(0, 0, 270);
                }
                else if(ProfAndAIDisty < 0)
                {
                    AIAnim.SetBool("walkDown", true);
                    AIAnim.SetBool("walkUp", false);
                    AttackAreaColliderRotate.transform.rotation = Quaternion.Euler(0, 0, 0);
                    DetectionColliderRotate.transform.rotation = Quaternion.Euler(0, 0, 270);
                }
            }

            else
            {
                AIAnim.SetBool("walkUp", false);
                AIAnim.SetBool("walkDown", false);

                if(ProfAndAIDistx > 0)
                {
                    AIAnim.SetBool("walkHorizontal", true);
                    AISpriteImage.flipX = true;
                    AttackAreaColliderRotate.transform.rotation = Quaternion.Euler(0, 0, 90);
                    DetectionColliderRotate.transform.rotation = Quaternion.Euler(0, 0, 270);
                }
                else if (ProfAndAIDistx < 0)
                {
                    AIAnim.SetBool("walkHorizontal", true);
                    AISpriteImage.flipX = false;
                    AttackAreaColliderRotate.transform.rotation = Quaternion.Euler(0, 0, 270);
                    DetectionColliderRotate.transform.rotation = Quaternion.Euler(0, 0, 270);
                }
                else
                {
                    AIAnim.SetBool("walkHorizontal", false);
                }
            }
        }
    }




}

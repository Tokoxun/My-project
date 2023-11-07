using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    private Animator AIAnim;
    private SpriteRenderer AISpriteImage;
    public float AIspeed = 2f;
    private float ProfAndAIDistx;
    private float ProfAndAIDisty;
    public bool ChasingPlayer = false;
    public bool playerSpotted = false;
    public Transform professor;
    public Transform AttackAreaColliderRotate;
    private Rigidbody2D rb;
    private Vector2 stopVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AIAnim=(Animator)GetComponent(typeof(Animator));
        AISpriteImage =(SpriteRenderer)GetComponent(typeof(SpriteRenderer));
    }

    void Update()
    { 
        if(ChasingPlayer == true)
        {
            ProfAndAIDistx = professor.transform.position.x - transform.position.x;
            ProfAndAIDisty = professor.transform.position.y - transform.position.y;
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
                    AISpriteImage.flipX = false;
                }
                else if(ProfAndAIDistx < 0)
                {
                    AttackAreaColliderRotate.transform.rotation = Quaternion.Euler(0, 0, 270);
                    AISpriteImage.flipX = true;
                }
            }

            else if (ProfAndAIDistx == 0)
            {
                AIAnim.SetBool("walkHorizontal", false);
            }
        }

        if(playerSpotted == true && ChasingPlayer == false)
        {
            stopVelocity = new Vector2(0, 0); 
            rb.velocity = stopVelocity;
            AIAnim.SetBool("walkHorizontal", false);
        }
    }
}

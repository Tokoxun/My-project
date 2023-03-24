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
        int profposy = Mathf.RoundToInt(professor.transform.position.y);
        int AIposy = Mathf.RoundToInt(transform.position.y);
        ProfAndAIDistx = professor.transform.position.x - transform.position.x;
        ProfAndAIDisty = professor.transform.position.y - transform.position.y;
        if(playerNotDetected == false)
        {
            transform.Translate(new Vector2(ProfAndAIDistx * AIspeed, ProfAndAIDisty * AIspeed) * Time.deltaTime);
            if(AIposy != profposy)
            {
                AIAnim.SetBool("walkHorizontal", false);
                AISpriteImage.flipX = false;
            
                if(ProfAndAIDisty > 0)
                {
                    AIAnim.SetBool("walkUp", true);
                    AIAnim.SetBool("walkDown", false);
                    colliderRotate.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
                else if(ProfAndAIDisty < 0)
                {
                    AIAnim.SetBool("walkDown", true);
                    AIAnim.SetBool("walkUp", false);
                    colliderRotate.transform.rotation = Quaternion.Euler(0, 0, 0);
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
                    colliderRotate.transform.rotation = Quaternion.Euler(0, 0, 90);
                }
                else if (ProfAndAIDistx < 0)
                {
                    AIAnim.SetBool("walkHorizontal", true);
                    colliderRotate.transform.rotation = Quaternion.Euler(0, 0, 270);
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

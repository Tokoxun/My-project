using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator AIAnim;
    private SpriteRenderer AISpriteImage;

    private float attackTimer = 1f;
    private float timer = 0f;
    private GameObject atkRange = default;
    private bool atk = false;

    // Start is called before the first frame update
    void Start()
    {
        AIAnim = (Animator)GetComponent(typeof(Animator));
        AISpriteImage =(SpriteRenderer)GetComponent(typeof(SpriteRenderer));
        atkRange = transform.GetChild(0).gameObject;
        atkRange.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Collider2D>().CompareTag("Ally"))
        {
            AIAnim.SetBool("enemyAtky", true);

            if(AISpriteImage.flipX == false)
            {
                AIAnim.SetBool("enemyAtkx", true);
            }
            else if(AISpriteImage.flipX == true)
            {
                AIAnim.SetBool("enemyAtkx", true);
            }
            atkRange.SetActive(false);
            atk = true;
        }
    }

    void Update()
    {
        if(atk)
        {
            timer += Time.deltaTime;

            if(timer >= attackTimer)
            {
                timer = 0;
                AIAnim.SetBool("enemyAtky", false);
                AIAnim.SetBool("enemyAtkx", false);
                atkRange.SetActive(true);
            }
        }
    }

}

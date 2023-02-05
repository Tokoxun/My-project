using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator AIAnim;
    private SpriteRenderer AISpriteImage;

    private bool attacking = false;
    private GameObject enemyAttackArea = default;

    private float attackTimer = 0.25f;
    private float timer = 0f;
    private int damage = 3;


    // Start is called before the first frame update
    void Start()
    {
        enemyAttackArea = transform.GetChild(0).gameObject;
        AIAnim = (Animator)GetComponent(typeof(Animator));
        AISpriteImage =(SpriteRenderer)GetComponent(typeof(SpriteRenderer));
    }

    void Update()
    {
        if(attacking)
        {
            timer += Time.deltaTime;
            AIAnim.SetBool("enemyAtky", true);

            if(AISpriteImage.flipX == false)
            {
                AIAnim.SetBool("enemyAtkx", true);
            }
            else if(AISpriteImage.flipX == true)
            {
                AIAnim.SetBool("enemyAtkx", true);
            }

            if(timer >= attackTimer)
            {
                timer = 0;
                attacking = false;
                enemyAttackArea.SetActive(attacking);
                AIAnim.SetBool("enemyAtky", false);
                AIAnim.SetBool("enemyAtkx", false);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Collider2D>().tag == "Ally" && col.GetComponent<Health>() != null)
        {
            attacking = true;
            enemyAttackArea.SetActive(attacking);
            Health health = GetComponent<Collider2D>().GetComponent<Health>();
            health.Damage(damage);
            Debug.Log("Hit");
        } 
    }

}

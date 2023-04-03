using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator AIAnim;
    private SpriteRenderer AISpriteImage;

    private float attackTimer = 1f;
    private float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        AIAnim = (Animator)GetComponent(typeof(Animator));
        AISpriteImage =(SpriteRenderer)GetComponent(typeof(SpriteRenderer));
    }

    public void EnemyAction()
    {
            Debug.Log("attacked");
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
                AIAnim.SetBool("enemyAtky", false);
                AIAnim.SetBool("enemyAtkx", false);
            }
        
    }

}

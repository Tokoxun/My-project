using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack2 : MonoBehaviour
{
    private Animator AIAnim;
    private SpriteRenderer AISpriteImage;

    private float attackTimer = 2f;
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
            AIAnim.SetBool("attacking", true);

            if(AISpriteImage.flipX == false)
            {
                AIAnim.SetBool("attacking", true);
            }
            else if(AISpriteImage.flipX == true)
            {
                AIAnim.SetBool("attacking", true);
            }

            if(timer >= attackTimer)
            {
                timer = 0;
                AIAnim.SetBool("attacking", false);
            }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer profSpriteImage;

    private Animator profAnim;

    private GameObject attackArea = default;

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        profAnim = (Animator)GetComponent(typeof(Animator));
        profSpriteImage =(SpriteRenderer)GetComponent(typeof(SpriteRenderer));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Attack();
            profAnim.SetBool("yAttk", true);

            if(profSpriteImage.flipX == false)
            {
                profAnim.SetBool("xAttk", true);
            }
            else if(profSpriteImage.flipX == true)
            {
                profAnim.SetBool("xAttk", true);
            }
        }

        if(attacking)
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
                profAnim.SetBool("yAttk", false);
                profAnim.SetBool("xAttk", false);
            }

        }
    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
        Debug.Log("attacking");
    }
}

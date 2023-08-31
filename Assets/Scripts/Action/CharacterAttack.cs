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

    public SlashProjectile SlashPrefab;
    public Transform Sword;
    private float readyingSlash;
    private float SlashCooldown = 2f;
    private bool hadFired = false;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        profAnim = (Animator)GetComponent(typeof(Animator));
        profSpriteImage =(SpriteRenderer)GetComponent(typeof(SpriteRenderer));
    }

    void Update()
    {
        readyingSlash += Time.deltaTime;
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

    // Update is called once per frame
    public void attackButton()
    {
        // Attack();
        attacking = true;
        attackArea.SetActive(attacking);
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

    public void SlashButton()
    {
        if(readyingSlash >= SlashCooldown)
        {
            attacking = true;
            profAnim.SetBool("yAttk", true);
            if(profSpriteImage.flipX == false)
            {
                profAnim.SetBool("xAttk", true);
            }
            else if(profSpriteImage.flipX == true)
            {
                profAnim.SetBool("xAttk", true);
            }
            Instantiate(SlashPrefab, Sword.position, Sword.rotation);
            hadFired = true;
        }
        if(hadFired == true && readyingSlash >= SlashCooldown)
        {
            readyingSlash = 0;
        }
    }

    // private void Attack()
    // {
    //     attacking = true;
    //     attackArea.SetActive(attacking);
    //     Debug.Log("attacking");
    // }
}

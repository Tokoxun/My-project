using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack2 : MonoBehaviour
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
            Debug.Log("attacked");
            AIAnim.SetBool("attacking", true);
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
                Debug.Log("Atk finished");
                timer = 0;
                AIAnim.SetBool("attacking", false);
                atkRange.SetActive(true);
                atk = false;
            }
        }
    }
}

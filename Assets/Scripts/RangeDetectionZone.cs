using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDetectionZone : MonoBehaviour
{
    private Animator AIAnim;
    private SpriteRenderer AISpriteImage;
    public float AIspeed = 2f;
    private float ProfAndAIDistx;
    private float ProfAndAIDisty;
    private bool playerNotDetected = true;
    private GameObject detection = default;
    private bool attacks = false;
    private GameObject range;
    public Transform professor;


    void Start()
    {
        range = transform.GetChild(0).gameObject;
        detection = transform.GetChild(1).gameObject;
        range.SetActive(attacks);
        detection.SetActive(playerNotDetected);
        AIAnim=(Animator)GetComponent(typeof(Animator));
        AISpriteImage =(SpriteRenderer)GetComponent(typeof(SpriteRenderer));
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        playerNotDetected = false;
        detection.SetActive(playerNotDetected);
        attacks = true;
        range.SetActive(attacks);
    }

    void Update()
    {
        int profposy = Mathf.RoundToInt(professor.transform.position.y);
        int AIposy = Mathf.RoundToInt(transform.position.y);
        ProfAndAIDistx = professor.transform.position.x - transform.position.x;
        ProfAndAIDisty = professor.transform.position.y - transform.position.y;
        if(playerNotDetected == false)
        {
            // transform.Translate(new Vector2(ProfAndAIDistx * AIspeed, ProfAndAIDisty * AIspeed) * Time.deltaTime);
        }
    }
}

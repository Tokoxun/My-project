using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttackArea : MonoBehaviour
{
    private float stoppingTime = 1f;
    private float timeStoped = 0f;
    private bool haveStoped = false;
    // Start is called before the first frame update
    public float damage = 3f;

    void Start()
    {
        Difficulty.Instance.Buff(damage);
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Ally")
        {
            TankMovement stopMove = GetComponentInParent<TankMovement>();
            stopMove.ChasingPlayer = false;
            haveStoped = true; 
        }
        if(collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
    }

    void Update()
    {
        Debug.Log(haveStoped);
        if(haveStoped)
        {
            timeStoped += Time.deltaTime;
            if(timeStoped >= stoppingTime)
            {
                timeStoped = 0;
                TankMovement stopMove = GetComponentInParent<TankMovement>();
                stopMove.ChasingPlayer = true;
                haveStoped = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider HealthBar;
    public Text HealthAndMaxHealth;
    [SerializeField] float health = 100;

    private int MAX_HEALTH = 100;

    // Update is called once per frame
    void Update()
    {
        int roundedHealth = Mathf.RoundToInt(health);
        HealthBar.value = roundedHealth;
        HealthAndMaxHealth.text = roundedHealth + "/" + MAX_HEALTH;
        // if (Input.GetKeyDown(KeyCode.D))
        // {
        //     // Damage(10);
        // }

        // if (Input.GetKeyDown(KeyCode.H))
        // {
        //     // Heal(10);
        // }
    }

    public void Damage(float amount)
    {
        UIManager died = FindObjectOfType<UIManager>();
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount;
        Debug.Log(this.health);

        if(this.health <= 0)
        {
            died.PlayerDied();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;

        if (wouldBeOverMaxHealth)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
    }

    // private void Die()
    // {
    //     Debug.Log("I am Dead!");
    //     Destroy(gameObject);
    // }
}

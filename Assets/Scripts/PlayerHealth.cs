using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar HPBar;

    [SerializeField] [Range(0, 10)] private int maxHealth;
    [SerializeField] private int health;

    private void Awake()
    {
        health = maxHealth;
        HPBar.SetMaxHealth(maxHealth);
    }

    private void CheckHealth()
    {
        HPBar.SetHealth(health);

        if (health <= 1)
        {
            HPBar.fill.color = Color.red;
        }
        else
        {
            HPBar.fill.color = Color.green;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            //Display Game Over Overlay
        }
    }

    public void ReduceHealth()
    {
        health--;
        CheckHealth();
    }
}
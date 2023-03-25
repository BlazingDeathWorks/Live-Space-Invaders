using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] private int maxHealth;
    private int health;

    public Slider slider;
    public Image fill;

    private void Awake()
    {
        health = maxHealth;
        SetMaxHealth(maxHealth);
    }

    private void CheckHealth()
    {
        SetHealth(health);

        if (health <= 1)
        {
            fill.color = Color.red;
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

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
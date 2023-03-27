using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] private int maxHealth;
    private int health;
	[SerializeField] private GameOverScript GOScript;

    [SerializeField] private Slider slider;
    [SerializeField] private Image fill;

    private void Awake()
    {
        health = maxHealth;
        slider.maxValue = health;
        slider.value = health;
    }

    private void CheckHealth()
    {
        UpdateHealth();

        if (health <= 1)
        {
            fill.color = Color.red;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            //Display Game Over Overlay
			GOScript.GameOver();
        }
    }

    private void UpdateHealth()
    {
        slider.value = health;
    }

    public void ReduceHealth()
    {
        health--;
        CheckHealth();
    }
}
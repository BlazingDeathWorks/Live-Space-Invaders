using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] private int maxHealth;
    private int health;

    private void Awake()
    {
        health = maxHealth;
    }

    private void CheckHealth()
    {
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

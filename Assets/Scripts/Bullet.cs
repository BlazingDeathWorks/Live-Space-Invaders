using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float lifetime = 3;

    private void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);

        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().ReduceHealth();
        }

        //Enemies will die in one hit
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            //Add score
			PlayerScore.score += 5;
        }
    }
}
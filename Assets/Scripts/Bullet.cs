using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        transform.Translate(0, 5 * Time.deltaTime, 0);

        Destroy(gameObject, 3f);
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
            return;
        }
    }
}
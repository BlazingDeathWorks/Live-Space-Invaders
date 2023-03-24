using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
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

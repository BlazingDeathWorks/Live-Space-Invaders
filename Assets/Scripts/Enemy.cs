using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public PathData path;
    [SerializeField] private Bullet bulletPrefab;

    [SerializeField] private float minTime = 2f;
    [SerializeField] private float maxTime = 5f;
    float timeToSpend = 0f;
    float timeSpent = 0f;

    [SerializeField] private float speed = 0.2f;

    private int pos = 0;

    [SerializeField] private Transform firePoint;

    void Awake()
    {
        RandomizeTime();
    }

    void Update()
    {
        if (path == null) return;

        if (pos >= path.position.Length)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, path.position[pos], speed);
        if (Vector3.Distance(transform.position, path.position[pos]) < 0.2)
            pos++;

        timeSpent += Time.deltaTime;
        if (timeSpent >= timeToSpend)
            Shoot();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().ReduceHealth();
            Destroy(gameObject);
        }
    }

    void RandomizeTime()
    {
        timeToSpend = Random.Range(minTime, maxTime);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(new Vector3(180, 0, 0)));
        RandomizeTime();
        timeSpent = 0f;
    }
}
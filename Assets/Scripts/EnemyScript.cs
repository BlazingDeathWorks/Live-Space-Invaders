using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [HideInInspector] public PathData path;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float minTime = 2f;
    [SerializeField] private float maxTime = 5f;
    float timeToSpend = 0f;
    float timeSpent = 0f;

    [SerializeField] private float speed = 0.2f;

    private int pos = 0;

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

        transform.position = Vector2.MoveTowards(getPlayerVec2(), path.position[pos], speed);
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
        }
    }

    Vector2 getPlayerVec2()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }

    void RandomizeTime()
    {
        timeToSpend = Random.Range(minTime, maxTime);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(180, 0, 0)));
        RandomizeTime();
        timeSpent = 0f;
    }
}

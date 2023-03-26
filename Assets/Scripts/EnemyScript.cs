using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyScript : MonoBehaviour
{
    public float maxTime = 5f;
    public float minTime = 2f;
    float timeToSpend = 0f;
    float timeSpent = 0f;

    public float speed = 0.2f;

    public GameObject bulletPrefab;
    public PathData path;

    private int pos = 0;

    void Awake()
    {
        RandomizeTime();
    }
    void Update()
    {
        /*        Vector2 direction = (getPlayerVec2() - path.position[pos]).normalized;*/
        transform.position = Vector2.MoveTowards(getPlayerVec2(), path.position[pos], speed);
        if (Vector3.Distance(transform.position, path.position[pos]) < 0.2)
            pos++;
        pos = Math.Clamp(pos, 0, path.position.Length-1);

        timeSpent += Time.deltaTime;
        if (timeSpent >= timeToSpend)
            Shoot();
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
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(Vector3.right*180));
        RandomizeTime();
        timeSpent = 0f;
    }
}

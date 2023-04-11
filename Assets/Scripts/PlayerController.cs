using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float movement;

    [SerializeField] private float fireRate;
    private float fireTime;

    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform firePoint;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");

        fireTime -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse0) && fireTime <= 0)
        {
            Instantiate(bullet, firePoint.position, Quaternion.identity);
            fireTime = fireRate;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement * moveSpeed, 0f);
    }
}
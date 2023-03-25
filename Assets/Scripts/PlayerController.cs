using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float movement;

    [SerializeField] private float fireRate;
    private float fireTime;

    [SerializeField] private GameObject bullet;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        fireTime = fireRate;
    }

    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");

        Shooting();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement * moveSpeed, 0f);
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            fireTime -= Time.deltaTime;

            if (fireTime <= 0)
            {
                Instantiate(bullet, new Vector3 (transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
                fireTime = fireRate;
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            fireTime = fireRate;
        }
    }
}
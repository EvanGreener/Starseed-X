using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float strifeSpeed = 2.0f;
    public float verticalSpeed = 2.0f;
    public float forwardBackwardSpeed = 0.25f;

    Rigidbody rb;
    float horizontal = 0.0f;
    float vertical = 0.0f;
    float forward;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Capture input
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        forward = Input.GetButton("Forward") ? forwardBackwardSpeed : -forwardBackwardSpeed;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontal * strifeSpeed, vertical * strifeSpeed, forward);

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, horizontal * -30));
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag.CompareTo("Obstacle") == 0)
        {
            Debug.Log("Game over");
            Destroy(gameObject);
        }
    }
}

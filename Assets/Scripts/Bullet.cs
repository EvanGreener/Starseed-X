using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float ttl = 2.0f;

    Rigidbody rb;
    float elapsed = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward * speed;
    }

    void Update()
    {
        elapsed += Time.deltaTime;

        if (elapsed >= ttl)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
    }


}

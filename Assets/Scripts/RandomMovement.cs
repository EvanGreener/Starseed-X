using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemyController : MonoBehaviour
{
    public float speed = 20.0f;
    public float verticalSpeed = 5.0f;
    public float switchDirectionTime = 3.0f;
    Vector3 despawn;
    float elapsed = 0.0f;
    Rigidbody rb;
    Vector3 currentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        despawn = GameObject.Find("Clouds end").transform.position;
        rb = GetComponent<Rigidbody>();

        currentVelocity = new Vector3(Random.value * verticalSpeed, Random.value * verticalSpeed, -speed);
        rb.velocity = currentVelocity;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.z <= despawn.z)
        {
            Destroy(gameObject);
        }

        if (elapsed > switchDirectionTime)
        {
            currentVelocity = new Vector3(Random.Range(-1f, 1f) * verticalSpeed, Random.Range(-1f, 1f) * verticalSpeed, -speed);
            rb.velocity = currentVelocity;
            elapsed = 0f;
        }

        elapsed += Time.deltaTime;
    }
}

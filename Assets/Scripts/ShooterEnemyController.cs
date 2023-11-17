using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemyController : MonoBehaviour
{
    public float speed = 10.0f;
    public float fireRate = 1.0f;
    public GameObject bulletPrefab;
    float elapsedSinceFire;

    Vector3 despawn;

    // Start is called before the first frame update
    void Start()
    {
        despawn = GameObject.Find("Clouds end").transform.position;
        GetComponent<Rigidbody>().velocity = Vector3.forward * -speed;

        elapsedSinceFire = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= despawn.z)
        {
            Destroy(gameObject);
        }

        if (elapsedSinceFire >= (1.0f / fireRate))
        {
            Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
            elapsedSinceFire = 0.0f;
        }
        else
        {
            elapsedSinceFire += Time.deltaTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperEnemyController : MonoBehaviour
{
    public float speed = 10.0f;
    Vector3 despawn;

    // Start is called before the first frame update
    void Start()
    {
        despawn = GameObject.Find("Clouds end").transform.position;
        GetComponent<Rigidbody>().velocity = Vector3.forward * -speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= despawn.z)
        {
            Destroy(gameObject);
        }
    }
}

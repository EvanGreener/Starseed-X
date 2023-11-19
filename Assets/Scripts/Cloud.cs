using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed = 20.0f;
    public Transform cloudStart;
    Vector3 start;
    Vector3 end;

    void Start()
    {
        start = cloudStart.position;
        end = GameObject.Find("Clouds end").transform.position;
        GetComponent<Rigidbody>().velocity = Vector3.forward * -speed;
    }

    void Update()
    {
        if (transform.position.z <= end.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, start.z);
        }
    }
}

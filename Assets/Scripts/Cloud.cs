using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public static float speed = 20.0f;
    Vector3 start;
    Vector3 end;

    void Start()
    {
        start = GameObject.Find("Clouds start").transform.position;
        end = GameObject.Find("Clouds end").transform.position;
        GetComponent<Rigidbody>().velocity = Vector3.forward * -speed;
    }

    void Update()
    {
        if (transform.position.z <= end.z)
        {
            transform.position = new Vector3(transform.position.x, start.y, start.z);
        }
    }
}

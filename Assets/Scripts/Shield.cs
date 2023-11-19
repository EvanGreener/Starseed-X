using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public PlayerController player;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        transform.position = player.transform.position;
    }

    // The enemy bullets aren't triggers
    void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag.CompareTo("Obstacle") == 0)
        {
            Destroy(obj);
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Destroy(collider.gameObject);
        gameObject.SetActive(false);
    }
}

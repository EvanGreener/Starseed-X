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
    void FixedUpdate()
    {
        rb.velocity = player.GetComponent<Rigidbody>().velocity;
    }

    void OnTriggerEnter(Collider collider)
    {
        Destroy(collider.gameObject);
        gameObject.SetActive(false);
    }
}

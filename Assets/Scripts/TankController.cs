using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.GraphView;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public float strifeSpeed = 2.0f;
    public float verticalSpeed = 2.0f;
    public float forwardBackwardSpeed = 0.25f;
    public GameManager gameManager;
    public GunController gunController;
    public GameObject shield;

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
            GameData.LastScore = gameManager.score + "";
            SceneManager.LoadScene(0);
        }


    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject obj = collider.gameObject;
        if (obj.tag.CompareTo("100") == 0)
        {
            gameManager.UpdateScore(100);
            Debug.Log("+100 score powerup");
            Destroy(obj);
        }
        else if (obj.tag.CompareTo("shield") == 0)
        {
            shield.SetActive(true);
            Debug.Log("Shield powerup");
            Destroy(obj);

        }
        else if (obj.tag.CompareTo("multigun") == 0)
        {
            Debug.Log("Multigun powerup");
            Destroy(obj);

        }
        else if (obj.tag.CompareTo("cooling") == 0)
        {
            // Restart powerup timer
            gunController.coolingElapsed = 0f;
            Debug.Log("Cooling powerup");
            Destroy(obj);

        }
        else if (obj.tag.CompareTo("speed") == 0)
        {
            Debug.Log("Speed powerup");
            Destroy(obj);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float strifeSpeed = 2.0f;
    public float verticalSpeed = 2.0f;
    public float forwardBackwardSpeed = 0.25f;
    public GameManager gameManager;
    public GunController gunController;
    public GameObject shield;
    public float speedPowerUpDuration = 20f;

    public FloatingJoystick joystick;

    Rigidbody rb;
    float horizontal = 0.0f;
    float vertical = 0.0f;
    float speedMultiplier = 1f;
    float speedElapsed;
    SFXManager sFXManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speedElapsed = speedPowerUpDuration;
        sFXManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();

    }

    void Update()
    {
        // Capture input
        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;

        if (speedElapsed > speedPowerUpDuration)
        {
            speedMultiplier = 1f;
        }
        else if (speedElapsed <= 0f)
        {
            speedMultiplier = 2f;
            speedElapsed += Time.deltaTime;
        }
        else
        {
            speedElapsed += Time.deltaTime;
        }

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontal * strifeSpeed * speedMultiplier, vertical * strifeSpeed * speedMultiplier);

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, horizontal * -30));
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag.CompareTo("Obstacle") == 0)
        {
            Destroy(gameObject);
            GameData.LastScore = gameManager.score + (gameManager.time * 10) + "";
            SceneManager.LoadScene(0);
        }


    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject obj = collider.gameObject;

        // Enemies & obstacles
        if (obj.tag.CompareTo("Obstacle") == 0)
        {
            Destroy(gameObject);
            GameData.LastScore = gameManager.score + (gameManager.time * 10) + "";
            SceneManager.LoadScene(0);
        }

        // Power ups
        if (obj.tag.CompareTo("100") == 0)
        {
            sFXManager.PlayPickupSound();
            gameManager.UpdateScore(100);
            Destroy(obj);
        }
        else if (obj.tag.CompareTo("shield") == 0)
        {
            sFXManager.PlayPickupSound();
            shield.SetActive(true);
            Destroy(obj);

        }
        else if (obj.tag.CompareTo("multigun") == 0)
        {
            sFXManager.PlayPickupSound();
            gunController.multiGunElapsed = 0f;
            Destroy(obj);

        }
        else if (obj.tag.CompareTo("cooling") == 0)
        {
            sFXManager.PlayPickupSound();
            gunController.coolingElapsed = 0f;
            Destroy(obj);

        }
        else if (obj.tag.CompareTo("speed") == 0)
        {
            sFXManager.PlayPickupSound();
            speedElapsed = 0f;
            Destroy(obj);

        }
    }
}

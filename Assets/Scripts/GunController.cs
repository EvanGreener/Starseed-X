using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public OverheatBar overHeatBar;
    public float maxOverheat = 100.0f;
    public float overheatSpeed = 1.5f;
    public float heatCooldownSpeed = 0.5f;
    public float fireRate = 1.0f;
    // For the cooling power up
    public Image coolingImage;
    public float coolingMultiplier = 1f;
    public float coolingElapsed = 20f;
    float elapsedSinceFire;
    bool firing = false;
    float coolingDuration = 20f;


    void Start()
    {
        overHeatBar.SetMaxOverheat(maxOverheat);
        elapsedSinceFire = 1.0f / fireRate;
    }

    void Update()
    {
        // Firing code
        firing = Input.GetButton("Fire1");
        float heat = 0f;
        if (firing && elapsedSinceFire >= (1.0f / fireRate) && overHeatBar.GetCurrentOverHeat() < (overHeatBar.maxOverheat - 5))
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletPrefab.transform.rotation);
            elapsedSinceFire = 0.0f;
        }
        else if (elapsedSinceFire < (1.0f / fireRate))
        {
            elapsedSinceFire += Time.deltaTime;
        }

        if (firing)
        {
            heat += overheatSpeed * coolingMultiplier * Time.deltaTime;
        }
        else
        {
            heat = -heatCooldownSpeed * Time.deltaTime;
        }

        // When timer is done reset multiplier back to normal
        if (coolingElapsed > coolingDuration)
        {
            coolingImage.enabled = false;
            coolingMultiplier = 1f;
        }
        else if (coolingElapsed <= 0f)
        {
            coolingMultiplier = 0.5f;
            coolingImage.enabled = true;

            coolingElapsed += Time.deltaTime;
        }
        else
        {
            coolingElapsed += Time.deltaTime;
        }


        overHeatBar.SetCurrentOverheat(heat);


    }
}

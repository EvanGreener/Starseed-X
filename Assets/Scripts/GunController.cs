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
    float elapsedSinceFire;
    bool firing = false;
    // bullets/seconds

    void Start()
    {
        overHeatBar.SetMaxOverheat(maxOverheat);
        elapsedSinceFire = 1.0f / fireRate;
    }

    void Update()
    {
        // Firing code
        firing = Input.GetButton("Fire1");
        float heat = -heatCooldownSpeed;
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
            heat += overheatSpeed;
        }
        overHeatBar.SetCurrentOverheat(heat);


    }
}

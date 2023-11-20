using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    public Transform bulletSpawn;
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;
    public GameObject bulletPrefab;
    public OverheatBar overHeatBar;
    public float maxOverheat = 100.0f;
    public float overheatSpeed = 1.5f;
    public float heatCooldownSpeed = 0.5f;
    public float fireRate = 1.0f;
    // For the cooling power up
    public Image coolingImage;
    public float coolingMultiplier = 1f;
    public float coolingElapsed;
    public float coolingDuration = 20f;
    // For the multigun power up
    public float multiGunElapsed;
    public float multiGunDuration = 20f;

    float elapsedSinceFire;
    bool firing = false;

    AudioSource machineGunSounds;
    bool audioPlaying = false;

    void Start()
    {
        overHeatBar.SetMaxOverheat(maxOverheat);
        elapsedSinceFire = 1.0f / fireRate;
        coolingElapsed = coolingDuration;
        multiGunElapsed = multiGunDuration;
        machineGunSounds = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Firing code
        firing = Input.GetButton("Fire1");
        float heat = 0f;
        if (firing && elapsedSinceFire >= (1.0f / fireRate) && overHeatBar.GetCurrentOverHeat() < (overHeatBar.maxOverheat - 5))
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletPrefab.transform.rotation);
            if (multiGunElapsed <= multiGunDuration)
            {
                Instantiate(bulletPrefab, bulletSpawn1.position, bulletPrefab.transform.rotation);
                Instantiate(bulletPrefab, bulletSpawn2.position, bulletPrefab.transform.rotation);
            }
            elapsedSinceFire = 0.0f;
        }
        else if (elapsedSinceFire < (1.0f / fireRate))
        {
            elapsedSinceFire += Time.deltaTime;
        }

        // Overheat and cooling logic
        if (firing)
        {
            if (!audioPlaying)
            {
                machineGunSounds.Play();
                audioPlaying = true;
            }
            heat += overheatSpeed * coolingMultiplier * Time.deltaTime;
        }
        else
        {
            if (audioPlaying)
            {
                machineGunSounds.Stop();
                audioPlaying = false;
            }
            heat = -heatCooldownSpeed * Time.deltaTime;
        }

        if (overHeatBar.GetCurrentOverHeat() > (overHeatBar.maxOverheat - 5))
        {
            machineGunSounds.Stop();
            audioPlaying = false;
        }

        // Cooling power up logic
        if (coolingElapsed > coolingDuration)
        {
            coolingImage.enabled = false;
            coolingMultiplier = 1f;
        }
        else if (coolingElapsed <= 0f)
        {
            coolingMultiplier = 0.25f;
            coolingImage.enabled = true;
            coolingElapsed += Time.deltaTime;
        }
        else
        {
            coolingElapsed += Time.deltaTime;
        }

        // Multi gun power up logic
        if (multiGunElapsed <= multiGunDuration)
        {
            multiGunElapsed += Time.deltaTime;
        }


        overHeatBar.SetCurrentOverheat(heat);


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip explosion;
    public AudioClip powerUpPickup;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = explosion;

    }

    public void PlayExplosionSound()
    {
        audioSource.clip = explosion;
        audioSource.Play();
    }
    public void PlayPickupSound()
    {
        audioSource.clip = powerUpPickup;
        audioSource.Play();
    }

}

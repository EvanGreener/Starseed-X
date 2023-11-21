using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public float lightIntensitySpeed = 1f;
    Light light;

    float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float minutes = time / 60f;
        light.intensity = lightIntensitySpeed * minutes;
        time += Time.deltaTime;

    }
}

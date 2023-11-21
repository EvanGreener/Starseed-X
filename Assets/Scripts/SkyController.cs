using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyController : MonoBehaviour
{
    public float scaleSpeed = 1;

    float time = 0f;
    Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
    }
    void Update()
    {
        time += Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float minutes = time / 60f;
        transform.localScale = new Vector3(
            initialScale.x + (scaleSpeed * minutes),
            initialScale.y + (scaleSpeed * minutes),
            1f);
    }
}

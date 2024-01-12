using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    public LineRenderer line;
    public int collisionLayer = 7;
    public float length = 100.0f;

    bool lineOfSight = false;
    float enemyDistance;
    void Start()
    {
        line.positionCount = 2;
        line.enabled = false;

    }
    void Update()
    {
        if (lineOfSight)
        {
            line.enabled = true;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position + new Vector3(0, 0, enemyDistance));
        }
        else
        {
            line.enabled = false;
        }

    }

    void FixedUpdate()
    {
        int layerMask = 1 << collisionLayer;

        RaycastHit hit;
        lineOfSight = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask);
        if (lineOfSight) enemyDistance = hit.distance;
    }
}

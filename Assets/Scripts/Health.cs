using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    [ReadOnly]
    public float currentHealth;

    public static float damageFromBullet = 5.0f;

    public Color color;
    float h, s, v;

    Material mat;

    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        mat.SetColor("_Color", color);
        Color.RGBToHSV(color, out h, out s, out v);
        currentHealth = maxHealth;
    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject obj = collider.gameObject;
        currentHealth -= obj.tag.CompareTo("Bullet") == 0 ? damageFromBullet : 0;

        if (currentHealth > 0)
        {
            float newSaturation = s * (currentHealth / maxHealth);
            mat.SetColor("_Color", Color.HSVToRGB(h, newSaturation, v));
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

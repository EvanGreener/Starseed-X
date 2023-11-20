using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public int scoreWhenDestroyed = 10;
    // public Color color;
    public static float damageFromBullet = 5.0f;

    float h, s, v;
    GameManager gameManager;
    // Material mat;
    SFXManager sFXManager;


    void Start()
    {
        // mat = GetComponent<MeshRenderer>().material;
        // mat.SetColor("_Color", color);
        // Color.RGBToHSV(mat.color, out h, out s, out v);
        currentHealth = maxHealth;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        sFXManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
    }

    void OnTriggerEnter(Collider collider)
    {

        GameObject obj = collider.gameObject;
        currentHealth -= obj.tag.CompareTo("Bullet") == 0 ? damageFromBullet : 0;

        if (currentHealth > 0)
        {
            float newSaturation = s * (currentHealth / maxHealth);
            // mat.SetColor("_Color", Color.HSVToRGB(h, newSaturation, v));
        }
        else
        {
            sFXManager.PlayExplosionSound();
            if (gameObject.name.Contains("SuperEnemy"))
            {
                gameManager.GiveRandomUpgrade();
            }
            gameManager.UpdateScore(scoreWhenDestroyed);
            Destroy(gameObject);
        }
    }
}

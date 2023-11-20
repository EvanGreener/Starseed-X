using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject rock;
    public GameObject randomEnemy;
    public GameObject fastEnemy;
    public GameObject superEnemy;
    public GameObject shooterEnemy;
    public float rockFreq = 5.0f;
    public float randomEnemyFreq = 2.0f;
    public float fastEnemyFreq = 1.0f;
    public float superEnemyFreq = 0.25f;
    public float shooterEnemyFreq = 2.0f;
    public float spawnFreqFactor = 2;
    public GameObject[] powerUps;
    public float powerUpSpawnFreq = 0.1f / 3;
    public GameObject spawnPoints;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public Image[] upgradeImages;
    public float score = 0.0f;
    public float time = 0f;
    public GunController gunController;

    float rockElapsed = 0f;
    float randomElapsed = 0f;
    float fastElapsed = 0f;
    float superElapsed = 0f;
    float shooterElapsed = 0f;
    float powerUpElapsed = 0f;
    bool _45secPassed = false;
    bool _2min45secPassed = false;
    bool _4min45secPassed = false;
    bool[] upgradesGiven;
    float scoreMultiplier = 1f;
    int numUpgrades = 0;

    void Start()
    {
        spawnFreqFactor = (float)GameData.InitialDifficulty;

        upgradesGiven = new bool[upgradeImages.Length];
        for (int i = 0; i < upgradesGiven.Length; i++)
        {
            upgradesGiven[i] = false;
        }
    }

    void Update()
    {

        SpawnEnemy(rock, ref rockElapsed, rockFreq);
        SpawnEnemy(randomEnemy, ref randomElapsed, randomEnemyFreq);
        SpawnEnemy(fastEnemy, ref fastElapsed, fastEnemyFreq);
        SpawnEnemy(superEnemy, ref superElapsed, superEnemyFreq);
        SpawnEnemy(shooterEnemy, ref shooterElapsed, shooterEnemyFreq);

        rockElapsed += Time.deltaTime / spawnFreqFactor;
        randomElapsed += Time.deltaTime / spawnFreqFactor;
        fastElapsed += Time.deltaTime / spawnFreqFactor;
        superElapsed += Time.deltaTime / spawnFreqFactor;
        shooterElapsed += Time.deltaTime / spawnFreqFactor;

        SpawnRandomPowerUp();
        powerUpElapsed += Time.deltaTime;

        time += Time.deltaTime;
        timeText.text = string.Format("{0:.##}", time) + "s";

        if (time >= 285 && !_4min45secPassed)
        {
            spawnFreqFactor /= 2;
            _4min45secPassed = true;
        }
        else if (time >= 165 && !_2min45secPassed)
        {
            spawnFreqFactor /= 1.5f;
            _2min45secPassed = true;
        }
        else if (time >= 45 && !_45secPassed)
        {
            spawnFreqFactor /= 1.33333f;
            _45secPassed = true;
        }

    }

    void SpawnRandomPowerUp()
    {
        if (powerUpElapsed > 1f / powerUpSpawnFreq)
        {
            Transform spawn = spawnPoints.transform.GetChild(Random.Range(0, spawnPoints.transform.childCount));
            Instantiate(powerUps[Random.Range(0, powerUps.Length)], spawn.position, spawn.rotation);
            powerUpElapsed = 0;
        }
    }

    void SpawnEnemy(GameObject enemy, ref float elapsed, float spawnFrequency)
    {
        if (elapsed > 1f / spawnFrequency)
        {
            Transform spawn = spawnPoints.transform.GetChild(Random.Range(0, spawnPoints.transform.childCount));
            Instantiate(enemy, spawn.position, enemy.transform.rotation);
            elapsed = 0;
        }
    }

    public void UpdateScore(int value)
    {
        score += value * scoreMultiplier;
        scoreText.text = score + "pts";
    }

    public void GiveRandomUpgrade()
    {
        if (numUpgrades == upgradesGiven.Length)
        {
            return;
        }

        // Randomly select an upgrade that hasn't been given yet
        int index = Random.Range(0, upgradesGiven.Length);
        while (upgradesGiven[index])
        {
            index = Random.Range(0, upgradesGiven.Length);
        }

        string upgrade = upgradeImages[index].gameObject.name;
        if (upgrade.CompareTo("Fire rate") == 0)
        {
            gunController.fireRate *= 2;
        }
        else if (upgrade.CompareTo("Score multiplier") == 0)
        {
            scoreMultiplier = 1.5f;
        }
        else if (upgrade.CompareTo("Max Overheat") == 0)
        {
            float newOverheatMax = gunController.maxOverheat + 50;
            gunController.overHeatBar.SetMaxOverheat(newOverheatMax);
        }

        upgradeImages[index].enabled = true;
        upgradesGiven[index] = true;
        numUpgrades++;

    }
}

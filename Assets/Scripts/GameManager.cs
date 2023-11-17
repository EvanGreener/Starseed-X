using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    public GameObject enemySpawnPoints;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    float score = 0.0f;
    float rockElapsed = 0f;
    float randomElapsed = 0f;
    float fastElapsed = 0f;
    float superElapsed = 0f;
    float shooterElapsed = 0f;
    float time = 0f;

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

        time += Time.deltaTime;
        timeText.text = time + "s";

    }

    void SpawnEnemy(GameObject enemy, ref float elapsed, float spawnFrequency)
    {
        if (elapsed > 1f / spawnFrequency)
        {
            Transform spawn = enemySpawnPoints.transform.GetChild(Random.Range(0, enemySpawnPoints.transform.childCount));
            Instantiate(enemy, spawn.position, spawn.rotation);
            elapsed = 0;
        }
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score + "pts";
    }
}

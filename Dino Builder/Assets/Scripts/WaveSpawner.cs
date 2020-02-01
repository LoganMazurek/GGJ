using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class WaveSpec
    {
        public int enemyType;
        public int numEnemies;
    };
    public Transform enemyPrefab;
    //add more enemyPrefabs here to give choice of enemy type
    public Transform spawnPoint;
    public WaveSpec[] waves;

    public float timeBetweenWaves = 6f;
    public float timeBetweenEnemies = 0.3f;

    public Text waveCountdownText;

    private float countdown = 2f;

    private int waveIndex = 0;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;

        }
        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waves.Length; i++)
        {
            for (int j = 0; j < waves[i].numEnemies; j++)
            {
                SpawnEnemy(enemyPrefab);
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
        }
    }

    void SpawnEnemy(Transform enemyType)
    {
        Instantiate(enemyType, spawnPoint.position, spawnPoint.rotation);
    }
}
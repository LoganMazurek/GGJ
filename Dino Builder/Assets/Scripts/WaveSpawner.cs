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
        public int spawnPoint;
    };
    public Transform enemyPrefabPtero; //0
    public Transform enemyPrefabTRex;  //1
    public Transform enemyPrefabSkel;  //2
    public Transform enemyPrefabTri;   //3
    public Transform enemyPrefabVel;   //4
    private Transform[] enemies;
    //can add more enemyPrefabs here to give choice of enemy type
    public Transform spawnPoint1; //0
    public Transform spawnPoint2; //1
    //can add more spawnpoints here
    public WaveSpec[] waves;
    private Transform[] spawns;

    public float timeBetweenWaves = 6f;
    public float timeBetweenEnemies = 0.3f;
    

    private float countdown = 2f;

    private int waveIndex = 0;
    private void Start()
    {
        enemies = new Transform[5];
        enemies[0] = enemyPrefabPtero;
        enemies[1] = enemyPrefabTRex;
        enemies[2] = enemyPrefabSkel;
        enemies[3] = enemyPrefabTri;
        enemies[4] = enemyPrefabVel;
        spawns = new Transform[2];
        spawns[0] = spawnPoint1;
        spawns[1] = spawnPoint2;
    }
    private void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waves.Length; i++)
        {
            for (int j = 0; j < waves[i].numEnemies; j++)
            {
                SpawnEnemy(enemies[waves[i].enemyType], spawns[waves[i].spawnPoint]);
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
        }
       //Debug.Log("Wave Inbound!");
        
    }

    void SpawnEnemy(Transform enemyType, Transform spawn)
    {
        Instantiate(enemyType, spawn.position,spawn.rotation);
    }
}

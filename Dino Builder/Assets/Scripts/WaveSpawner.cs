using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class WaveSpec
    {
        public int enemyType;
        public int numEnemies;
        public int spawnPoint;
    };
    public static WaveSpawner instance;
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
    public bool ButtonPressed = false;

    public float timeBetweenWaves = 6f;
    public float timeBetweenEnemies = 0.3f;
    private bool spawning = false;
    public string sceneName;
    public int waveIndex = 0;
    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        enemies = new Transform[5];
        enemies[0] = enemyPrefabPtero;
        enemies[1] = enemyPrefabTRex;
        enemies[2] = enemyPrefabSkel;
        enemies[3] = enemyPrefabTri;
        enemies[4] = enemyPrefabVel;
        spawns = new Transform[2];
        spawns[0] = spawnPoint1;
        spawns[1] = spawnPoint2;
        instance = this;
    }
    private void Update()
    {
        if(waveIndex >Player.instance.maxRound && sceneName == "MilesLevel")
        {
            SceneManager.LoadScene(2);
        }
        if(waveIndex > Player.instance.maxRound && sceneName == "NickLevel")
        {
            SceneManager.LoadScene(3);
        }
        if(ButtonPressed && !spawning)
        {
            StartCoroutine(SpawnWave(waveIndex));
            ButtonPressed = false;
        }
    }

    IEnumerator SpawnWave(int index)
    {
        waveIndex++;
        
            for (int j = 0; j < waves[index].numEnemies; j++)
            {
                spawning = true;
                if (spawning)
                {
                    SpawnEnemy(enemies[waves[index].enemyType], spawns[waves[index].spawnPoint]);
                    yield return new WaitForSeconds(timeBetweenEnemies);
                }
            }
        
        spawning = false;
       //Debug.Log("Wave Inbound!");
    }

    void SpawnEnemy(Transform enemyType, Transform spawn)
    {
        Instantiate(enemyType, spawn.position,spawn.rotation);
    }
}

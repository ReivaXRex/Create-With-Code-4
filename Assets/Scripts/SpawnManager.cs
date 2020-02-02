using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    public int enemyCount;
    public int waveNumber = 1;


    private float spawnrange = 9.0f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWaves(waveNumber);
        Instantiate(powerUpPrefab, GenerateRandomSpawnPosition(), powerUpPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWaves(waveNumber);
            Instantiate(powerUpPrefab, GenerateRandomSpawnPosition(), powerUpPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateRandomSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnrange, spawnrange);
        float spawnPosZ = Random.Range(-spawnrange, spawnrange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void SpawnEnemyWaves(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }


}

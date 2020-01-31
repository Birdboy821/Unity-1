using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    private float spawnRange = 9;

    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(3);
        
    }
        private Vector3 GenerateSpawnPosition() 
    { 
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
    
    
    // Update is called once per frame
    void Update()
    {
       if (transform.position.y < -10)
       {
           Destroy(gameObject);

       }
       enemyCount = FindObjectOfType<Enemy>().Length;
       if (enemyCount == 0)
       {
           SpawnEnemyWave(1);
       }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int index = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[index], GenerateSpawnPosition(), enemyPrefab[index].transform.rotation);
        }
    }
}

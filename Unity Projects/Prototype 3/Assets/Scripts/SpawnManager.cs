using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[ ] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25,0,0);
    private PlayerController playerControllerScript;
    private float startDelay = 2;
    private float repeatRate;
    // Start is called before the first frame update
    void Start()
    {
        repeatRate = Random.Range(2, 4);
        playerControllerScript = GameObject.Find("dino").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle ()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
        if (playerControllerScript.gameOver == false)
        {
        Instantiate(obstaclePrefab[obstacleIndex], spawnPos, obstaclePrefab[obstacleIndex].transform.rotation);
        }
    }

}

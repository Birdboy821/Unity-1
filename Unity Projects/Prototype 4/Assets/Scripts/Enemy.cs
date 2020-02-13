using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player; 
    private GameObject enemy;
    public float speed;

    

    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        // enemy = GameObject.FindGameObjectsWithTag("Enemy");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = player.transform.position;

        int randtarget = Random.Range(0,1);

        Debug.Log(randtarget);
        
        if (randtarget == 0)
        {
            target = player.transform.position;
        }/* else if (randtarget == 1)
        {
            target = enemy.transform.position;
        } */

        Vector3 lookDirection = (target - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}

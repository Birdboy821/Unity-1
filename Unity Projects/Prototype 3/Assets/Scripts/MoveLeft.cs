using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private float speed = 30;
    private float leftBound = -15;
    private float lowerBound = -5;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("dino").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
             transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        }
        if(transform.position.x < leftBound || transform.position.y < lowerBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}

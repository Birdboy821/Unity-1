﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    [SerializeField] Vector3 offset = new Vector3(0, 8, -7);

    // -0.3 8.8 -7.6



    // Start is called before the first frame update
   


    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;    
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Main(Clone)");
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }

    public void setPlayer(GameObject player)
    {
        this.player = player;
    }
}

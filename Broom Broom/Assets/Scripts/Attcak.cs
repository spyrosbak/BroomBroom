using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Attcak : MonoBehaviour
{   
    private PlayerController playerController;
    private GameManager gameManager;
    private SpawnManager spawnManager;

    public float speed;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.gameOver == false)
        {
            if (!gameManager.gamePaused)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
            } 
        }
        else
        {
            Destroy(gameObject);
        }

        if(transform.position.x < -5 && gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            spawnManager.obstacles.Remove(gameObject);
        }
    }
}

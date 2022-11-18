using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    private PlayerController playerController;
    private GameManager gameManager;

    public float repeatSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.position;
        repeatWidth = gameObject.GetComponent<BoxCollider>().size.x / 2;

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.gameOver == false && gameManager.gameStart && !gameManager.gamePaused)
        {
            transform.Translate(Vector3.left * Time.deltaTime * repeatSpeed, Space.World);
        }

        if (gameObject.transform.position.x < startPos.x - repeatWidth)
        {
            gameObject.transform.position = startPos;
        }
    }
}
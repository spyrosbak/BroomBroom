using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    private Vector3[] spawnPositions = { new Vector3(15, 8, -1), new Vector3(15, 5, -1), new Vector3(15, 2, -1)};
    private float startDelay = 1.0f;
    private float repeatRate = 1.0f; 
    private float speed = 5f;

    private PlayerController playerController;
    private GameManager gameManager;
    private RepeatBackground repeatBackgroundScript;

    [NonSerialized] public List<GameObject> obstacles = new List<GameObject>();
    [NonSerialized] public int enemiesCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", startDelay, repeatRate);

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        repeatBackgroundScript = GameObject.FindGameObjectWithTag("Background").GetComponent<RepeatBackground>();
    }

    private void SpawnEnemies()
    {
        if(playerController.gameOver == false && gameManager.gameStart && !gameManager.gamePaused)
        {
            GameObject spawnedEnemy = Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Length)], spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Length)], Quaternion.Euler(0, -90, 0));
            spawnedEnemy.GetComponent<Attcak>().speed = speed;
            obstacles.Add(spawnedEnemy);
            enemiesCount++;
            
            //Finding all pumpkin game objects in the scene
            var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Pumpkin(Clone)");
            foreach (GameObject pumpkin in objects)
            {
                pumpkin.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if(enemiesCount % 25 == 0)
            {
                IncreaseMovement();
            }
        }
    }

    private void IncreaseMovement()
    {
        //Increase background Speed
        repeatBackgroundScript.repeatSpeed += 0.5f;

        //Increase enemy speed
        foreach (GameObject obstacle in obstacles)
        {
            speed += 0.5f;
            obstacle.GetComponent<Attcak>().speed = speed;
        }

        //Increase score adding rate
        gameManager.addFactor += 0.01f;
    }
}

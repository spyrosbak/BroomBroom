using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    private Vector3[] spawnPositions = { new Vector3(15, 8, -1), new Vector3(15, 5, -1), new Vector3(15, 2, -1)};
    private float startDelay = 1.0f;
    private float repeatRate = 1.0f;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", startDelay, repeatRate);
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void SpawnEnemies()
    {
        if(playerController.gameOver == false)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPositions[Random.Range(0, spawnPositions.Length)], Quaternion.Euler(0, -90, 0));
            
            //Finding all pumpkin game objects in the scene
            var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Pumpkin(Clone)");
            foreach (GameObject pumpkin in objects)
            {
                pumpkin.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}

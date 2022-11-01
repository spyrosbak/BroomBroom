using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    private Vector3[] spawnPositions = { new Vector3(15, 8, -1), new Vector3(15, 5, -1), new Vector3(15, 2, -1)};
    private float startDelay = 1.0f;
    private float repeatRate = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", startDelay, repeatRate);
    }

    private void SpawnEnemies()
    {
        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPositions[Random.Range(0, spawnPositions.Length)], Quaternion.Euler(0, -90, 0));
    }
}

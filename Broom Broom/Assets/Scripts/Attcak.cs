using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attcak : MonoBehaviour
{
    [SerializeField] private float speed;
    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        }
        else
        {
            Destroy(gameObject);
        }

        if(transform.position.x < -5 && gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    private float repeatSpeed = 3.0f;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.position;
        repeatWidth = gameObject.GetComponent<BoxCollider>().size.x / 2;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * repeatSpeed, Space.World);
        }

        if (gameObject.transform.position.x < startPos.x - repeatWidth)
        {
            gameObject.transform.position = startPos;
        }
    }
}
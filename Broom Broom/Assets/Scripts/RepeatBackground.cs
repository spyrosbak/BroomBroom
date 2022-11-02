using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    private float repeatSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.position;
        repeatWidth = gameObject.GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * repeatSpeed, Space.World);

        if (gameObject.transform.position.x < startPos.x - repeatWidth)
        {
            gameObject.transform.position = startPos;
        }   
    }
}
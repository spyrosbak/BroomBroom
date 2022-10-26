using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float movementSpeed = 5.0f;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = this.GetComponent<Transform>().position;

        this.transform.Rotate(transform.rotation.x + 15.0f, transform.rotation.y, transform.rotation.z, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.position.y < 9.0f)
            {
                transform.Translate(Vector3.up * movementSpeed * Time.deltaTime, Space.World);
            }
            else
            {
                position = new Vector3(transform.position.x, 9.0f, transform.position.z);
            }
            
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.position.y > 1.0f)
            {
                transform.Translate(Vector3.down * movementSpeed * Time.deltaTime, Space.World);
            }
            else
            {
                position = new Vector3(transform.position.x, 1.0f, transform.position.z);
            }
        }
    }
}
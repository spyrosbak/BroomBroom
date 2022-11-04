using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float movementSpeed = 5.0f;
    private Vector3 position;
    private Quaternion initRot;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        position = this.GetComponent<Transform>().position;

        this.transform.Rotate(transform.rotation.x + 15.0f, transform.rotation.y, transform.rotation.z, Space.Self);
        initRot = this.gameObject.GetComponent<Transform>().rotation;
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

            if (transform.rotation.x > 0)
            {
                transform.Rotate(-15, 0, 0);
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

            if (transform.rotation.x < 30)
            {
                this.transform.rotation = Quaternion.Euler(30, 90, 0);
            }
        }
        else
        {
            this.transform.rotation = initRot;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
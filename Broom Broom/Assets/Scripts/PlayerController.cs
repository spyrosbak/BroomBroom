using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] ParticleSystem deathVFX;
    [SerializeField] ParticleSystem vanishVFX;

    public bool gameOver = false;

    private GameManager gameManager;
    private float movementSpeed = 5.0f;
    private Vector3 position;
    private Quaternion initRot;
    private Rigidbody broomRB;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        position = this.GetComponent<Transform>().position;
        initRot = this.gameObject.GetComponent<Transform>().rotation;
        broomRB = this.gameObject.GetComponent<Rigidbody>();

        this.transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (Input.GetKey(KeyCode.UpArrow) && !gameOver)
        {
            if (transform.position.y < 9.0f)
            {
                transform.Translate(Vector3.up * movementSpeed * Time.deltaTime, Space.World);
            }
            else
            {
                position = new Vector3(transform.position.x, 9.0f, transform.position.z);
            }

            if (transform.rotation.x > -15)
            {
                //transform.Rotate(-15, 0, 0);
                //this.transform.rotation = Quaternion.Euler(-15, 90, 0);
                this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-15, 90, 0), 0.5f);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) && !gameOver)
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
                //this.transform.rotation = Quaternion.Euler(30, 90, 0);
                this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(30, 90, 0), 0.5f);
            }
        }
        else
        {
            this.transform.rotation = initRot;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameOver = true;
            Debug.Log("Game Over!");

            broomRB.AddForce(Vector3.left * 20.0f, ForceMode.Impulse);
            deathVFX.gameObject.transform.parent = null;
            deathVFX.Play();
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
        else if (other.gameObject.CompareTag("Ground") && gameOver)
        {
            vanishVFX.Play();
            vanishVFX.gameObject.transform.parent = null;
            Destroy(gameObject, 0.1f);

            GameObject.Find("GameManager").GetComponent<GameManager>().gameOverPanel.SetActive(true);
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOverPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Your final score is " + gameManager.finalScore.ToString();
        }
    }
}
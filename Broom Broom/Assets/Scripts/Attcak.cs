using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attcak : MonoBehaviour
{
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed,  Space.World);
    }
}

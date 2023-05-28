using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 rotation = Vector2.zero;
    public Rigidbody playerRb;
    public float lookSpeed = 3;
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x -= Input.GetAxis("Mouse Y");

        transform.eulerAngles = rotation * lookSpeed;

        if (Input.GetKey(KeyCode.W))
        {
        }
        if (Input.GetKey(KeyCode.S))
        {
        }
        if (Input.GetKey(KeyCode.A))
        {
        }
        if (Input.GetKey(KeyCode.D))
        {
        }
    }
}

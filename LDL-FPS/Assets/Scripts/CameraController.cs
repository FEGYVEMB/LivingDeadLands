using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector2 rotation = Vector2.zero;
    public float speed = 3;

    // Update is called once per frame
    void Update()
    {
        rotation.y += Input.GetAxis("Horizontal");
        rotation.x -= Input.GetAxis("Vertical");

        transform.eulerAngles = rotation * speed;
    }
}

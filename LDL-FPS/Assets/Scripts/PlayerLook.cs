using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private float xRotation = 0f;

    public Camera cam;
    public GameObject gun;
    public float xSensitivity = 30;
    public float ySensitivity = 30;

    public void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        // calculate camera rotation for looking up and down
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // apply rotation value to camera transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        gun.transform.localRotation = Quaternion.Euler(xRotation * 1.5f, 0, 0);
        

        // rotate player for looking left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}

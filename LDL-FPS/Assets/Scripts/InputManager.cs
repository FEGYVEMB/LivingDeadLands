using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerController controller;
    private PlayerLook look;
    private GunController gun;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        controller = GetComponent<PlayerController>();
        look = GetComponent<PlayerLook>();
        gun = GameObject.Find("Gun").GetComponent<GunController>();

        // add callback context to jump and shooting where the respective methods are called
        onFoot.Jump.performed += ctx => controller.Jump();
        onFoot.Shoot.performed += ctx => gun.Shoot();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // tell playercontroller to move using the value from movement action
        controller.ProcessMove(onFoot.Movement.ReadValue<Vector2>());

    }
    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}

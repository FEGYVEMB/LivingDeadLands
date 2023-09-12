using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class InputManager : MonoBehaviour
{
    // general
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    // look and movement
    private PlayerController controller;
    private PlayerLook look;

    // shooting
    private GunController gun;
    private FireModeController fireController;

    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        controller = GetComponent<PlayerController>();
        look = GetComponent<PlayerLook>();
        gun = GameObject.Find("Gun").GetComponent<GunController>();

        // jump and shoot inputs receive context for the respective method calls 
        onFoot.Jump.performed += ctx => controller.Jump();
        onFoot.Shoot.performed += ctx => gun.Shoot();
        onFoot.Shoot.started += ctx => 
            {
                fireController.enabled = true;
                fireController.RapidFire();
            };

        onFoot.Shoot.canceled -= ctx => 
            {
                fireController.RapidFire();
                fireController.enabled = false;
            };

    }

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;

    private PlayerStats stats;
    private PlayerUI hud;

    public float lookSpeed = 3;
    public float speed = 10f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    // Start is called before the first frame update
    void Start()
    {
        // initialize components 
        stats = GetComponent<PlayerStats>();
        hud = GetComponent<PlayerUI>();
        controller = GetComponent<CharacterController>();
    }

    // check if player is on the ground constantly
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    // receive inputs for input manager class and apply to character controller
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;

        // make sure that the applied gravity does not apply infinitely 
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    // apply damage dealt to Player, kill player if health reaches zero
    public void DecreaseHealth(float amount)
    {

        // take damage equal to amount, update HUD
        Debug.Log($"player was hit with damage: {amount}");
        stats.currentHealth -= amount;
        hud.SetData();

        if (stats.currentHealth <= 0f)
        {
            Destroy(gameObject);
            Debug.Log("YOU DIED!");
        }
    }
}

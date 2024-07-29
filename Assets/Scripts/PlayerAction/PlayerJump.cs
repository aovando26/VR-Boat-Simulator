using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// requires player input
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private InputActionProperty jumpButton;
    [SerializeField] private float jumpHeight = 3.0f;
    [SerializeField] private CharacterController cc;
    [SerializeField] private LayerMask groundLayers;


    private float gravityMultiplier = -2.5f;
    private float gravity = Physics.gravity.y;
    private Vector3 movement;

    private void Update()
    {
        bool isGrounded = IsGrounded();

        if (jumpButton.action.WasPressedThisFrame() && isGrounded)
        {
            Jump();
        }

        movement.y += gravity * Time.deltaTime;
        cc.Move(movement * Time.deltaTime);
    }

    private void Jump()
    {
        movement.y = Mathf.Sqrt(jumpHeight * gravityMultiplier * gravity);
    }

    private bool IsGrounded()
    {
        // acting raycast
        return Physics.CheckSphere(transform.position, 0.2f, groundLayers);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private CharacterController controller;
    private Quaternion targetRotation;
    private Animator animator;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        targetRotation = transform.rotation;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Get input from the WASD keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection.y = 0f; // Set y to 0 to keep movement on the horizontal plane
        moveDirection.Normalize();

        // Rotate the character to face the movement direction
        if (moveDirection.magnitude >= 0.1f)
        {
            targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        }

        // Smoothly interpolate the character's rotation towards the target rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f);

        // Apply movement to the character controller
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Set walking animation parameter based on movement input
        bool isWalking = moveDirection.magnitude > 0f;
        animator.SetBool("IsWalking", isWalking);
    }
}

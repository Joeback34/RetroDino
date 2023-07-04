using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public Vector3 offset; // Offset from the player
    public float rotationSpeed = 5f; // Speed of camera rotation

    private float currentRotationX = 0f; // Current rotation around the player on the X-axis
    private float currentRotationY = 0f; // Current rotation around the player on the Y-axis

    void LateUpdate()
    {
        if (target != null)
        {
            // Get the mouse movement axes
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Update the rotation around the player based on mouse movement
            currentRotationX += mouseX * rotationSpeed;
            currentRotationY -= mouseY * rotationSpeed;
            currentRotationY = Mathf.Clamp(currentRotationY, -90f, 90f); // Clamp vertical rotation between -90 and 90 degrees

            // Calculate the desired rotation
            Quaternion rotation = Quaternion.Euler(currentRotationY, currentRotationX, 0f);

            // Calculate the desired position based on the player's position and rotation
            Vector3 desiredPosition = target.position - rotation * offset;

            // Smoothly move the camera towards the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);

            // Apply the rotation to the camera
            transform.rotation = rotation;
        }
    }
}
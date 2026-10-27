using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Rigidbody of the player.
    private Rigidbody rb;

    // Movement along X axes.
    private float movementX;

    // Speed at which the player moves.
    public float speed = 10;

    // Controls the direction of the player

    private string direction = "Front";

    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();
        Vector3 movement = new Vector3(-movementX, 0.0f, 0);
    }

    // This function is called when a move input is detected.
    void OnMove(InputValue movementValue)
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the X component of the movement.
        movementX = movementVector.x;
    }

    // FixedUpdate is called once per fixed frame-rate frame.
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(-movementX, 0.0f, 0);
        // Create a 3D movement vector using the X and Y inputs.
        if (direction == "Front")
        {
            movement = new Vector3(-movementX, 0.0f, 0);
        }
        if (direction == "Right")
        {
            movement = new Vector3(0, 0.0f, -movementX);
        }
        if (direction == "Left")
        {
            movement = new Vector3(0, 0.0f, movementX);
        }
        if (direction == "Back")
        {
            movement = new Vector3(movementX, 0.0f, 0);
        }
        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Front-Right Rotate"))
        {
            if (direction == "Front")
            {
                direction = "Right";
                transform.Rotate(0, 0, 90);
            }
            else
            {
                direction = "Front";
                transform.Rotate(0, 0, -90);
            }

        }
        if (other.gameObject.CompareTag("Front-Left Rotate"))
        {
            if (direction == "Front")
            {
                direction = "Left";
                transform.Rotate(0, 0, -90);
            }
            else
            {
                direction = "Front";
                transform.Rotate(0, 0, 90);
            }
        }
    }
}
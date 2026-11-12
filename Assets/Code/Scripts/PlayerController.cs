using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

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

    // This controls the players rotation and triggers when it hits a corner trigger
    private void OnTriggerEnter(Collider other)
    {
        // if the player touches the left corner trigger.
        if (other.gameObject.CompareTag("Corner Left"))
        {
            // rotates the player left.
            transform.Rotate(0, 0, 90);
            rb.linearVelocity = Vector3.zero;
            if (direction == "Front")
            {
                Vector3 myvector = new Vector3(-12, 1, 8);
                transform.position = myvector;
                direction = "Right";
            }
            else if (direction == "Right")
            {
                Vector3 myvector = new Vector3(-8, 1, -12);
                transform.position = myvector;
                direction = "Back";
            }
            else if (direction == "Back")
            {
                Vector3 myvector = new Vector3(12, 1, -8);
                transform.position = myvector;
                direction = "Left";
            }
            else if (direction == "Left")
            {
                Vector3 myvector = new Vector3(8, 1, 12);
                transform.position = myvector;
                direction = "Front";
            }
        }
        // if the player touches the left corner trigger.
        if (other.gameObject.CompareTag("Corner Right"))
        {
            // rotates the player left.
            transform.Rotate(0, 0, -90);
            rb.linearVelocity = Vector3.zero;
            if (direction == "Front")
            {
                Vector3 myvector = new Vector3(12, 1, 8);
                transform.position = myvector;
                direction = "Left";
            }
            else if (direction == "Left")
            {
                Vector3 myvector = new Vector3(8, 1, -12);
                transform.position = myvector;
                direction = "Back";
            }
            else if (direction == "Back")
            {
                Vector3 myvector = new Vector3(-12, 1, -8);
                transform.position = myvector;
                direction = "Right";
            }
            else if (direction == "Right")
            {
                Vector3 myvector = new Vector3(-8, 1, 12);
                transform.position = myvector;
                direction = "Front";
            }
        if (other.gameObject.CompareTag("ladder"))
            {
             Vector3 myvector = new Vector3(7, 5, 10);
             transform.position = myvector;
             direction = "Right";
            }
            

        }
    }
}
        
        
               
            

  
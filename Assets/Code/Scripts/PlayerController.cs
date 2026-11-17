using Microsoft.Extensions.Logging.Abstractions;
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

    // creates an object using a public script.
    public ladder ladder_obj;

    // Is used in vectors to say which direction the player is moving.
    private float movement_direction;

    // Speed at which the player moves.
    public float speed = 5;

    // Controls the direction of the player
    private string direction = "Front";

    // defines the starting floor for BOB
    private int y_floor = 1;





    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();
        // get and stores the script component attached to NPCs
        ladder_obj = ladder_obj.GetComponent<ladder>();
        // is just an example/default for movement for the player.
        Vector3 movement = new Vector3(-movement_direction, 0.0f, 0);

    }

    // This function is called when a move input is detected.
    void OnMove(InputValue movementValue)
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the X component of the movement.
        movement_direction = movementVector.x;
    }

    // FixedUpdate is called once per fixed frame-rate frame.
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(-movement_direction, 0.0f, 0);
        // Create a 3D movement vector using the X and Y inputs.
        if (direction == "Front")
        {
            movement = new Vector3(-movement_direction, 0.0f, 0);
        }
        if (direction == "Right")
        {
            movement = new Vector3(0, 0.0f, -movement_direction);
        }
        if (direction == "Left")
        {
            movement = new Vector3(0, 0.0f, movement_direction);
        }
        if (direction == "Back")
        {
            movement = new Vector3(movement_direction, 0.0f, 0);
        }



        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed);
    }

    /// <summary>
    /// This controls the players rotation, direction and positon when it hits a corner trigger
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        // if the player touches the trigger on the right side of the floor.
        if (other.gameObject.CompareTag("Corner Left"))
        {
            // depending on the direction the player is currently facing it:
            // - rotates them
            // - changes their movement direction.
            // - teleports them to the positon on the perpendicular corner.
            // sets the player floor to the current y_floors level.
            transform.Rotate(0, -90, 0);
            rb.linearVelocity = Vector3.zero;
            if (direction == "Front")
            {
                Vector3 myvector = new Vector3(-12, y_floor, 8);
                transform.position = myvector;
                direction = "Right";
            }
            else if (direction == "Right")
            {
                Vector3 myvector = new Vector3(-8, y_floor, -12);
                transform.position = myvector;
                direction = "Back";
            }
            else if (direction == "Back")
            {
                Vector3 myvector = new Vector3(12, y_floor, -8);
                transform.position = myvector;
                direction = "Left";
            }
            else if (direction == "Left")
            {
                Vector3 myvector = new Vector3(8, y_floor, 12);
                transform.position = myvector;
                direction = "Front";
            }
        }
        // if the player touches the trigger on the left side of the floor.
        if (other.gameObject.CompareTag("Corner Right"))
        {
            // depending on the direction the player is currently facing it:
            // - rotates them
            // - changes their movement direction.
            // - teleports them to the positon on the perpendicular corner.
            // sets the player floor to the current y_floors level.
            transform.Rotate(0, 90, 0);
            rb.linearVelocity = Vector3.zero;
            if (direction == "Front")
            {
                Vector3 myvector = new Vector3(12, y_floor, 8);
                transform.position = myvector;
                direction = "Left";
            }
            else if (direction == "Left")
            {
                Vector3 myvector = new Vector3(8, y_floor, -12);
                transform.position = myvector;
                direction = "Back";
            }
            else if (direction == "Back")
            {
                Vector3 myvector = new Vector3(-12, y_floor, -8);
                transform.position = myvector;
                direction = "Right";
            }
            else if (direction == "Right")
            {
                Vector3 myvector = new Vector3(-8, y_floor, 12);
                transform.position = myvector;
                direction = "Front";
            }
        }
    }
    /// <summary>
    /// If the player is holding E on a ladder trigger.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerStay(Collider other)
    {
        // if the player is <holding> the E key. 
        if (Input.GetKey(KeyCode.E))
        {
            // if the player is touching the first-second floor ladder.
            rb.linearVelocity = Vector3.zero;
            if (other.gameObject.CompareTag("Ladder_up_first"))
            {
                Vector3 myvector = new Vector3(5, 7, 12);
                transform.position = myvector;
                y_floor = 7;
            }
            // if the player is touching the second-first floor ladder.
            if (other.gameObject.CompareTag("Ladder_down_first"))
            {
                Vector3 myvector = new Vector3(5, 1, 12);
                transform.position = myvector;
                y_floor = 1;
            }
            // if the player is touching the second-third floor ladder.
            if (other.gameObject.CompareTag("Ladder_up_second"))
            {
                Vector3 myvector = new Vector3(-12, 13, -3);
                transform.position = myvector;
                y_floor = 13;
            }
            // if the player is touching the third-second floor ladder.
            if (other.gameObject.CompareTag("Ladder_down_second"))
            {
                Vector3 myvector = new Vector3(-12, 7, -3);
                transform.position = myvector;
                y_floor = 7;
            }
        }
    }
}
        
        
               
            

  
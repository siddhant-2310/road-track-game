using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;  // Speed of movement
    private float moveLimitX = 7f; // Left-right boundary limits (No forward/backward limit)

    void Update()
    {
        // Get current position
        Vector3 newPosition = transform.position;

        // Move Left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition.x -= speed * Time.deltaTime;
        }

        // Move Right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition.x += speed * Time.deltaTime;
        }

        // Move Forward
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPosition.z += speed * Time.deltaTime;
        }

        // Move Backward
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition.z -= speed * Time.deltaTime;
        }

        // Clamp movement only on X-axis (left-right)
        newPosition.x = Mathf.Clamp(newPosition.x, -moveLimitX, moveLimitX);

        // Apply new position
        transform.position = newPosition;
    }
}

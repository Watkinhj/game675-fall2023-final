using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonowireMovement : PlayerController
{
    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    // click on the left mouse button over a groundLayer tile to move the grounded player towards that tile
    protected override void HandleMonowireMovement()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0) && isGrounded())
        {
            // Check if Camera.main is not null before using it
            if (Camera.main != null)
            {
                // Get the mouse position in world coordinates
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // Calculate the direction towards the clicked position
                Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;

                // Apply force to move the player in the direction of the click
                rb.AddForce(direction * jumpForce, ForceMode2D.Impulse);

                // Debug information
                Debug.Log("Mouse click detected on ground layer.");
                Debug.Log("Clicked position: " + mousePosition);
                Debug.Log("Player position: " + transform.position);
                Debug.Log("Direction: " + direction);
            }
            else
            {
                Debug.LogError("Main camera not found. Make sure you have a camera tagged as 'MainCamera' in your scene.");
            }
        }
    }
}

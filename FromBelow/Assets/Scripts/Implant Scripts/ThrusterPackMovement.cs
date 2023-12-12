using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterPackMovement : PlayerController
{
    [SerializeField] protected float doubleJumpForce = 12f;

    // Update is called once per frame
    void Update()
    {
        base.Update();

        // Check horizontal input to determine movement direction
        if (base.horizontal != 0)
        {
            // Adjust the player's direction based on the input
            FlipDirection();
        }
    }

    // this is the override that should now work
    protected override void HandleDoubleJump()
    {
        if (isGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
            //animator.SetBool("isJumping", false);
        }

        if ((Input.GetButtonDown("Jump") && isGrounded()) || (Input.GetButtonDown("Jump") && doubleJump))
        {
            if (!isGrounded()) // Check if it's a double jump
            {
                // Change the player's direction based on the current movement direction
                //FlipDirection(Input.GetAxis("Horizontal"));
            }

            Jump(doubleJumpForce);
            doubleJump = !doubleJump;
            //animator.SetBool("isJumping", true);
        }
    }

    // Function to flip the player's direction based on the input
    private void FlipDirection()
    {
        // Change the player's direction based on the isFacingRight variable
        transform.localScale = new Vector3(isFacingRight ? 1 : -1, transform.localScale.y, transform.localScale.z);
    }
}

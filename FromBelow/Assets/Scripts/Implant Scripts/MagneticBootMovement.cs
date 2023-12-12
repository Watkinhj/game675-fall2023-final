using System.Collections;
using UnityEngine;

public class MagneticBootMovement : PlayerController
{
    [SerializeField] private Transform leftWallCheck;
    [SerializeField] private Transform rightWallCheck;
    [SerializeField] private LayerMask wallLayer;

    protected override void HandleMagneticBootMovement()
    {
        bool isLeftWall = Physics2D.OverlapCircle(leftWallCheck.position, 0.2f, wallLayer);
        bool isRightWall = Physics2D.OverlapCircle(rightWallCheck.position, 0.2f, wallLayer);

        if (!isGrounded() && (isLeftWall || isRightWall))
        {
            // Wall jump logic
            HandleWallJump(isLeftWall);
        }
    }

    private void HandleWallJump(bool isLeftWall)
    {
        // Check for wall jump input
        if (Input.GetButtonDown("Jump"))
        {
            // Apply a force to jump off the wall
            float wallJumpForce = jumpForce * 0.7f; // Adjust the force as needed
            float horizontalForce = isLeftWall ? wallJumpForce : -wallJumpForce;

            rb.velocity = new Vector2(horizontalForce, jumpForce);

            // Reset double jump flag
            doubleJump = false;

            // Play jump animation
            StartCoroutine(JumpCooldown());
        }
    }
}

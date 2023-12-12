using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndustrialKnifeMovement : PlayerController
{
    // Update is called once per frame
    void Update()
    {
        base.Update();

        // Check for movement input
        float horizontalInput = Input.GetAxis("Horizontal");
        FlipSprite(horizontalInput);
    }

    protected override void HandleKnifeAttack()
    {
        if (Input.GetMouseButtonDown(1))
        {
            knifeObj.SetActive(true);
            Debug.Log("Knife attack!");
            animator.SetBool("isAttacking", true);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            knifeObj.SetActive(false);
            Debug.Log("Knife attack ended.");
            animator.SetBool("isAttacking", false);
        }
    }

    // Flip the sprite based on the input direction
    private void FlipSprite(float horizontalInput)
    {
        if (horizontalInput > 0)
        {
            // Moving right, flip the sprite to face right
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (horizontalInput < 0)
        {
            // Moving left, flip the sprite to face left
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        // If horizontalInput is 0, the player is not moving horizontally, so you may choose to keep the current scale.
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterPackMovement : PlayerController
{
    [SerializeField] protected float doubleJumpForce = 12f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // this is the override that does not work
    protected override void HandleDoubleJump()
    {
        if (isGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
            //animator.SetBool("isJumping", false);
        }

        if ((Input.GetButtonDown("Jump") && isGrounded()) || (Input.GetButtonDown("Jump") && doubleJump))
        {
            Jump(doubleJumpForce);
            doubleJump = !doubleJump;
            //animator.SetBool("isJumping", true);
        }
    }
}

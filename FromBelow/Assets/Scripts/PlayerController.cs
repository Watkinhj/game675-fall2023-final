using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] protected float speed = 8f;
    [SerializeField] protected float jumpForce = 12f;
    [SerializeField] protected int maxLength = 50;

    protected float horizontal;
    protected bool isFacingRight = true;
    protected bool doubleJump;
    protected bool isJumping;

    [Header("Components")]
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected SpriteRenderer sR;
    [SerializeField] protected Animator animator;

    [Header("Control Variables")]
    [SerializeField] protected float coyoteTime = 0.2f;
    [SerializeField] protected float jumpBufferTime = 0.2f;
    protected float coyoteTimeCounter;
    protected float jumpBufferCounter;

    [Header("Running Jump Variables")]
    [SerializeField] protected float releaseJumpDuration = 0.2f;
    protected float releaseJumpCounter;

    [Header("Ladder Variables")]
    [SerializeField] protected LayerMask ladderLayer;
    [SerializeField] protected float ladderClimbSpeed = 5f;
    protected bool isClimbing;
    protected bool isExitingLadder;

    [SerializeField] protected GameObject knifeObj;

    void Start()
    {
        knifeObj.SetActive(false);
    }

    protected void Update()
    {
        GetInput();
        CheckGrounded();
        HandleJumpInput();
        HandleDoubleJump();
        HandleReleaseJumpInput();
        UpdateAnimator();

        // Add ladder-related methods
        if (isClimbing)
        {
            HandleLadderClimbing();
        }
        else
        {
            HandleMonowireMovement();
            HandleKnifeAttack();
            HandleMagneticBootMovement();
        }
    }
    /*
    protected void Update()
    {
        GetInput();
        CheckGrounded();
        HandleJumpInput();
        HandleDoubleJump();
        HandleReleaseJumpInput();
        UpdateAnimator();
        HandleMonowireMovement();
        HandleKnifeAttack();
        HandleMagneticBootMovement();
    }
    */

    private void FixedUpdate()
    {
        MoveHorizontally();
        //AdjustGravity();
        LimitVelocity();
    }

    private void GetInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void CheckGrounded()
    {
        if (isGrounded())
        {
            //Debug.Log("Is grounded");
            animator.SetBool("inAir", false);
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            animator.SetBool("inAir", true);
            coyoteTimeCounter -= Time.deltaTime;
        }
    }

    private void HandleJumpInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
            releaseJumpCounter = 0f;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
            releaseJumpCounter += Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f && !isJumping)
        {
            Jump(jumpForce);
        }
    }

    protected void Jump(float force)
    {
        rb.velocity = new Vector2(rb.velocity.x, force);
        jumpBufferCounter = 0f;
        StartCoroutine(JumpCooldown());
    }

    protected virtual void HandleDoubleJump()
    {
        
    }

    protected virtual void HandleMonowireMovement()
    {

    }

    protected virtual void HandleKnifeAttack()
    {

    }

    protected virtual void HandleMagneticBootMovement()
    {

    }

    private void HandleReleaseJumpInput()
    {
        if (Input.GetButtonUp("Jump") && (rb.velocity.y > 0f || rb.velocity.y < 0f) && releaseJumpCounter < releaseJumpDuration)
        {
            // Reduce upward velocity when jump button is released
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void UpdateAnimator()
    {
        animator.SetBool("isRunning", Mathf.Abs(horizontal) > 0 && isGrounded());
        FlipCharacter();
    }

    private void MoveHorizontally()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    // private void AdjustGravity()
    // {
    //     rb.gravityScale = (rb.velocity.y < -0.1) ? rb.gravityScale * 1.1f : 1;
    // }

    private void LimitVelocity()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxLength);
    }

    protected bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void FlipCharacter()
    {
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            sR.flipX = !sR.flipX;
        }
    }

    protected IEnumerator JumpCooldown()
    {
        isJumping = true;
        Debug.Log("Jumping");
        animator.SetBool("isJumping", true);
        yield return new WaitForSeconds(0.4f);
        isJumping = false;
        Debug.Log("Not Jumping");
        animator.SetBool("isJumping", false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = true;
            isExitingLadder = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = false;
            StartCoroutine(ExitLadder());
        }
    }

    protected IEnumerator ExitLadder()
    {
        isExitingLadder = true;
        yield return new WaitForSeconds(0.2f); // Adjust the delay as needed
        isExitingLadder = false;
        animator.SetBool("isClimbing", false); // Assuming "isClimbing" is the climbing animation parameter
    }

    protected virtual void HandleLadderClimbing()
    {
        if (isExitingLadder)
        {
            // Do nothing while exiting the ladder
            return;
        }

        float vertical = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, vertical * ladderClimbSpeed);

        // Trigger climbing animation
        animator.SetBool("isClimbing", Mathf.Abs(vertical) > 0.1f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovementTutorial : MonoBehaviour
{
    private Animator _animator;
    public float cSpeed;
    [Header("Movement")]
    private float moveSpeed;

    public bool isGrounded;
    public float walkSpeed;
    public float sprintSpeed;
    public bool lockMovement;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;
    public Transform groundCheck;
    public  float groundDistance = 0.1f;
   
    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    public KeyCode sprintKey = KeyCode.LeftShift;
    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;
    public MovementState state;
    public enum MovementState
    {
        walking,
        sprinting,
        air,
        attack,
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
    }

    private void Update()
    {
        // ground check
       // grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.1f, whatIsGround);
       grounded = Physics.CheckSphere(groundCheck.position, groundDistance, whatIsGround);
        MyInput();
        SpeedControl();
        StateHandler();

        // handle drag
        if (grounded) 
        {
            rb.drag = groundDrag;
            isGrounded = true;
        }
        else
        {   
            rb.drag = 0;
        
            isGrounded = false;
        }
        cSpeed = rb.velocity.magnitude / sprintSpeed;
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();
            

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void StateHandler()
    {
        //sprinting
        if (grounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
            
        }
        
        else if (grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
            
        }
        else  
        {
            state = MovementState.air;
        }

        if (lockMovement)
        {
            state = MovementState.attack;
            moveSpeed = 0;
        }
    }

    private void MovePlayer()
    {
        if (OnSlope() && !exitingSlope)
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);

            if (rb.velocity.y > 0)
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
        }
        
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if(grounded){
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }

        // in air
        else if(!grounded){
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
            
        }
        
        rb.useGravity = !OnSlope();
    }

    private void SpeedControl()
    {
        // limiting speed on slope
        if (OnSlope() && !exitingSlope)
        {
            if (rb.velocity.magnitude > moveSpeed)
                rb.velocity = rb.velocity.normalized * moveSpeed;
        }

        // limiting speed on ground or in air
        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            // limit velocity if needed
            if (flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }
    }

    private void Jump()
    {
        exitingSlope = true;

        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;

        exitingSlope = false;
    }

    
    private bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonAnimation : MonoBehaviour
{
    public PlayerMovementTutorial pmv;


    Animator animator;

    private int isWalkingHash;
    private int isRunningHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = pmv.isGrounded;
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool isJumping = animator.GetBool("isJumping");
        bool walkPressed = Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d");
        bool runPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKey(KeyCode.Space);
        if (!isWalking && walkPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }
        if (isWalking && !walkPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isRunning && (walkPressed && runPressed))
        {
            animator.SetBool(isRunningHash, true);
        }
        
        if (isRunning && (!walkPressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }

        if (jumpPressed && isGrounded)
        {
            animator.SetBool("isJumping", true);
        }

        if (!jumpPressed && !isGrounded)
        {
            animator.SetBool("isJumping", false);
        }
    }
}

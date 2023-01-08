using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private Animator anim;
    public PlayerMovementTutorial pmv;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && pmv.isGrounded)
        {
            anim.SetTrigger("Attack");
        }

        if (Input.GetKeyDown(KeyCode.Q) && pmv.isGrounded)
        {
            anim.SetTrigger("Skill1");
        }
        
    }


    
}

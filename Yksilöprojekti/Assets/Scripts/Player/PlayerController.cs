using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Android.LowLevel;

public class PlayerController : MonoBehaviour
{

    PlayerControls controls;
    public Animator playerAnimator;
    
    float direction = 0;

    public Rigidbody2D playerRb;

    public float speed = 400;
    public float jumpForce = 5;
    public int numberOfJumps = 0;
    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private void Awake()
    {
        // Check wether the rigidbody is valid on awake
        if (playerRb == null)
        {
            Debug.Log("Rigidbody for player controller: "+ gameObject + " was destroyed");
        }
        else
            Debug.Log("Rigidbody for player controller: " + gameObject);

        
        if(controls == null)
            controls = new PlayerControls();
        controls.Enable();

        controls.Land.Move.performed += context =>
        {
            direction = context.ReadValue<float>();
        };

        controls.Land.Jump.performed += context => Jump();

    } 

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        Debug.Log(isGrounded);
        playerRb.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRb.velocity.y);

        playerAnimator.SetFloat("Speed", direction);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            numberOfJumps = 0;
            // Skip performed problem
            if(playerRb != null)
                playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            numberOfJumps++;
        }
        else 
        {
            if (numberOfJumps == 1)
            {
                if (playerRb != null)
                    playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
                numberOfJumps++;
            }
        }
        
    }

    void OnDisable()
    {
        Debug.Log("Disabling event");
        controls.Land.Jump.performed -= context => Jump();
    }
}

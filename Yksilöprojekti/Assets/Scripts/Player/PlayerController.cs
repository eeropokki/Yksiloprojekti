using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    PlayerControls controls;
    
    
    float direction = 0;

    public Rigidbody2D playerRb;

    public float speed = 400;
    public float jumpForce = 5;
    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private void Awake()
    {

        
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
        
    }

    private void Jump()
    {
        Debug.Log("Player Jump");
        playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CapsuleMovement : MonoBehaviour
{
    [HideInInspector] public float horizontal;		//Float that stores horizontal input
    [HideInInspector] public bool jumpHeld;			//Bool that stores jump pressed
    [HideInInspector] public bool jumpPressed;		//Bool that stores jump held
    public float jumpHeight = 20;
    public float gravity = -20f;
    [SerializeField] private LayerMask ground;
    private bool isGrounded = false;
    private float horizontalInput;
    public Transform groundCheck;
    public float moveSpeed = 2;
    public CharacterController controller;
    private Vector3 moveVelocity = Vector3.zero;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // Gravity();
        horizontal = Input.GetAxisRaw("Horizontal");
        if (IsGrounded())
        {
            moveVelocity = transform.right * moveSpeed * horizontal;
            if (true)
            {
                moveVelocity.y = jumpHeight;
            }
        }

        moveVelocity.y += gravity * Time.deltaTime;
        controller.Move(moveVelocity * Time.deltaTime);
        // if (IsGrounded())
        // {
        //     HorizontalMovement();
        //     Jump();
        // }
        // controller.Move(moveVelocity * Time.deltaTime);
    }

    void FixedUpdate()
    {
        
    }

    private void HorizontalMovement()
    {
        Vector3 direction = new Vector3(horizontal, 0f, 0f).normalized;
        if (direction.magnitude >= 0.1f)
        {
            moveVelocity += direction;
        }
    }

    private void Gravity()
    {
        Vector3 direction = new Vector3(0f, -1f, 0f).normalized;
        moveVelocity += direction * 9.8f;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Gotten Keydown");
            moveVelocity.y = jumpHeight;
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }
}

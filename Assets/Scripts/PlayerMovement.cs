using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float jumpVelocity;
    [SerializeField] float moveVelocity;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        rb.velocity = new Vector3(horizontalInput * moveVelocity, rb.velocity.y, verticalInput * moveVelocity);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Vector3 old = rb.velocity;
            rb.velocity = new Vector3(old.x, jumpVelocity, old.z);
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.5f, groundMask);
        // return false;
    }
}

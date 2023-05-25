using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void Jump()
    {
        Vector3 old = rb.velocity;
        rb.velocity = new Vector3(old.x, jumpVelocity, old.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyHead"))
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
            Jump();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Exit"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        rb.velocity = new Vector3(horizontalInput * moveVelocity, rb.velocity.y, verticalInput * moveVelocity);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.5f, groundMask);
        // return false;
    }
}

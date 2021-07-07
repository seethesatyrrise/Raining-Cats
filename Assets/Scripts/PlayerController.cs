using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    [SerializeField] float timeSinceLastMove;
    [SerializeField] float speed = 2.5f;
    [SerializeField] float jumpForce = 15;
    [SerializeField] float speedJumpModifier = 0.02f;
    //[SerializeField] float turnSpeed = 4;
    float timeToSit = 5;
    public float turnSmoothing = 0.06f;

    Animator animator;
    Rigidbody rb;
    CapsuleCollider playerCollider;
    [SerializeField] Camera cam;
    

    [SerializeField] bool isOnSomething;
    [SerializeField] bool canJump;

    Quaternion rotation;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();

        timeSinceLastMove = 0;
    }

    private void FixedUpdate()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0)
        {
            //transform.Rotate(0, horizontalInput, 0);
            //rotation = Quaternion.Euler(0, horizontalInput * turnSpeed, 0);
            //rb.MoveRotation(rb.rotation * rotation);

            Vector3 forward = cam.transform.TransformDirection(Vector3.forward);

            forward.y = 0.0f;
            forward = forward.normalized;

            Vector3 right = new Vector3(forward.z, 0, -forward.x);
            Vector3 targetDirection;
            targetDirection = forward * verticalInput + right * horizontalInput;

            // Lerp current direction to calculated target direction.
            if (targetDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

                Quaternion newRotation = Quaternion.Slerp(rb.rotation, targetRotation, turnSmoothing);
                rb.MoveRotation(newRotation);
            }

            timeSinceLastMove = 0;
        }


        if (verticalInput != 0)
        {
            if (isOnSomething)
            {
                rb.velocity = transform.TransformDirection(0, 0, verticalInput * speed);
            }
            else
            {
                rb.velocity += transform.TransformDirection(0, 0, verticalInput * speed * speedJumpModifier);
            }

            timeSinceLastMove = 0;
        }

        animator.ResetTrigger("Jump");
        animator.SetFloat("AxisZ", verticalInput);
        animator.SetFloat("AxisX", horizontalInput);

        if (canJump && Input.GetKey(KeyCode.Space))
        {
            isOnSomething = false;
            canJump = false;

            timeSinceLastMove = 0;
            animator.SetTrigger("Jump");

            RemoveVerticalVelocity();
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (timeSinceLastMove < timeToSit)
        {
            timeSinceLastMove += Time.deltaTime;
            animator.ResetTrigger("Sit");
            animator.SetTrigger("StandUp");
        } else
        {
            animator.ResetTrigger("StandUp");
            animator.SetTrigger("Sit");
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        isOnSomething = true;
        canJump = false;
        // Slide on vertical obstacles
        for (int i = 0; i < collision.contactCount; i++)
        {
            if (collision.GetContact(i).normal.y <= 0.1f)
            {
                playerCollider.material.dynamicFriction = 0f;
                playerCollider.material.staticFriction = 0f;
            }
            else canJump = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        playerCollider.material.dynamicFriction = 0.6f;
        playerCollider.material.staticFriction = 0.6f;
        isOnSomething = false;
    }

    private void RemoveVerticalVelocity()
    {
        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        rb.velocity = horizontalVelocity;
    }

}

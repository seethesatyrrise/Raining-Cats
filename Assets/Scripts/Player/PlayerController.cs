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
    float timeToSit = 5;
    public float turnSmoothing = 0.06f;
    float axisZ, axisX;

    Animator animator;
    Rigidbody rb;
    CapsuleCollider playerCollider;
    [SerializeField] Camera cam;
    

    [SerializeField] bool isOnSomething;
    [SerializeField] bool canJump;

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

        axisX = 0;
        axisZ = 0;
        rb.velocity = new Vector3(0, rb.velocity.y, 0);

        if (horizontalInput != 0 || verticalInput != 0)
        {
            timeSinceLastMove = 0;
            axisZ = 1;

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

            if (isOnSomething)
            {
                rb.velocity = transform.TransformDirection(0, 0, speed);
            }
            else
            {
                rb.velocity = transform.TransformDirection(0, rb.velocity.y, speed);
            }

            
            if (verticalInput != 0)
            {
                axisX = Vector3.SignedAngle(rb.velocity, verticalInput > 0 ? forward : -forward, Vector3.up);
            }
            axisX = Mathf.Clamp(axisX, -90f, 90f) / 90f;
        }

        animator.ResetTrigger("Jump");
        animator.SetFloat("AxisZ", axisZ, 0.1f, Time.deltaTime);
        animator.SetFloat("AxisX", axisX, 0.1f, Time.deltaTime);

        if (canJump && Input.GetKey(KeyCode.Space))
        {
            isOnSomething = false;
            canJump = false;

            timeSinceLastMove = 0;
            animator.SetTrigger("Jump");

            RemoveVerticalVelocity();
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }


        if (timeSinceLastMove < timeToSit)
        {
            timeSinceLastMove += Time.deltaTime;
            animator.ResetTrigger("Sit");
            animator.SetTrigger("StandUp");
        }
        else
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isJumped;
    bool isFacedRight;
    Animator animator;
    [SerializeField] float jumpSpeed;
    [SerializeField] float movementSpeed;

    void Start()
    {
        animator = GetComponent<Animator>();
        isFacedRight = true;
    }


    void Update()
    {
        if (Input.GetKeyDown("a") && isFacedRight && !Input.GetKey("d"))
        {
            transform.Rotate(-Vector3.up, 180);
            isFacedRight = false;
        }
        if (Input.GetKeyDown("d") && !isFacedRight && !Input.GetKey("a"))
        {
            transform.Rotate(Vector3.up, 180);
            isFacedRight = true;
        }

        if (Input.GetKey("d") || Input.GetKey("a"))
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown("space") && !isJumped)
        {
            animator.SetTrigger("isJumping");
            isJumped = true;
        }


        if (Input.GetKey("d") || Input.GetKey("a"))
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
        
     
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            if (isJumped)
            {
                animator.SetTrigger("isGrounded");
            }
            isJumped = false;
           
        }
    }
    private void FixedUpdate()
    {
        if (isJumped)
        {
            transform.Translate(Vector3.up * jumpSpeed * Time.fixedDeltaTime, Space.World);
        }
    }

}

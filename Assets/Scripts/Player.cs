using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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

        if (Input.GetKey("space"))
        {
            animator.SetTrigger("isJumping");
            transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime);
        }

        if (Input.GetKey("d") || Input.GetKey("a"))
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
        
     
    }

}

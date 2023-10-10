//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    public Rigidbody playerRB;
//    public float moveSpeed;
//    public float jumpForce;

//    private Vector2 moveInput;

//    public LayerMask terrainLayer;
//    public Transform groundPoint;
//    private bool isGrounded;

//    public Animator anim;
//    public SpriteRenderer playerSR;

//    private bool movingBackwads;

//    private void Start()
//    {
//    }
//    private void Update()
//    {
//        moveInput.x = Input.GetAxis("Horizontal");
//        moveInput.y = Input.GetAxis("Vertical");
//        moveInput.Normalize();

//        playerRB.velocity = new Vector3(moveInput.x * moveSpeed, playerRB.velocity.y, moveInput.y * moveSpeed);

//        anim.SetFloat("moveSpeed", playerRB.velocity.magnitude);

//        RaycastHit hit;
//        if(Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, terrainLayer))
//        {
//            isGrounded = true;
//        }
//        else
//        {
//            isGrounded = false;
//        }

//        if(Input.GetButtonDown("Jump") && isGrounded)
//        {
//            playerRB.velocity += new Vector3(0f, jumpForce, 0f);
//        }

//        anim.SetBool("onGround", isGrounded);

//        if(!playerSR.flipX && moveInput.x < 0)
//        {
//            playerSR.flipX = true;
//        }
//        else if(playerSR.flipX && moveInput.x > 0)
//        {
//            playerSR.flipX = false;
//        }

//        if (!movingBackwads && moveInput.y > 0)
//        {
//            movingBackwads = true;
//        }
//        else if(movingBackwads && moveInput.y < 0)
//        {
//            movingBackwads = false;
//        }

//        anim.SetBool("movingBackwards", movingBackwads);
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRB;
    public float moveSpeed;
    public float jumpForce;

    private Vector2 moveInput;

    public LayerMask terrainLayer;
    public Transform groundPoint;
    private bool isGrounded;

    public Animator anim;

    private void Update()
    {
        // Get input from user
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        // Apply movement to the rigidbody
        playerRB.velocity = new Vector3(moveInput.x * moveSpeed, playerRB.velocity.y, moveInput.y * moveSpeed);

        // Update animator parameters
        anim.SetFloat("moveSpeed", playerRB.velocity.magnitude);

        if (moveInput.x > 0)
            anim.SetInteger("Direction", 3); // Right
        else if (moveInput.x < 0)
            anim.SetInteger("Direction", 2); // Left

        if (moveInput.y > 0)
            anim.SetInteger("Direction", 1); // Backward
        else if (moveInput.y < 0)
            anim.SetInteger("Direction", 0); // Forward


        RaycastHit hit;
        if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, terrainLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRB.velocity += new Vector3(0f, jumpForce, 0f);
        }


        //anim.SetBool("onGround", isGrounded);
    }
}

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
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        playerRB.velocity = new Vector3(moveInput.x * moveSpeed, playerRB.velocity.y, moveInput.y * moveSpeed);

        anim.SetFloat("moveSpeed", playerRB.velocity.magnitude);

        if (moveInput.x > 0)
            anim.SetInteger("Direction", 3);
        else if (moveInput.x < 0)
            anim.SetInteger("Direction", 2); 

        if (moveInput.y > 0)
            anim.SetInteger("Direction", 1);
        else if (moveInput.y < 0)
            anim.SetInteger("Direction", 0);


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
    }
}

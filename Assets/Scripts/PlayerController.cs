using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float grondDist;

    public LayerMask terrainLayer;
    public Rigidbody playerRB;
    public SpriteRenderer playerSR;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if(hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + grondDist;
                transform.position = movePos;
            }
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(x, 0, y);
        playerRB.velocity = moveDir * speed;

        if(x != 0 && x < 0)
        {
            playerSR.flipX = true;
        }
        else if( x != 0 && x > 0)
        {
            playerSR.flipX = false ;
        }
    }
}

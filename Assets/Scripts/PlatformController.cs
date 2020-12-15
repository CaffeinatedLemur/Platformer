///////////////////////
///Name: Thomas Allen
///Date: 12/14/2020
///Desc. A 2d platformer controller script
//////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private float moveInput;
    private bool facingRight = true;

    private Rigidbody2D myRB;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    private int jumps;
    public int maxJumps;

    public float fallMultiplier = 2.5f;

    int groundLayer = 1;

    bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            jumps = maxJumps;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && jumps > 1)
        {
            myRB.velocity = Vector2.up * jumpForce;
            //myRB.AddForce(new Vector2(0f, jumpForce));

            --jumps;
        }

        if (myRB.velocity.y < 0 || myRB.velocity.y > 1)
        {
            myRB.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        //isTouchingFront = Physics2D.OverlapCircle

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius /*whatIsGround*/);

        moveInput = Input.GetAxisRaw("Horizontal");
        //set player velocity based on input
        myRB.velocity = new Vector2(moveInput * speed, myRB.velocity.y);
        //determine the new facing

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }

        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}

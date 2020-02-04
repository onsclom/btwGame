using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    bool isGrounded = false;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private float dir = 0;
    public float speed;
    private float extraSpeed = 0f;
    public float extraSpeedAmount;
    public float jumpVel;

    public float dashTime = 1f;
    private float curDash = 0f;
    private bool hasDash = true;
    private Vector2 dashVel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, .15f, groundLayer);
        dir = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.AddForce(new Vector2(0f, jumpVel));
            }
        }

        if (isGrounded)
        {
            hasDash = true;
        }

        //decrement extra speed
        if (extraSpeed >= 0)
        {
            extraSpeed -= Time.deltaTime * 60;
        }

        //check for dash input
        if (Input.GetButtonDown("Dash") && hasDash)
        {
            hasDash = false;
            print("DASH");
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.gravityScale = 0;
            curDash = dashTime;
            rb.velocity = rb.velocity * 4;
        }

        if (curDash >= 0f)
        {
            curDash -= Time.deltaTime;
            if (curDash < 0)
            {
                rb.gravityScale = 1;
            }
        }
    }

    private void FixedUpdate()
    {
        if (curDash <= 0) //if not dashing
            rb.velocity = new Vector2(dir * (speed + extraSpeed) * Time.deltaTime, rb.velocity.y);
        else //is dashing
        {
            

        }


    }

    public void speedup()
    {
        extraSpeed += extraSpeedAmount;
    }
}
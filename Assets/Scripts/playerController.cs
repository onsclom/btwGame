using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    bool isGrounded = false;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private float dir=0;
    public float speed;
    private float extraSpeed=0f;
    public float extraSpeedAmount;
    public float jumpVel;
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
                rb.AddForce(new Vector2 (0f, jumpVel));
            }
        }

        //decrement extra speed
        if (extraSpeed >= 0)
        {
            extraSpeed -= Time.deltaTime * 60;
        }
    }

    private void FixedUpdate() 
    {
        rb.velocity = new Vector2 (dir * (speed+extraSpeed) * Time.deltaTime, rb.velocity.y);
    }

    public void speedup()
    {
        extraSpeed += extraSpeedAmount;
    }
}

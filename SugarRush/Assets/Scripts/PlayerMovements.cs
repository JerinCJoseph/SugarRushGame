using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteR;
    private Animator playerAnim;
    private BoxCollider2D bcoll;
  
    private float axisX = 0f;
    public float playerSpeed;  
    [SerializeField] private float jumpForce; 
    private enum MovementState { idle, running, jumping, falling }
    
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpSoundEffect; //20April

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
        bcoll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        axisX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(axisX * playerSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && IsOnGround())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimatorState();
    }
    private void UpdateAnimatorState()
    {
        MovementState state;
        if (axisX > 0f)
        {
            state = MovementState.running;
            spriteR.flipX = false;
        }
        else if (axisX < 0f)
        {
            state = MovementState.running;
            spriteR.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        //checking for jump
        if (rb.velocity.y > .25f)  
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.25f)
        {
            state = MovementState.falling;
        }

        playerAnim.SetInteger("state", (int)state);
    }

    private bool IsOnGround()
    {
        return Physics2D.BoxCast(bcoll.bounds.center, bcoll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
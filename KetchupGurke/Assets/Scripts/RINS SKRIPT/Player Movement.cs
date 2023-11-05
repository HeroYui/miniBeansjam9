using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigid;
    private BoxCollider2D playerCollider;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private enum MovementState{idle, running, falling, jumping }

    [SerializeField] private LayerMask jumpableGround;
    private float directionX = 0f;
    private float movementSpeed = 7f;
    private float jumpForce = 14f;

   

    // Start is called before the first frame update
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(directionX * movementSpeed,rigid.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rigid.velocity = new Vector2(rigid.velocity.y,jumpForce);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state;

        if(directionX > 0f )
        {
            state = MovementState.running;
            spriteRenderer.flipX = false;
        } 
        else if (directionX < 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = true;
        }
        else
        {
            state = MovementState.idle;  
        }

        if(rigid.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        } 
        else if(rigid.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(playerCollider.bounds.center,playerCollider.bounds.size,0f,Vector2.down,0.1f,jumpableGround);
    }
}

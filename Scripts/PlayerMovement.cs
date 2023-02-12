using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator animator; //animation 
    private float directionX = 0f;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField]private float jumpSpeed = 10f; 

    private enum MovementState { idle, run, jump, falling }; //0,1,2,3

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); //animation
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            //playerRb.velocity = new Vector2(0, 14f); //X,Y,Z
        }

        directionX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);

        UpdateAnimation();

        

        //float vertical = Input.GetAxis("Vertical");
        //rb.velocity = new Vector2(rb.velocity.x, vertical * 3.5f);
    }

    private void UpdateAnimation()
    {
        MovementState state; //Animation movements

        //animation 
        if (directionX > 0f)
        {
            state = MovementState.run;
            sprite.flipX = false; 
        }
        else if (directionX < 0f)
        {
            state = MovementState.run;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y > -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int) state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}

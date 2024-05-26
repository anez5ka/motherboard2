using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //tady Terka
    //serialize je stale private, ale muzes tu promennou upravovat v unity
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    private Rigidbody2D body;
    private Animator anim;
    private float horizontalInput;
    private BoxCollider2D collide;
    private float wallJumpCooldown;
    public float side;

    private void Awake()
    {
        // priradis komponenty k promennym
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collide = GetComponent<BoxCollider2D>();
    }
    
    private void Update()
    {
        //get axis horizontal = leva x prava sipka, output je z intervalu -1(leva spika) az 1(prava sipka)
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        //JUMP
        if (Input.GetKey(KeyCode.Space)&&IsGrounded())
        {
            Jump();
        }

        //MOVING TO SIDE
        if (horizontalInput != 0)
        {
            anim.SetBool("right", horizontalInput > 0);
            if (anim.GetBool("right"))
            {
                side = 1;
            }
            else
            {
                side = -1;
            }
        }
        //ANIMATOR PARAMETERS
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", IsGrounded());

        //WALLJUMP
        if (OnWall())
        {
            wallJumpCooldown += Time.deltaTime;
        }
        else
        {
            wallJumpCooldown = 0;
            body.gravityScale = 1;
        }
        if (wallJumpCooldown < 0.1f)
        {
            if (OnWall() && !IsGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            if (Input.GetKey(KeyCode.Space) && OnWall())
            {
                Jump();
            }
        }
        else
        {
            body.gravityScale = 1;
        }
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);

        }
        else if (OnWall())
        {
            body.velocity = new Vector2(side * speed, jumpPower);
        }
    }

    //raycast vysila signal, jestli neni x daleko nejaky predmet
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(collide.bounds.center, collide.bounds.size,0, Vector2.down,0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    
    private bool OnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(collide.bounds.center, collide.bounds.size, 0, new Vector2(-side,0), 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    
    public bool canShoot()
    {
        return horizontalInput == 0 && IsGrounded() && !OnWall();
    }
    
    //FACING SIDE
    public float Facingside()
    {
        return side;
    }
}

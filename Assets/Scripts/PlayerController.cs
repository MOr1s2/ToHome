using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public float speed;
    public float flySpeed;
    public LayerMask ground;

    Animator animator;
    Collider2D coll;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<CircleCollider2D>();
    }

    void FixedUpdate()
    {
        Movement();
        AnimatorSet();
    }

    void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float faceDirection = Input.GetAxisRaw("Horizontal");
        bool fly = Input.GetButton("Jump");

        if (faceDirection != 0)
        {
            transform.localScale = new Vector3(faceDirection,1,1);
            rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        }
        if (fly)
        {
            rb.velocity = new Vector2(rb.velocity.x, flySpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("collection"))
        {
            Destroy(other.gameObject);
        }
    }

    void AnimatorSet()
    {
        animator.SetFloat("horizontal_speed",Mathf.Abs(rb.velocity.x));
        animator.SetFloat("vertical_speed", rb.velocity.y);
        if (coll.IsTouchingLayers(ground))
            animator.SetBool("on_floor", true);
        else
            animator.SetBool("on_floor", false);
    }

}

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

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Movement();
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake_move : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform leftpoint;
    public Transform rightpoint;
    private float left_x_value;
    private float right_x_value;
    //private bool faceleft = true;是否面向左
    public int speed;

    Animator animator;
    public float attacktime;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        left_x_value = leftpoint.position.x;
        right_x_value = rightpoint.position.x;

        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!animator.GetBool("is_attack"))
        {
            movement();
        }
        AnimatorSet();
    }

    public void movement()
    {
        if(transform.localScale.x > 0)//初始状态如果是面向左
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (transform.position.x < left_x_value)
            {
                transform.localScale = new Vector3(-0.15f, 0.15f, 0.15f);
                
            }
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x > right_x_value)
            {
                transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animator.SetBool("is_attack", true);
            animator.SetFloat("lastHurtTime", Time.timeSinceLevelLoad);
        }
    }

    void AnimatorSet()
    {
        if (animator.GetBool("is_attack") && Time.timeSinceLevelLoad - attacktime > animator.GetFloat("lastHurtTime"))
        {
            animator.SetBool("is_attack", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed;
    public float flySpeed;
    /*加入持有樱桃计数和生命值计数*/
    public int Cherrycount;
    
    public int HealthValue;
    public int MaxHealthValue;

    public bool isHurt;//默认是未受伤

    /*加入收集樱桃音效*/
    public AudioSource cherryCollectionAudio;
    public AudioSource heartCollectionAudio;

    /*UI显示樱桃数和生命值文本*/
    public Text Healthnum;
    public Text Cherrynum;


    public LayerMask ground;

    Animator animator;
    Collider2D coll;

    void Start()
    {
        HealthValue = MaxHealthValue;
        animator = GetComponent<Animator>();
        coll = GetComponent<CircleCollider2D>();  
    }

    void FixedUpdate()
    {
        Cherrynum.text = Cherrycount.ToString();
        Healthnum.text = HealthValue.ToString();
        if (!isHurt)//受伤了停止当前运动，切换到击退效果
        {
            Movement();
        }
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


    /*与樱桃碰撞触发效果*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "CherryCollection")
        {
            cherryCollectionAudio.Play();
            Destroy(collision.gameObject);
            Cherrycount += 1;
           
        }
        if (collision.CompareTag("HeartCollection"))
        {
            heartCollectionAudio.Play();
            Destroy(collision.gameObject);
            if (HealthValue < MaxHealthValue)
            {
                HealthValue += 2;
                if (HealthValue > MaxHealthValue)
                {
                    HealthValue = MaxHealthValue;
                }
            }
            
        }
    }

    void AnimatorSet()
    {
        animator.SetFloat("horizontal_speed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("vertical_speed", Mathf.Abs(rb.velocity.y));
        if (coll.IsTouchingLayers(ground))
            animator.SetBool("on_floor", true);
        else
            animator.SetBool("on_floor", false);
        if (isHurt)
        {
            if (Mathf.Abs(rb.velocity.x) < 0.1f)
            {
                isHurt = false;

            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)//与陷阱碰撞触发效果
    {
        if (collision.gameObject.tag == "spike")
        {
            if (animator.GetBool("on_floor") == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, flySpeed);
            }
            else if (transform.position.x < collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-10, rb.velocity.y);
                isHurt = true;
            }
            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(10, rb.velocity.y);
                isHurt = true;
            }
            HealthValue -= 1;
        }

        
    }


}

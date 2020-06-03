using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Tracing;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed;
    public float flySpeed;
    public float hurtTime;
    /*加入持有樱桃计数和生命值计数*/
    public int CherryValue;

    public int HealthValue;
    public int MaxHealthValue;

    /*加入收集樱桃音效*/
    public AudioSource cherryCollectionAudio;
    public AudioSource heartCollectionAudio;

    /*UI显示樱桃数和生命值文本*/
    public Text Healthnum;
    public Text Cherrynum;


    public LayerMask ground;

    public bool is_dead;//默认为未死亡
    public bool is_target;//判断是否收集够物品
    public int dialogcount;//判断出发收集对话框出现的次数
    public GameObject hunter;
    

    Animator animator;
    Collider2D coll;

    void Start()
    {

        //HealthValue = MaxHealthValue;
        animator = GetComponent<Animator>();
        coll = GetComponent<CircleCollider2D>();
    }

    void FixedUpdate()
    {
        if (!animator.GetBool("is_hurt"))//受伤了停止当前运动，切换到击退效果
        {
            Movement();
        }
        AnimatorSet();
        SetDeath();
        
    }

    void Update()
    {
        Cherrynum.text = CherryValue.ToString();
        Healthnum.text = HealthValue.ToString();
        animator.SetInteger("health", HealthValue);
    }
    
    void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float faceDirection = Input.GetAxisRaw("Horizontal");
        bool fly = Input.GetButton("Jump");

        if (faceDirection != 0)
        {
            transform.localScale = new Vector3(faceDirection, 1, 1);
            rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        }
        if (fly)
        {
            rb.velocity = new Vector2(rb.velocity.x, flySpeed);
        }
    }


    /*与樱桃和爱心碰撞触发效果*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CherryCollection")
        {

            collision.gameObject.tag = "Untagged";
            //Destroy(collision.gameObject);
            collision.GetComponent<Animator>().Play("isGot");

        }
        if (collision.CompareTag("HeartCollection"))
        {
            collision.gameObject.tag = "Untagged";

            //Destroy(collision.gameObject);
            collision.GetComponent<Animator>().Play("isGot");
        }
    }

    void AnimatorSet()
    {
        animator.SetFloat("horizontal_speed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("vertical_speed", Mathf.Abs(rb.velocity.y));
        if (coll.IsTouchingLayers(ground))
        {
            animator.SetBool("on_floor", true);
        }
        else
        {
            animator.SetBool("on_floor", false);
        }
        if (animator.GetBool("is_hurt") && Time.timeSinceLevelLoad - hurtTime > animator.GetFloat("lastHurtTime"))
        {
            animator.SetBool("is_hurt", false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)//与陷阱碰撞触发效果
    {
        if (collision.gameObject.tag == "spike")
        {
            if (animator.GetBool("on_floor") == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, flySpeed);
                animator.SetBool("is_hurt", true);
                animator.SetFloat("lastHurtTime", Time.timeSinceLevelLoad);
            }
            else if (transform.position.x < collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-10, rb.velocity.y);
                animator.SetBool("is_hurt", true);
                animator.SetFloat("lastHurtTime", Time.timeSinceLevelLoad);
            }
            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(10, rb.velocity.y);
                animator.SetBool("is_hurt", true);
                animator.SetFloat("lastHurtTime", Time.timeSinceLevelLoad);
            }
            HealthValue -= 1;
            
        }
        if (collision.gameObject.tag == "coveredSpike")
        {
            if (animator.GetBool("on_floor") == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, flySpeed);
                animator.SetBool("is_hurt", true);
                animator.SetFloat("lastHurtTime", Time.timeSinceLevelLoad);
            }
            else if (transform.position.x < collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-10, rb.velocity.y);
                animator.SetBool("is_hurt", true);
                animator.SetFloat("lastHurtTime", Time.timeSinceLevelLoad);
            }
            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(10, rb.velocity.y);
                animator.SetBool("is_hurt", true);
                animator.SetFloat("lastHurtTime", Time.timeSinceLevelLoad);
            }
            HealthValue -= 1;
            
        }

    }

    public void CherryCount()
    {
        CherryValue += 1;
        if(CherryValue == 4 && dialogcount == 0)
        {
            GameManager.reachtarget(true);
            speed += 2;
            hunter.GetComponent<Hunt>().shootInterval -= 10;
            dialogcount++;
        }
    }

    public void HeartCount()
    {
        if (HealthValue < MaxHealthValue)
        {
            HealthValue += 2;
            if (HealthValue >= MaxHealthValue)
            {
                HealthValue = MaxHealthValue;
            }
        }
    }

    public void SetDeath()
    {   
        if(HealthValue <= 0)
        {
            is_dead = true;
            GameManager.GameOver(is_dead);
        }
        
    }

    public void ReachtargetUI()
    {
        
    }


}

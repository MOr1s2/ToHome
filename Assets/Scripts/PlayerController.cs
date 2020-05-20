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
    /*加入持有樱桃计数*/
    public int Cherrycount;
    public Text Cherrynum;
    /*加入生命值计数*/
    public int lifevalue;


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
        float fly = Input.GetAxisRaw("Vertical");

        if (faceDirection != 0)
        {
            transform.localScale = new Vector3(faceDirection,1,1);
        }
        rb.velocity = new Vector2(horizontalMove * speed, fly * flySpeed);
    }


    /*与樱桃碰撞触发效果*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collection")
        {
            Destroy(collision.gameObject);
            Cherrycount += 1;
            Cherrynum.text = Cherrycount.ToString();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eagle_controll : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform highpoint;
    public Transform lowpoint;
    private float high_y_value;
    private float low_y_value;
    public bool fly_up = true;//判断是否向上飞行

    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        high_y_value = highpoint.position.y;
        low_y_value = lowpoint.position.y;

        Destroy(highpoint.gameObject);
        Destroy(lowpoint.gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();
    }

    public void movement()
    {
        if(fly_up == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
            if (transform.position.y > high_y_value)
            {
                fly_up = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
            if(transform.position.y < low_y_value)
            {
                fly_up = true;
            }
        }
    }


}

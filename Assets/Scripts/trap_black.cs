using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_black : MonoBehaviour//控制夹子陷阱的脚本
{
    public GameObject trap;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animator.SetBool("is_trigger", true);
        }
    }

    public void to_static()
    {
        animator.SetBool("have_trigger", true);
        Destroy(trap.gameObject, 2f);
    }
}

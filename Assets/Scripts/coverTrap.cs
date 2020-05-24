using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coverTrap : MonoBehaviour
{
    public bool is_trigger;//默认未触发
    public int triggercount;
    public GameObject spike;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            triggercount += 1;
        }
        if (triggercount >= 1)
        {
            is_trigger = true;
        }
        if (is_trigger)
        {
            spike.GetComponent<SpriteRenderer>().sortingLayerName = "exposed";

        }
    }
}

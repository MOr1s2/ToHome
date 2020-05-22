using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int HealthValue;
    public int MaxHealthValue;
    public Text Healthnum;

    // Start is called before the first frame update
    void Start()
    {
        HealthValue = MaxHealthValue;
        Healthnum.text = HealthValue.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HeartCollection")){
            Destroy(collision.gameObject);
            if(HealthValue < MaxHealthValue)
            {
                HealthValue += 2;
                if (HealthValue > MaxHealthValue)
                {
                    HealthValue = MaxHealthValue;
                }
            }
            Healthnum.text = HealthValue.ToString();
        }
    }
}

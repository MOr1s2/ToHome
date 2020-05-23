using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public Rigidbody2D rb;
    public int HealthValue;
    public int MaxHealthValue;
    /*UI显示生命值文本*/
    public Text Healthnum;
    
 


    /*加入收集爱心音效*/
    public AudioSource collectionAudio;

    

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

    /*收集爱心恢复生命*/
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HeartCollection")){
            collectionAudio.Play();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject player;
    public int collectionvalue;
    public GameObject startTipsUI;//房子提示

    // Update is called once per frame
    void Update()
    {
        getCollectionValue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(collectionvalue >= 4)
            {
                GameManager.GoodEnding(true);
            }
            if (collectionvalue < 4 && collectionvalue >= 1)
            {
                GameManager.BadEnding(true);
            }
            if (collectionvalue == 0)
            {
                startTipsUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        { 
            startTipsUI.SetActive(false);
        }
    }

    private void getCollectionValue()
    {
        collectionvalue = player.GetComponent<PlayerController>().CherryValue;
    }

}

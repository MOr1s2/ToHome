using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject player;
    public int collectionvalue;
    public GameObject startTipsUI;//游戏开始房子提示
    public GameObject finishTipsUI;//游戏结束提示

    // Update is called once per frame
    void Update()
    {
        getCollectionValue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (collectionvalue>0)
            {
                finishTipsUI.SetActive(true);
            }
            
            if (collectionvalue == 0)
            {
                startTipsUI.SetActive(true);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player" )
        {
            if (collectionvalue == 0)
            {
                startTipsUI.SetActive(false);
            }
            if (collectionvalue > 0)
            {
                finishTipsUI.SetActive(false);
            }
        }
    }

    private void getCollectionValue()
    {
        collectionvalue = player.GetComponent<PlayerController>().CherryValue;
    }



}

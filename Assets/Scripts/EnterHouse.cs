using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHouse : MonoBehaviour
{
    public GameObject player;
    public GameObject finishUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            finishUI.SetActive(false);
            if (player.GetComponent<PlayerController>().CherryValue >= 5)
            {
                GameManager.GoodEnding(true);
            }
            if (player.GetComponent<PlayerController>().CherryValue < 5 && player.GetComponent<PlayerController>().CherryValue >= 1)
            {
                GameManager.BadEnding(true);
            }
        }  
    }
}

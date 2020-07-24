using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goodendingUI_controll : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gamemanager;
    public void goodending_Animation_isover()
    {
        gamemanager.GetComponent<GameManager>().goodendingUI_isover = true;
    }
}

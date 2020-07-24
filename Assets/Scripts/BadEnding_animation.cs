using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEnding_animation : MonoBehaviour
{
    public GameObject gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void badending_Animation_isover()
    {
        gamemanager.GetComponent<GameManager>().badendingUI_isover = true;
    }
}

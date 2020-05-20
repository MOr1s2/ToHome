using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_lifevalue : MonoBehaviour
{
    public List<GameObject> UI_logo = new List<GameObject>();//生成logo列表

    private Vector3 lifespawnpostion;
    private Vector3 cherryposition;
    public GameObject player;

    private int current_lifevalue;

    void Start()
    {
        lifespawnpostion = UI_logo[0].transform.position;
        cherryposition = UI_logo[1].transform.position;
       
    }

    void Update()
    {
        
    }

    public void Spawn_life_logo()
    {
        
    }

}

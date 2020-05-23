using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollimationController : MonoBehaviour
{
    public Transform playerTrans; 
    public float randomRange;

    float lastAimTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Aim();
    }

    private void Aim()
    {
        if (Time.timeSinceLevelLoad - 0.2 > lastAimTime)
        {
            float offsetX = Random.Range(-randomRange, randomRange);
            float offsetY = Random.Range(-randomRange, randomRange);
            transform.position = new Vector2(playerTrans.position.x + offsetX, playerTrans.position.y + offsetY);
            lastAimTime = Time.timeSinceLevelLoad;
        }
    }
}

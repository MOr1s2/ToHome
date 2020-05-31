using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollimationController : MonoBehaviour
{
    public Transform playerTrans; 
    public float randomRange;
    public float aimInterval;
    public bool fixedCollimation;
    float lastAimTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        fixedCollimation = false;
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
    }

    private void Aim()
    {
        if (!fixedCollimation && Time.timeSinceLevelLoad - aimInterval > lastAimTime)
        {
            float offsetX = Random.Range(-randomRange, randomRange);
            float offsetY = Random.Range(-randomRange, randomRange);
            transform.position = new Vector2(playerTrans.position.x + offsetX, playerTrans.position.y + offsetY);
            lastAimTime = Time.timeSinceLevelLoad;
        }
    }

    private void Disable() {
        gameObject.SetActive(false);
        fixedCollimation = false;
    }
}

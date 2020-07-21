using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunt : MonoBehaviour
{
    
    public GameObject collimation;
    public GameObject player;
    CollimationController collimationControl;
    PlayerController playerControl;
    public Animator playerAnim;
    public float firstShootTime;
    public float shootInterval;
    public float aimmingTime;
    public float bulletFlyTime;
    public AudioSource reloading;
    public AudioSource shoot;
    public AudioSource bulletMiss;
    public LayerMask layerPlayer;

    float lastShootTime;
    bool isAimming;
    bool isShooting;

    // Start is called before the first frame update
    void Start()
    {
        lastShootTime = firstShootTime - shootInterval;
        isAimming = false;
        isShooting = false;
        collimationControl = collimation.GetComponent<CollimationController>();
        playerControl = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Hunting();
    }

    private void Hunting()
    {
        if (Time.timeSinceLevelLoad - shootInterval > lastShootTime)
        {
            collimation.SetActive(true);
            reloading.Play();
            lastShootTime = Time.timeSinceLevelLoad;
            isAimming = true;
        }
        if (isAimming && Time.timeSinceLevelLoad - aimmingTime > lastShootTime)
        {
            shoot.Play();
            collimationControl.fixedCollimation = true;
            isAimming = false;
            isShooting = true;
        }
        if (isShooting && Time.timeSinceLevelLoad - aimmingTime - bulletFlyTime > lastShootTime)
        {
            isShooting = false;
            if (collimation.GetComponent<CircleCollider2D>().IsTouchingLayers(layerPlayer))
            {
                playerAnim.SetBool("is_hurt", true);
                playerAnim.SetFloat("lastHurtTime", Time.timeSinceLevelLoad);
                playerControl.HealthValue -= 1;
                collimation.GetComponent<Animator>().Play("hit");
            }
            else
            {
                bulletMiss.Play();
                collimation.SetActive(false);
                collimationControl.fixedCollimation = false;
            }
        }
    }
}

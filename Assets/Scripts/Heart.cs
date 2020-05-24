using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public void Death()
    {

        Destroy(gameObject);
    }
    public void Count()
    {
        FindObjectOfType<PlayerController>().HeartCount();
    }
    public void PlayAudio()
    {
        FindObjectOfType<PlayerController>().heartCollectionAudio.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cherry : MonoBehaviour
{

    public void Death()//樱桃销毁
    {

        Destroy(gameObject);
    }
    public void Count()
    {
        FindObjectOfType<PlayerController>().CherryCount();
    }
    public void Playaudio()
    {
        FindObjectOfType<PlayerController>().cherryCollectionAudio.Play();
    }
}

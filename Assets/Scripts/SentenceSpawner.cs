using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentenceSpawner : MonoBehaviour
{
    public List<GameObject> Sentencelist = new List<GameObject>();
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        ActivateSentence();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateSentence()
    {
        index = Random.Range(0, Sentencelist.Count);
        Sentencelist[index].SetActive(true);
    }
}

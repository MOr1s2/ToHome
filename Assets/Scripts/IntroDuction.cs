using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroDuction : MonoBehaviour
{
    public Animator crossfade;
    public void ReturnMenu()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex - 1));
    }
    IEnumerator LoadScene(int SceneIndex)
    {
        crossfade.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneIndex);
    }
}

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject GuidUI;
  public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

  public void QuitGame()
    {
        Application.Quit();
    }


    public void ToIntroduction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
    public void ToGuid()
    {
        GuidUI.SetActive(true);
    }
   public void Return()
    {
        GuidUI.SetActive(false);
    }
}

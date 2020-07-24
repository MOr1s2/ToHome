 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject GuidUI;
    public GameObject PauseUI;
    public Animator crossfade;


    public void Update()
    {
        PauseGame();
    }
    IEnumerator LoadScene(int SceneIndex)
    {
        crossfade.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneIndex);
    }
    public void PlayGame()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 2));
    }

  public void QuitGame()
    {
        Application.Quit();
    }


    public void ToIntroduction()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    
    public void ToGuid()
    {
        GuidUI.SetActive(true);
    }
   public void Return()
    {
        GuidUI.SetActive(false);
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ReturnGame()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

}

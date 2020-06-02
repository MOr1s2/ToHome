using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public GameObject player ;
    public GameObject gameOverUI;//死亡结局
    public GameObject goodendingUI;//好结局
    public GameObject badEndingUI;//坏结局
    public GameObject reachtargetUI;//收集4个浆果弹出对话框
   

   private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public static void GameOver(bool is_dead)
    {
        if (is_dead)
        {
            instance.gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public static void GoodEnding(bool is_GoodEnding)
    {
        if (is_GoodEnding)
        {
            instance.goodendingUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public static void BadEnding(bool is_BadEnding)
    {
        if (is_BadEnding)
        {
            instance.badEndingUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public static  void reachtarget(bool is_target)
    {
        if (is_target)
        {
            instance.reachtargetUI.SetActive(true);
            Destroy(instance.reachtargetUI, 4f);
        }
           
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StartCG_controll : MonoBehaviour
{
    private VideoPlayer video;
    public float videoFrame;
    public bool is_over;
    public VideoClip _VideoClip;
    public Animator crossfade;



    // Start is called before the first frame update
    void Start()
    {
        video = GetComponent<VideoPlayer>();
        video.clip = _VideoClip;
        video.Play();
        //Debug.Log(video.frameCount);167帧
    }

    // Update is called once per frame
    void Update()
    {
        VideoEnd();
    }

    void VideoEnd()
    {
        //video.frame代表的当前帧数；
        //video.frameCount代表视频总帧数；

        videoFrame = video.frame;
        
        if (videoFrame >= video.frameCount-1)
        {
            is_over = true;
            //TODO视频播放完毕后的逻辑

            StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }
    
    IEnumerator LoadScene(int SceneIndex)
    {
        crossfade.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneIndex);
    }
}

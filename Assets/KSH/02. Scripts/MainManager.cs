using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public AudioClip mainAudio;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
    }
    public void SceneChange()
    {
        //anim.SetTrigger("Hi");
        //게임 화면으로 이동
        SceneManager.LoadScene("Play_FSW");
    }
     
}


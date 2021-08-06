using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject result;
    public GameObject Button;

    // Start is called before the first frame update
    void Start()
    {
        //GameOver Text 크기 0->1
        iTween.ScaleTo(gameOver, iTween.Hash(
            "x", 1,
            "y", 1,
            "z", 1,
            "time", 2,
            "easeType", iTween.EaseType.easeOutBack,
            "oncompletetarget", gameObject,
            "oncomplete", "OnCompleteAni"
            ));

        //다시하기 버튼 크기 0->1
        iTween.ScaleTo(Button, iTween.Hash(
            "x", 1,
            "y", 1,
            "z", 1,
            "time", 2,
            "easeType", iTween.EaseType.easeOutBounce,
            "delay", 1
            ));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnclikRetry()
    {
        SceneManager.LoadScene("Play_FSW");
    }

    void OnCompleteAni()
    {
        
        //최고점수 크기 0->1
        //iTween.ScaleTo(result, iTween.Hash(
        //    "x", 1,
        //    "y", 1,
        //    "z", 1,
        //    "time", 2,
        //    "easeType", iTween.EaseType.easeOutBack
        //    ));
    }
}

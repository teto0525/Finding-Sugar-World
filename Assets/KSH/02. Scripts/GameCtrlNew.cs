using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCtrlNew : MonoBehaviour
{
    public GameObject YouDie;
    bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void PlayerDie()
    {
        iTween.ScaleTo(YouDie, iTween.Hash(
            "x", 1,
            "y", 1,
            "z", 1,
            "time", 2,
            "easeType", iTween.EaseType.easeOutBounce,
            "delay", 1
            ));

        gameOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == true)
        {
            GameOver();
        }
    }

    void GameOver()
    {

        if (Input.GetMouseButtonDown(0))

        {
            SceneManager.LoadScene("GameOver");

        }
    }
}

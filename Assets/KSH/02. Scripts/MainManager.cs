using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
 
    // Start is called before the first frame update

    public void SceneChange()
    {
        //anim.SetTrigger("Hi");
        //���� ȭ������ �̵�
        SceneManager.LoadScene("Play_FSW");
    }
}

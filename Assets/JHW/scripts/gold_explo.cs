using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gold_explo : MonoBehaviour
{
    public GameObject ExploEFT;


    BlackBox blockBlock;
    bool isDestroy; 

    // Start is called before the first frame update
    void Start()
    {
        blockBlock = GameObject.Find("���ڽ�").GetComponent<BlackBox>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDestroy == false && blockBlock.destroyCoin)
        {
            ShowDestoryEft();
            isDestroy = true;
        }
    }
    
    public void ShowDestoryEft()
    {
        //���� ���ֶ�

    }


    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class hp : MonoBehaviour
{

    [SerializeField]
    private Slider hpbar;

    private float iniHP = 100.0f;
    public float currHP = 100.0f;

    void Start()
    {


    }

    void Update()
    {
       
        HandleHP();
    }

    void HandleHP()
    {
        hpbar.value = Mathf.Lerp(hpbar.value, (float)currHP / (float)iniHP, Time.deltaTime * 10);
    }

    public void SetHp(float hp)
    {
        currHP = hp;
    }

}
 

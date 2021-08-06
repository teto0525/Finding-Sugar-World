using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class hp : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;

    private float iniHP = 100.0f;
    private float currHP = 100.0f;

    private Animator anim;

    void Start()
    {
        currHP = iniHP;
        hpbar.value = (float)currHP / (float)iniHP;

    }

    void Update()
    {
        currHP -= 1;
        HandleHP();
    }

    void HandleHP()
    {
        hpbar.value = Mathf.Lerp(hpbar.value, (float)currHP / (float)iniHP, Time.deltaTime * 10);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp_enemy : MonoBehaviour
{
    private float iniHP_e = 30;
    public float currHP_e;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetHp_e(float hp_e)
    {
        currHP_e = hp_e;
    }
}

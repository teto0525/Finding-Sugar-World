using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetCtrl : MonoBehaviour
{

    public float speed = 4;
    public GameObject target;
    private float r;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1. Player 방향 구하기
        Vector3 dir = target.transform.position - this.transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

         r = Input.GetAxis("Mouse X");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//이동하다가 장애물 근처에 가면 장애물이 움직인다
//닿으면 죽는다
public class Player : MonoBehaviour
{
    public int speed = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, v, 0);
        transform.Translate(dir * speed * Time.deltaTime);
        //transform.position+=dir*speed*Time.deltaTime;
    }
    void OnTriggerEnter(Collider other)
    {
        //장애물에 닿으면 죽는다
        Destroy(other.gameObject);
    }
}
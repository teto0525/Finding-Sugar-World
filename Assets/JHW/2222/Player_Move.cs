using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //사용자의 입력을 받아라
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //방향을 설정해라
        Vector3 dirH = transform.right * h;
        Vector3 dirV = transform.up * v;
        Vector3 dir = dirH + dirV;
        dir.Normalize();
        //방향대로 계속 나아가게 해라 P=P0+VT
        transform.position += dir * speed * Time.deltaTime;
    }
}

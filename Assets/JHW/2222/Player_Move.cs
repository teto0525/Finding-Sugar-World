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
        //������� �Է��� �޾ƶ�
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //������ �����ض�
        Vector3 dirH = transform.right * h;
        Vector3 dirV = transform.up * v;
        Vector3 dir = dirH + dirV;
        dir.Normalize();
        //������ ��� ���ư��� �ض� P=P0+VT
        transform.position += dir * speed * Time.deltaTime;
    }
}

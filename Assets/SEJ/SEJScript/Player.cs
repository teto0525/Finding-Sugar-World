using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�̵��ϴٰ� ��ֹ� ��ó�� ���� ��ֹ��� �����δ�
//������ �״´�
public class Player : MonoBehaviour
{
    private float h;
    private float v;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = (Vector3.right * h) + (Vector3.forward * v);
        transform.Translate(dir.normalized * speed * Time.deltaTime);
        //transform.position+=dir*speed*Time.deltaTime;
    }
}
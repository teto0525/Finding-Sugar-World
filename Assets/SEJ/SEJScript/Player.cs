using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�̵��ϴٰ� ��ֹ� ��ó�� ���� ��ֹ��� �����δ�
//������ �״´�
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
        //��ֹ��� ������ �״´�
        Destroy(other.gameObject);
    }
}
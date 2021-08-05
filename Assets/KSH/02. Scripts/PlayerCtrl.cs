using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{

    // �÷��̾� ������ (�յ��¿� + ��)
    private float h;
    private float v;
    private float r;
    [Range(5.0f, 20.0f)]
    public float moveSpeed = 8.0f;
    [Range(100.0f, 200.0f)]
    public float turnSpeed = 200f;

    // �÷��̾� �ִϸ��̼�
    private Animator anim;

    // �÷��̾� ������
    public GameObject[] Item;
    int Count = 0;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void PlayerMove()
    {
        // �÷��̾� ������ ����
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");
        Vector3 dir = ((Vector3.right * h) + (Vector3.forward * v));
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * turnSpeed * r * Time.deltaTime);

        //�ڷ� �̵��� ������ �̵� �Ұ���
        if (v <= 0)
        {
            h = 0;
        }
    }

    void PlayerAnim()
    {
        if (v < 0.0f)
        {
            anim.SetTrigger("Walk_B");
        }
        else if (v > 0.0f)
        {
            anim.SetTrigger("Walk_F");
            v = 0;
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Attack");
        }
        else if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("Jump");
        }
        else
        {
            anim.SetTrigger("Idle");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            this.transform.Translate(Vector3.back * 10.0f * moveSpeed * Time.deltaTime);
            anim.SetBool("Hit", true);
        }
        else
        {
            anim.SetBool("Hit", false);
        }
    }



}

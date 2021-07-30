using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    //�յ��¿� + ��
    private float h;
    private float v;
    private float r;

    [Range(5.0f, 20.0f)]
    public float moveSpeed = 8.0f;
    [Range(100.0f, 200.0f)]
    public float turnSpeed = 200f;

    //�ִϸ��̼� ������ ���� ����
    private Animator anim;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");

        //�밢�� ���� �̵�
        Vector3 dir = ((Vector3.right * h) + (Vector3.forward * v));

        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * turnSpeed * r * Time.deltaTime);

        //�ڷ� �̵��� ������ �̵� �Ұ���
        if (v <= 0)
        {
            h = 0;
        }
        rigidbody.velocity = new Vector3(v, 0, h);

        PlayerAnim();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Debug.Log("�浹 ����");
            anim.Play("Hit");
            this.transform.Translate(Vector3.back * 5.0f * Time.deltaTime);
        }
    }


    void PlayerAnim()
    {
        if(v < 0.0f)
        {
            anim.SetTrigger("Walk_B");
        }
        else if(v > 0.0f)
        {
            anim.SetTrigger("Walk_F");
            v = 0;
        }
        else if(Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Attack");
        }
        else if(Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("Jump");
        }
        else
        {
            anim.SetTrigger("Idle");
        }
        //if (v >= 0.1f)
        //{
        //    anim.CrossFade("RunF", 0.3f);
        //}
        //else if (v <= -0.1f)
        //{
        //    anim.CrossFade("RunB", 0.3f);
        //}
        //else if (h >= 0.1f)
        //{
        //    anim.CrossFade("RunR", 0.3f);
        //}
        //else if (h >= -0.1f)
        //{
        //    anim.CrossFade("RunL", 0.3f);
        //}
        //else
        //{
        //    anim.CrossFade("Idle", 0.3f);
        //}
    }
}

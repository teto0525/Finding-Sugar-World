using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    //앞뒤좌우 + 턴
    private float h;
    private float v;
    private float r;

    [Range(5.0f, 20.0f)]
    public float moveSpeed = 8.0f;
    [Range(100.0f, 200.0f)]
    public float turnSpeed = 200f;

    //애니메이션 저장할 변수 지정
    private Animator anim;
    private Animation anime;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");

        //대각선 방향 이동
        Vector3 dir = ((Vector3.right * h) + (Vector3.forward * v));

        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * turnSpeed * r * Time.deltaTime);

        //뒤로 이동시 옆으로 이동 불가능
        if (v <= 0)
        {
            h = 0;
        }

        PlayerAnim();
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
    }
}

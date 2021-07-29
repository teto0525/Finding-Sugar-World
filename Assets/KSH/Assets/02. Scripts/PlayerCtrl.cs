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
    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();

        anim.Play("Idle");
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

        PlayerAnim();
    }

    void PlayerAnim()
    {
        if (v >= 0.1f)
        {
            anim.CrossFade("RunF", 0.3f);
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade("RunB", 0.3f);
        }
        else if (v >= 0.1f)
        {
            anim.CrossFade("RunR", 0.3f);
        }
        else if (v >= -0.1f)
        {
            anim.CrossFade("RunL", 0.3f);
        }
        else
        {
            anim.CrossFade("Idle", 0.3f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isDie", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //1. �ε��� ���ӿ�����Ʈ �ı�
       // Destroy(collision.gameObject);
        //2. ���� ���� ������Ʈ �ı�
       // Destroy(gameObject);
       
        if (collision.collider.tag=="Player")
        {
            //anim.Play("die");
            anim.SetBool("isDie",true);
           // Destroy(gameObject);
        }
    }
}

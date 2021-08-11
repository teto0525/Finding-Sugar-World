using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Attack : MonoBehaviour
{
    private Transform MonsterTR;
    private Transform PlayerTR;
    private NavMeshAgent nvAgent;
    private Animator anim;




    //State
    //0. IDLE
    //1.TRACE
    //2. ATTACK
    //3. 

    int state = 0;
    bool isDie = false;
    Vector3 dir;

    //�÷��̾ ã��
    GameObject player;

    public float currHP_e;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        MonsterTR = gameObject.GetComponent<Transform>();
        PlayerTR = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = gameObject.GetComponent<NavMeshAgent>();
        float distance = Vector3.Distance(MonsterTR.position, PlayerTR.position);


        //nvAgent.destination = player.transform.position;

        //�÷��̾ ���ϴ� ������ ���Ѵ�. P - E
        // dir = player.transform.position - transform.position;
        //transform.position += dir * Time.deltaTime;

        if (isDie == false)
        {

            if (state != 0)
            {
                state = 0;
                anim.SetTrigger("idle");

            }
            else if (distance <= 5)
            {
                nvAgent.destination = PlayerTR.position;

                if (state != 1)
                {
                    state = 1;
                    anim.SetTrigger("walk");
                }
            }
        }
        else if (currHP_e <= 0)
        {
            //���� ���� hp���� 0���� ������ �״� ���,���ó��
            isDie = true;
            anim.SetTrigger("isDie");
            nvAgent.destination = transform.position;
            Destroy(gameObject, 2f);
        }
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Sword"))
        {

            //hp�� �پ���
            currHP_e -= 10.0f;
            //����׷α׷� ���� hp�� ���
            Debug.Log(currHP_e);
            Debug.Log("Į �浹");
            //player.attack=false ����
        }
        else if (col.collider.CompareTag("Player"))
        {
            state = 2;
            anim.SetTrigger("attack");
            Debug.Log("�÷��̾� �浹");


        }
    }
}

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("Player") && isDie == false)
//        {
//            transform.LookAt(player.transform.position);

//            state = 2;
//            anim.SetTrigger("attack");

//        }
//        else if (collision.gameObject.CompareTag("Sword"))
//        {
//            anim.SetTrigger("isDie");
//            isDie = true;
//            Debug.Log("Į2");

//        }
//    }

//}


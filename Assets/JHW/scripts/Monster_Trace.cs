using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster_Trace : MonoBehaviour
{
    private Transform MonsterTR;
    private Transform PlayerTR;
    private NavMeshAgent nvAgent; //using UnityEngine.AI;
    private Animator anim;

    //State
    //0. IDLE
    //1.TRACE
    //2. ATTACK
    //3. DIE
    int state = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MonsterTR = gameObject.GetComponent<Transform>();
        PlayerTR = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = gameObject.GetComponent<NavMeshAgent>();

        float distance = Vector3.Distance(MonsterTR.position, PlayerTR.position);

        //거리 안이면 추적
        if (distance <= 15.0f)
        {
            nvAgent.destination = PlayerTR.position;

            if (state != 1)
            {
                state = 1;
                anim.SetTrigger("TRACE");
            }
        }

        //거리 밖이면 무조건 대기모션
        else
        {
            if (state != 0)
            {
                state = 0;
                anim.SetTrigger("IDLE");
                nvAgent.destination = MonsterTR.position;
            }
        }



    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            nvAgent.destination = MonsterTR.position;
            anim.SetTrigger("ATTACK");
            state = 2;
        }

        //else if (collision.collider.tag == "Sword")    
        //{    
        //    anim.SetTrigger("DIE");    

        //}    
    }

}

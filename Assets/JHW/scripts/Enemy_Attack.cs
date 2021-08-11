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

    //플레이어를 찾자
    GameObject player;

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


        nvAgent.destination = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));

        player= GameObject.Find("Player");
        //플레이어를 향하는 방향을 구한다. P - E
       // dir = player.transform.position - transform.position;
        //transform.position += dir * Time.deltaTime;
        



        if (isDie == false)
        {
            
            if (state != 0)
            {
                state = 0;
                anim.SetTrigger("idle");
                
            }
        }

    }
    private void OnTriggernEnter(Collider other)
    {
        if (isDie == false)
        {

            //if (other.gameObject.tag == "Player" || other.gameObject.tag == "Sword")
            //{
                
            //    anim.SetTrigger("attack");
            //    state = 2;

            //}
            //if (other.gameObject.tag == "Sword")
            //{
            //    anim.SetTrigger("isDie");
            //    isDie = true;
            //    Debug.Log("칼1");

            //}
        }
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && isDie==false)
        {
            transform.LookAt(player.transform.position);

            state = 2;
            anim.SetTrigger("attack");
            
        }
        else if (collision.gameObject.CompareTag("Sword"))
        {
            anim.SetTrigger("isDie");
            isDie = true;
            Debug.Log("칼2");

        }
    }
}

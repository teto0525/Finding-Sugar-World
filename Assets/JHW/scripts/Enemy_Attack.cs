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
    //3. isDie

    int state = 0;
    bool isDie = false;
    Vector3 dir;

    //플레이어를 찾자
    GameObject player;

    float currHP_e = 30;

    public GameObject Explosion;

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

        //플레이어를 향하는 방향을 구한다. P - E
        // dir = player.transform.position - transform.position;
        //transform.position += dir * Time.deltaTime;

        if (isDie == false && currHP_e > 0)
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
                isDie = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            nvAgent.destination = transform.position;

            if (state != 3)
            {
                CreateExploEffect();
                state = 3;
                anim.SetTrigger("isDie");
                Destroy(gameObject, 1.0f);
            }

        }

    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Sword"))
        {

            //hp값 줄어들기
            currHP_e -= 10.0f;
            //디버그로그로 현재 hp값 출력
            Debug.Log("에너미hp : " + currHP_e);

            //player.attack=false 선언
        }
        else if (col.collider.CompareTag("Player"))
        {
            state = 2;
            anim.SetTrigger("attack");
            Debug.Log("플레이어 충돌");


        }
    }
    void CreateExploEffect()
    {
        // 폭발공장에서 폭발효과 만든다.
        GameObject Explosion2 = Instantiate(Explosion);
        // 만들어진 폭발효과를 enemy(나자신)의 위치에 놓는다
        Explosion2.transform.position = transform.position;
        //만들어진 폭발효과에서 ParticleSystem 컴포넌트를 가져온다
        ParticleSystem ps = Explosion2.GetComponent<ParticleSystem>();
        //가져온 컴포넌트의 기능중 play를 실행
        ps.Play();

        Destroy(Explosion2, 3);
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
//            Debug.Log("칼2");

//        }
//    }

//}


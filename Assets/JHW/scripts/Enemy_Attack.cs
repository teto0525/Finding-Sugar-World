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


        // nvAgent.destination = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
       
            
       if (state != 0)
       {
          state = 0;
          anim.SetTrigger("idle"); 
                
       }

    }
<<<<<<< Updated upstream
    private void OnCollisionEnter(Collision collision)
    {
        if (isDie == false)
        {

            if (collision.collider.tag == "Player")
            {
                
                anim.SetTrigger("attack");
                state = 2;

            }
            else if (collision.collider.tag == "Sword")
=======
    private void OnTriggernEnter(Collider other)
    {
         if (other.gameObject.CompareTag("Sword"))
>>>>>>> Stashed changes
            {
                anim.SetTrigger("isDie");
            }
    }
}

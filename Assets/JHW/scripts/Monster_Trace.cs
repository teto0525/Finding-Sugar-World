using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster_Trace : MonoBehaviour
{
    private Transform monsterTR;
    private Transform PlayerTR;
    private NavMeshAgent nvAgent; //using UnityEngine.AI;



    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(PlayerTR.position, monsterTR.position);

        if (distance<=5.0f) {
            monsterTR = gameObject.GetComponent<Transform>();
            PlayerTR = GameObject.FindWithTag("Player").GetComponent<Transform>();

            nvAgent = gameObject.GetComponent<NavMeshAgent>();
            nvAgent.destination = PlayerTR.position;
        }
    }
}

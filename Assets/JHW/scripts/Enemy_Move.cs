using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    Transform target = null;
    float enemyMoveSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * enemyMoveSpeed * Time.deltaTime);
        }

    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            target = col.gameObject.transform;
            Debug.Log("Box Enemy : Target found");
        }
    }

    private void OnTriggerExit(Collider col)
    {
        target = null;
        Debug.Log("Box Enemy : Target lost");
    }
}

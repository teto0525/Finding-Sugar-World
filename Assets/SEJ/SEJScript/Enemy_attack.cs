using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_attack : MonoBehaviour
{
        private Animator anim;
        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnCollisionEnter(Collision collision)
        {
            //1. 부딪힌 게임오브젝트 파괴
            // Destroy(collision.gameObject);
            //2. 나의 게임 오브젝트 파괴
            // Destroy(gameObject);
            if (collision.collider.tag == "Player")
            {
                anim.SetBool("IsAttack", true);

                

                Destroy(gameObject, 1.0f);
            }
            else
            {
                anim.SetBool("IsAttack", false);
            }
        }
}

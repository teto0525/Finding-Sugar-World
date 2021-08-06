using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_attack : MonoBehaviour
{
    private Animator anim;
    public GameObject DeathEffect;
    private float delay = 0.5f;

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
         if (collision.collider.CompareTag("Player") == true)
            {
                anim.SetBool("IsAttack", true);

                GameObject death = Instantiate(DeathEffect);
                death.transform.position = transform.position;

                Destroy(this.gameObject, 0.5f);

        }
        else
            {
                 anim.SetBool("IsAttack", false);
             }
     }
        
}

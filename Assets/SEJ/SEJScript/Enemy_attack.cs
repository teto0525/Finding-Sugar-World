using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_attack : MonoBehaviour
{
    private Animator anim;
    public GameObject DeathEffect;
<<<<<<< Updated upstream
    private float delay = 0.5f;
=======
    bool isDie = false;
   
    public AudioClip dieAudio; //몬스터죽을때
  
    AudioSource audioSource;

>>>>>>> Stashed changes

    void Start()
    {
     
    }

    void Update()
    {
        anim = GetComponent<Animator>();
  
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
                if (isDie == true)
                {
                    GameObject death = Instantiate(DeathEffect);
                    death.transform.position = transform.position;
                    
                }
            Destroy(this.gameObject, 0.5f);

        }
        else
            {
                 anim.SetBool("IsAttack", false);
             }

        //오디오 함수
        void SoundAttacked()
        {

          
            dieAudio.PlayOneShot(isDie);
            //죽었을때 오디오
            AudioSource dieAudio = gameObject.GetComponent<AudioSource>();
            dieAudio.Play();



        }
     }
        
}

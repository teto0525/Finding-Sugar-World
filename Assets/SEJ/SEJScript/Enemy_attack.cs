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
   
    public AudioClip dieAudio; //����������
  
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
        //1. �ε��� ���ӿ�����Ʈ �ı�
        // Destroy(collision.gameObject);
        //2. ���� ���� ������Ʈ �ı�
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

        //����� �Լ�
        void SoundAttacked()
        {

          
            dieAudio.PlayOneShot(isDie);
            //�׾����� �����
            AudioSource dieAudio = gameObject.GetComponent<AudioSource>();
            dieAudio.Play();



        }
     }
        
}

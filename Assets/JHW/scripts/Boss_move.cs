using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_move : MonoBehaviour
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

        if (collision.collider.tag == "Player")
        {
            anim.SetBool("attack", true);

            if (collision.collider.tag == "Sword")
            {
                //anim.Play("die");

                anim.SetBool("death", true);
                // Destroy(gameObject);
            }
        }
        else
        {
            anim.SetBool("attack", false);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_State : MonoBehaviour
{

    public readonly int hashTrace = Animator.StringToHash("TRACE");
    public readonly int hashAttack = Animator.StringToHash("ATTACK");
    //private readonly int hashHit = Animator.StringToHash("Hit");
    public readonly int hashDie = Animator.StringToHash("DIE");
    //private readonly int hashPlayerDie = Animator.StringToHash("PlayerDie");
    //private readonly int hashAniSpeed = Animator.StringToHash("AniSpeed");

    private Animator anim;
    public bool isDie = false;
   
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
            anim.SetBool("ATTACK", true);

 
        }


        else if (collision.collider.tag == "Sword")
        {
            anim.SetBool("DIE", true);
            isDie = true;
        }
    }
}

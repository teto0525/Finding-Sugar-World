using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class hp : MonoBehaviour
{

    public float moveSpeed = 10;

    [SerializeField]
    private Slider hpbar;

    private float iniHP = 100.0f;
    private float currHP = 100.0f;

    private Animator anim;

    void Start()
    {
        currHP = iniHP;
        hpbar.value = (float)currHP / (float)iniHP;

    }

    void Update()
    {
       
        HandleHP();
    }

    void HandleHP()
    {
        hpbar.value = Mathf.Lerp(hpbar.value, (float)currHP / (float)iniHP, Time.deltaTime * 10);
    }

    //===================================================================================
    void OncollisionEnter(Collider coll)
    {

        // 만약 빨간약 먹으면
        if (coll.gameObject.CompareTag("Potion_Purple"))
        {

            //hp가 회복된다
            currHP += 30.0f;
        }
    }
    // Enemy 피격
    private void OnTriggerEnter(Collision coll)
    {
        //충돌한 collider가 Enemy이면 HP 차감
        if (currHP >= 0.0f && coll.collider.CompareTag("Enemy"))
        {
            // 충격 모션
            anim.SetTrigger("gotHit");
            this.transform.Translate(Vector3.back * 10.0f * moveSpeed * Time.deltaTime);

            currHP -= 10.0f;
        }

        if (currHP >= 0.0f && coll.collider.CompareTag("Boss"))
        {
            BossAttack();
        }
        if (currHP <= 0.0f)
        {
            PlayerDie();
        }

    }

    // Boss
    void BossAttack()
    {
        anim.SetTrigger("gotHit");
        this.transform.Translate(Vector3.back * 10.0f * moveSpeed * Time.deltaTime);

        currHP -= 30.0f;
        Debug.Log("Player hp = {iniHP - currHp}");
    }
}
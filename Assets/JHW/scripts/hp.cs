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

        // ���� ������ ������
        if (coll.gameObject.CompareTag("Potion_Purple"))
        {

            //hp�� ȸ���ȴ�
            currHP += 30.0f;
        }
    }
    // Enemy �ǰ�
    private void OnTriggerEnter(Collision coll)
    {
        //�浹�� collider�� Enemy�̸� HP ����
        if (currHP >= 0.0f && coll.collider.CompareTag("Enemy"))
        {
            // ��� ���
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerCtrl : MonoBehaviour
{

    // �÷��̾� rigidbody ����
    public Rigidbody rb;

    // �÷��̾� ������ (�յ��¿� + ��)
    private float h;
    private float v;
    private float r;
    [Range(5.0f, 20.0f)]
    public float moveSpeed = 8.0f;
    [Range(100.0f, 200.0f)]
    public float turnSpeed = 200f;

    // �÷��̾� �ִϸ��̼�
    private Animator anim;

    //�ʱ� ����
    private readonly float iniHP = 100.0f;
    //���� ����
    public float currHP;
    //�׾��� �� �׾���
    bool isAlive =  true;
    //���� ����Ʈ
    public GameObject Deatheffect;
    public GameObject DeathPos;
    public float dieDelay = 0.5f;

    // ����
    // public SoundManager soundmanager;

    //gameCtrl
    public GameCtrlNew gameCtrl;

    //������ ����
    //WeaponManager
    public WeaponManager weaponSwitch;

    //public Transform cam;
    //public Transform PlayerPos;

    private Vector3 originPos;

    public hp hpUI;

    CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();

        //rb
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        //HP  �ʱ�ȭ
        currHP = iniHP;

        originPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        //ġƮŰ ���
        //�ױ�
        if (Input.GetKey(KeyCode.Z))
        {
            //PlayerDie();
            anim.SetTrigger("gotHit");
        }

        if (isAlive == true)
        {
            // �÷��̾� ������ ����
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            r = Input.GetAxis("Mouse X");


            //Vector3 dir = ((Vector3.right * h) + (Vector3.forward * v));
            //transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
            Vector3 dir = ((transform.right * h) + (transform.forward * v));
            cc.Move(dir.normalized * moveSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up * turnSpeed * r * Time.deltaTime);

            //cam.position = Vector3.Lerp(cam.position, PlayerPos.position, 5 * Time.deltaTime);
            //cam.rotation = Quaternion.Lerp(cam.rotation, PlayerPos.rotation, 5 * Time.deltaTime);

            //�ڷ� �̵��� ������ �̵� �Ұ���
            if (v <= 0)
            {
                h = 0;
            }

            PlayerAnim();

            // ġƮŰ
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SwitchWeapons();
            }
        }
    }
    

    bool isMove;
    void PlayerAnim()
    {
        if (v < 0.0f)
        {
            if(isMove ==false)
            { 
                anim.SetTrigger("Walk");
                isMove = true;
            }
        }
        else if (v > 0.0f)
        {
            if (isMove == false)
            {
                anim.SetTrigger("Walk");
                isMove = true;
            }
            //v = 0;
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Attack");
            SoundManager.instance.Playerattack();
        }
        else
        {
            if(isMove == true)
            {
                anim.SetTrigger("Idle");
                isMove = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // ���� �Ķ��� ������
        if (other.gameObject.CompareTag("Potion_Blue"))
        {
            // ���Ⱑ �ٲ��
            SwitchWeapons();
            SoundManager.instance.PickItem_B();
        }

        // ���� ������ ������
        if (other.gameObject.CompareTag("Potion_Red"))
        { 
    
            //hp�� ȸ���ȴ�
            currHP += 30.0f;
            hpUI.SetHp(currHP);
            SoundManager.instance.PickItem_R();
        }

        // ���� ����� ������
        if (other.gameObject.CompareTag("Potion_Purple"))
        { 
            // Ư�� ��ҷ� �̵��Ѵ�
            Teleport();
            SoundManager.instance.PickItem_P();
        }
        //������ ����=============
        if (other.gameObject.name.Contains("Coin")||other.gameObject.name.Contains("Gold")||other.gameObject.name.Contains("coin"))
        {
            ScoreManager.score += 200;
            SoundManager.instance.PickItem_Coin();
        }
        //========================

        // �ڷ���Ʈ
        void Teleport()
        {
            transform.position = originPos;
        }



        //���� ���������� ����ϸ�
        //YouWin ������ ��ȯ�ȴ�
        if (other.gameObject.CompareTag("SugarWorld"))
        { 
            SceneManager.LoadScene("YouWin");
        }

    }
    
    public void SwitchWeapons()
    {
        StartCoroutine(weaponSwitch.SwitchDelay());
        // ���� �ٲ�� �Ҹ�
        //SoundManager.instance.Blue;
    }


    // Enemy �ǰ�
    private void OnCollisionEnter(Collision collision)
    {
        //�浹�� collider�� Enemy�̸� HP ����
        if (currHP >= 0.0f && collision.gameObject.CompareTag("Enemy"))
        {
            // ��� ���
            anim.SetTrigger("gotHit");
            this.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

            //currHP -= 10.0f;
            hpUI.SetHp(currHP);
        }

        if (currHP >= 0.0f && collision.gameObject.CompareTag("Boss"))
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
        hpUI.SetHp(currHP);
        Debug.Log("Player hp = {iniHP - currHp}");
    }

    //void PlayerDieAnim()
    //{
    //Debug.Log("Player Die!");

    // anim.SetFloat("Speed", 1.0f);
    //anim.SetTrigger("Die");

    //Vector3 dir = DeathPos.transform.position;
    //Instantiate(Deatheffect, dir, Quaternion.identity);

    // PlayerDie();
    // }
    // public IEnumerator DieDelay()
    //{
    //isDie = true;
    //PlayerDieAnim();

    //yield return new WaitForSeconds(dieDelay);

    //PlayerDie();
    //isDie = false;
    //}

    //Player ���ó��
    //public void PlayerDie()
    //{

    //    Debug.Log("Player Die!");

    //    anim.SetFloat("Speed", 1.0f);
    //    anim.SetTrigger("Die");

    //    Vector3 dir = DeathPos.transform.position;
    //    Instantiate(Deatheffect, dir, Quaternion.identity);

    //    // ���� �ִٰ� �÷��̾� ���� �������
    //    t
    //    gameObject.GetComponent<CapsuleCollider>().enabled = false;

    //    gameObject.SetActive(false);

    //    // ���� ���¿��� ��� default -> �� �� �ִٰ� �� ��ȯ�ϱ�� �ٲ۴�

    //    // Delay�� ��ٰ� ȭ�� ��ȯ�ǰ� �ʹ�
    //    // ? �ڷ�ƾ �Լ� �̿� Ȥ�� Invoke("gameCtrl.PlayerDie")
    //    gameCtrl.PlayerDie();

    //}

    public void PlayerDie()
    {
        isAlive = false;

        Debug.Log("Player Die!");

        anim.SetFloat("Speed", 0.5f);
        anim.SetTrigger("Die");

        Vector3 dir = DeathPos.transform.position;
        Instantiate(Deatheffect, dir, Quaternion.identity);

        // ���� �ִٰ� �÷��̾� ���� �������
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        EnableRagdoll();

        //gameObject.SetActive(false);

        // ���� ���¿��� ��� default -> �� �� �ִٰ� �� ��ȯ�ϱ�� �ٲ۴�

        // Delay�� ��ٰ� ȭ�� ��ȯ�ǰ� �ʹ�
        // ? �ڷ�ƾ �Լ� �̿� Ȥ�� Invoke("gameCtrl.PlayerDie")
        gameCtrl.PlayerDie();

    }

    // ragdoll �����
    void EnableRagdoll()
    {
        rb.isKinematic = true;
        rb.detectCollisions = false;
    }

}

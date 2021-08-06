using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{

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

    //gameCtrl
    public GameCtrlNew gameCtrl;

    //������ ����
    //WeaponManager
    public WeaponManager weaponSwitch;
 


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        //HP  �ʱ�ȭ
        currHP = iniHP;

    }

    // Update is called once per frame
    void Update()
    {
        // �÷��̾� ������ ����
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");


        Vector3 dir = ((Vector3.right * h) + (Vector3.forward * v));
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * turnSpeed * r * Time.deltaTime);

        //�ڷ� �̵��� ������ �̵� �Ұ���
        if (v <= 0)
        {
            h = 0;
        }

        PlayerAnim();


        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapons();
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
        }

        // ���� ������ ������
        if (other.gameObject.CompareTag("Potion_Red"))
        { 
    
            //hp�� ȸ���ȴ�
            currHP += 30.0f;
        }

        // ���� ����� ������
        if (other.gameObject.CompareTag("Potion_Purple"))
        { 
            // Ư�� ��ҷ� �̵��Ѵ�
            Teleport();
        }

        // �ڷ���Ʈ
        void Teleport()
        {
            transform.position = new Vector3(-77, 5, -34);
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
    }


    // Enemy �ǰ�
    private void OnCollisionEnter(Collision other)
    {
        //�浹�� collider�� Enemy�̸� HP ����
        if (currHP >= 0.0f && other.gameObject.CompareTag("Enemy"))
        {
            // ��� ���
            anim.SetTrigger("gotHit");
            this.transform.Translate(Vector3.back * 10.0f * moveSpeed * Time.deltaTime);

            currHP -= 10.0f;
        }

        if (currHP >= 0.0f && other.gameObject.CompareTag("Boss"))
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



    //Player ���ó��
    public void PlayerDie()
    {
        Debug.Log("Player Die!");

        anim.SetFloat("Speed", 1.0f);
        anim.SetTrigger("Die");

        // Delay�� ��ٰ� ȭ�� ��ȯ�ǰ� �ʹ�
        // ? �ڷ�ƾ �Լ� �̿� Ȥ�� Invoke("gameCtrl.PlayerDie")
        gameCtrl.PlayerDie();

    }

}

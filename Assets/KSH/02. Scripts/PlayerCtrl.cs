using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerCtrl : MonoBehaviour
{

    // 플레이어 rigidbody 설정
    public Rigidbody rb;

    // 플레이어 움직임 (앞뒤좌우 + 턴)
    private float h;
    private float v;
    private float r;
    [Range(5.0f, 20.0f)]
    public float moveSpeed = 8.0f;
    [Range(100.0f, 200.0f)]
    public float turnSpeed = 200f;

    // 플레이어 애니메이션
    private Animator anim;

    //초기 생명값
    private readonly float iniHP = 100.0f;
    //현재 생명값
    public float currHP;
    //죽었나 안 죽었나
    bool isAlive =  true;
    //죽음 이펙트
    public GameObject Deatheffect;
    public GameObject DeathPos;
    public float dieDelay = 0.5f;

    // 사운드
    // public SoundManager soundmanager;

    //gameCtrl
    public GameCtrlNew gameCtrl;

    //아이템 변수
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

        //HP  초기화
        currHP = iniHP;

        originPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

       
        //치트키 목록
        //죽기
        if (Input.GetKey(KeyCode.Z))
        {
            //PlayerDie();
            anim.SetTrigger("gotHit");
        }

        if (isAlive == true)
        {
            // 플레이어 움직임 구현
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            r = Input.GetAxis("Mouse X");


            Vector3 dir = ((Vector3.right * h) + (Vector3.forward * v));
            transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
            //Vector3 dir = ((transform.right * h) + (transform.forward * v));
            //cc.Move(dir.normalized * moveSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up * turnSpeed * r * Time.deltaTime);
            

            //cam.position = Vector3.Lerp(cam.position, PlayerPos.position, 5 * Time.deltaTime);
            //cam.rotation = Quaternion.Lerp(cam.rotation, PlayerPos.rotation, 5 * Time.deltaTime);

            //뒤로 이동시 옆으로 이동 불가능
            if (v <= 0)
            {
                h = 0;
            }

            PlayerAnim();

            // 치트키
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SwitchWeapons();
            }
        }
    }

    private void LateUpdate()
    {
        rb.velocity = Vector3.zero;
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
        // 만약 파란약 먹으면
        if (other.gameObject.CompareTag("Potion_Blue"))
        {
            // 무기가 바뀐다
            SwitchWeapons();
            SoundManager.instance.PickItem_B();
        }

        // 만약 빨간약 먹으면
        if (other.gameObject.CompareTag("Potion_Red"))
        { 
    
            //hp가 회복된다
            currHP += 30.0f;
            hpUI.SetHp(currHP);
            SoundManager.instance.PickItem_R();
        }

        // 만약 보라약 먹으면
        if (other.gameObject.CompareTag("Potion_Purple"))
        { 
            // 특정 장소로 이동한다
            SoundManager.instance.PickItem_P();
            StartCoroutine(Teleport());
        }
        //정형우 수정=============
        if (other.gameObject.name.Contains("Coin")||other.gameObject.name.Contains("Gold")||other.gameObject.name.Contains("coin"))
        {
            ScoreManager.score += 200;
            SoundManager.instance.PickItem_Coin();
        }
        //========================


        //만약 최종관문을 통과하면
        //YouWin 씬으로 전환된다
        if (other.gameObject.CompareTag("SugarWorld"))
        { 
            SceneManager.LoadScene("YouWin");
        }

    }



    // 텔레포트
    IEnumerator Teleport()
    {
        //cc.enabled = false;
        yield return new WaitForSeconds(0.1f);
        transform.position = originPos;
        //cc.enabled = true;
    }

    public void SwitchWeapons()
    {
        StartCoroutine(weaponSwitch.SwitchDelay());
        // 무기 바뀌는 소리
        //SoundManager.instance.Blue;
    }


    // Enemy 피격
    private void OnCollisionEnter(Collision collision)
    {
        //충돌한 collider가 Enemy이면 HP 차감
        if (currHP >= 0.0f && collision.gameObject.CompareTag("Enemy"))
        {
            // 충격 모션
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

    //Player 사망처리
    //public void PlayerDie()
    //{

    //    Debug.Log("Player Die!");

    //    anim.SetFloat("Speed", 1.0f);
    //    anim.SetTrigger("Die");

    //    Vector3 dir = DeathPos.transform.position;
    //    Instantiate(Deatheffect, dir, Quaternion.identity);

    //    // 몇초 있다가 플레이어 모델이 사라진다
    //    t
    //    gameObject.GetComponent<CapsuleCollider>().enabled = false;

    //    gameObject.SetActive(false);

    //    // 죽음 상태에서 모두 default -> 몇 초 있다가 씬 전환하기로 바꾼다

    //    // Delay를 줬다가 화면 전환되고 싶다
    //    // ? 코루틴 함수 이용 혹은 Invoke("gameCtrl.PlayerDie")
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

        // 몇초 있다가 플레이어 모델이 사라진다
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        EnableRagdoll();

        //gameObject.SetActive(false);

        // 죽음 상태에서 모두 default -> 몇 초 있다가 씬 전환하기로 바꾼다

        // Delay를 줬다가 화면 전환되고 싶다
        // ? 코루틴 함수 이용 혹은 Invoke("gameCtrl.PlayerDie")
        gameCtrl.PlayerDie();

    }

    // ragdoll 만들기
    void EnableRagdoll()
    {
        rb.isKinematic = true;
        rb.detectCollisions = false;
    }

}

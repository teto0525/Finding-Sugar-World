using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{

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

    //gameCtrl
    public GameCtrlNew gameCtrl;

    //아이템 변수
    //WeaponManager
    public WeaponManager weaponSwitch;
 


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        //HP  초기화
        currHP = iniHP;

    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어 움직임 구현
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");


        Vector3 dir = ((Vector3.right * h) + (Vector3.forward * v));
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * turnSpeed * r * Time.deltaTime);

        //뒤로 이동시 옆으로 이동 불가능
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
        // 만약 파란약 먹으면
        if (other.gameObject.CompareTag("Potion_Blue"))
        {
            // 무기가 바뀐다
            SwitchWeapons();
        }

        // 만약 빨간약 먹으면
        if (other.gameObject.CompareTag("Potion_Red"))
        { 
    
            //hp가 회복된다
            currHP += 30.0f;
        }

        // 만약 보라약 먹으면
        if (other.gameObject.CompareTag("Potion_Purple"))
        { 
            // 특정 장소로 이동한다
            Teleport();
        }

        // 텔레포트
        void Teleport()
        {
            transform.position = new Vector3(-77, 5, -34);
        }



        //만약 최종관문을 통과하면
        //YouWin 씬으로 전환된다
        if (other.gameObject.CompareTag("SugarWorld"))
        { 
            SceneManager.LoadScene("YouWin");
        }

    }
    
    public void SwitchWeapons()
    {
        StartCoroutine(weaponSwitch.SwitchDelay());
    }


    // Enemy 피격
    private void OnCollisionEnter(Collision other)
    {
        //충돌한 collider가 Enemy이면 HP 차감
        if (currHP >= 0.0f && other.gameObject.CompareTag("Enemy"))
        {
            // 충격 모션
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



    //Player 사망처리
    public void PlayerDie()
    {
        Debug.Log("Player Die!");

        anim.SetFloat("Speed", 1.0f);
        anim.SetTrigger("Die");

        // Delay를 줬다가 화면 전환되고 싶다
        // ? 코루틴 함수 이용 혹은 Invoke("gameCtrl.PlayerDie")
        gameCtrl.PlayerDie();

    }

}

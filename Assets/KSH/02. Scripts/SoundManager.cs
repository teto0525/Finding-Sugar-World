using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    new AudioSource audio;

    //BGM 요소들  //배경음 클립
    //public AudioClip DGbgm;
    //public AudioClip Mbgm;
    //public AudioClip Lbgm;
    //public AudioClip Wbgm;


    //EFT 요소들  //효과음 클립

    public AudioClip AttackA; //플레이어 공격
    public AudioClip Blue;//무기변경(파란물약)
    public AudioClip Purple;//포탈 (보라물약)
    public AudioClip Red; // 하트 (빨간물약)
    public AudioClip Chestdie; // 체스트몬스터 죽음
    public AudioClip EnemDie; // 기타 잡몹 죽음 
    public AudioClip Obs2die;// 비홀더몬스터 죽음
    public AudioClip Bossdie;// 보스죽음
    public AudioClip Coin;// 코인먹음
    public AudioClip Gothit; //플레이어 공격당함





    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audio = this.gameObject.GetComponent<AudioSource>();
    }

    public void Playerattack()
    {
        audio.PlayOneShot(AttackA);
    }

    public void PickItem_B()
    {
        audio.PlayOneShot(Blue);
    }

    public void PickItem_P()
    {
        audio.PlayOneShot(Purple);
    }

    public void PickItem_R()
    {
        audio.PlayOneShot(Red);
    }

    public void PickItem_Coin()
    {
        audio.PlayOneShot(Coin);
    }

    public void ChestDie()
    {
        audio.PlayOneShot(Chestdie);
    }


    public void EnemyDie()
    {
        audio.PlayOneShot(EnemDie);
    }

    public void BossDie()
    {
        audio.PlayOneShot(Bossdie);
    }

    public void PlayerGotHit()
    {
        audio.PlayOneShot(Gothit);
    }
}

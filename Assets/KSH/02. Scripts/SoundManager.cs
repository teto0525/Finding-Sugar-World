using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    new AudioSource audio;

    //BGM ��ҵ�  //����� Ŭ��
    //public AudioClip DGbgm;
    //public AudioClip Mbgm;
    //public AudioClip Lbgm;
    //public AudioClip Wbgm;


    //EFT ��ҵ�  //ȿ���� Ŭ��

    public AudioClip AttackA; //�÷��̾� ����
    public AudioClip Blue;//���⺯��(�Ķ�����)
    public AudioClip Purple;//��Ż (���󹰾�)
    public AudioClip Red; // ��Ʈ (��������)
    public AudioClip Chestdie; // ü��Ʈ���� ����
    public AudioClip EnemDie; // ��Ÿ ��� ���� 
    public AudioClip Obs2die;// ��Ȧ������ ����
    public AudioClip Bossdie;// ��������
    public AudioClip Coin;// ���θ���
    public AudioClip Gothit; //�÷��̾� ���ݴ���





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

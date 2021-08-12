using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundM : MonoBehaviour
{

    public AudioClip sound_; // ����� �Ҹ�
    AudioSource SoundEffect;
    public static SoundM instance;

    private void Awake()
    {
        if (SoundM.instance == null)
        {
            SoundM.instance = this; // �ڱ� �ڽ� ���
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SoundEffect = this.gameObject.GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        SoundEffect.PlayOneShot(sound_); // �ش� ���� ���
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

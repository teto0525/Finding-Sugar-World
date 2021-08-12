using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundM : MonoBehaviour
{

    public AudioClip sound_; // 재생할 소리
    AudioSource SoundEffect;
    public static SoundM instance;

    private void Awake()
    {
        if (SoundM.instance == null)
        {
            SoundM.instance = this; // 자기 자신 담기
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SoundEffect = this.gameObject.GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        SoundEffect.PlayOneShot(sound_); // 해당 사운드 재생
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

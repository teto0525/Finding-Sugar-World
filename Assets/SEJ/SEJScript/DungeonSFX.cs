using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//던전 배경음악

public class DungeonSFX : MonoBehaviour
{
    //던전에 사용할 오디오 음원
    public AudioClip dgAudio;
  
    
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
    }


    // Update is c며alled once per frame
    void Update()
    {
        
    }
}

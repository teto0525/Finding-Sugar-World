using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarWorldSFX : MonoBehaviour
{
    public AudioClip swAudio;
    // Start is called before the first frame update
    void Awake()
    {
        AudioSource audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

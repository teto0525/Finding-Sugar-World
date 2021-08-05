using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSFX : MonoBehaviour
{
    public AudioClip mainAudio;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

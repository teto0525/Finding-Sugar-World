using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBox : MonoBehaviour
{
    public bool destroyCoin=false;
    private Transform PlayerTR;
    public GameObject hit_effect;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerTR = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name.Contains("Player"))
    //    {
    //        destroyCoin = true;
    //        ScoreManager.score -= 700;
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            destroyCoin = true;
            ScoreManager.score -= 700;

            GameObject Hit_effect = Instantiate(hit_effect);
            Hit_effect.transform.position = PlayerTR.transform.position;
            ParticleSystem ps = Hit_effect.GetComponent<ParticleSystem>();
            ps.Play();

            Destroy(Hit_effect, 3);
        }

    }
}

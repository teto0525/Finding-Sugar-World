using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gold_explo : MonoBehaviour
{
    public GameObject ExploEFT;


    BlackBox blockBlock;
    bool isDestroy; 

    // Start is called before the first frame update
    void Start()
    {
        blockBlock = GameObject.Find("Obstacle_G").GetComponent<BlackBox>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDestroy == false && blockBlock.destroyCoin==true)
        {
            ShowDestoryEft();
            isDestroy = true;
        }
    }
    
    public void ShowDestoryEft()
    {
        Destroy(gameObject);

        GameObject Explosion = Instantiate(ExploEFT);
        Explosion.transform.position = transform.position;
        ParticleSystem ps = Explosion.GetComponent<ParticleSystem>();
        ps.Play();

        Destroy(ExploEFT, 3);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Player"))
        {
            Destroy(gameObject);
        }
    }




}

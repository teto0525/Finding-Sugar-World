using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveItem : MonoBehaviour
{
    public GameObject EffectPos;
    public GameObject ItemEffect;


    // Start is called before the first frame update
    void Start()
    {
        

    }


    void OnTriggerEnter(Collider other)
    {
        Vector3 dir = EffectPos.transform.position;

        if (other.gameObject.CompareTag("Player") == true)
        {
            Instantiate(ItemEffect, dir, Quaternion.identity);
            //충돌한 게임 오브젝트 삭제
            Destroy(this.gameObject);
        }

        if (other.gameObject.name.Contains("Coin") || other.gameObject.name.Contains("Gold") || other.gameObject.name.Contains("coin"))
        {
            ScoreManager.score += 200;
        }

    }
    // Update is called once per frame
    void Update()
    {
    }
}

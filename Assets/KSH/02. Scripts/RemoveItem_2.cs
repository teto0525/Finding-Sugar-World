using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveItem_2 : MonoBehaviour
{
    public GameObject EffectPos;
    // public GameObject ItemEffect;
    public GameObject CoinEffect;


    // Start is called before the first frame update
    void Start()
    {
    }


    void OnCollisionEnter(Collision coll)
    {
      
        if (coll.collider.CompareTag("Player") == true)
        {
            ContactPoint cp = coll.GetContact(0);
            Quaternion rot = Quaternion.LookRotation(cp.normal);
            // GameObject effect = Instantiate(ItemEffect, cp.point, rot);

            Vector3 dir = EffectPos.transform.position;
            Instantiate(CoinEffect, dir, Quaternion.identity);
            Instantiate(CoinEffect, dir, Quaternion.identity);
            //충돌한 게임 오브젝트 삭제
            Destroy(this.gameObject);

            Destroy(gameObject);
            Destroy(CoinEffect, 1.0f);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}

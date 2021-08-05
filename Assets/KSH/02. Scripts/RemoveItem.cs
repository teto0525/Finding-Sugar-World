using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveItem : MonoBehaviour
{
    public GameObject EffectPos;
    public GameObject ItemEffect;
    public GameObject ItemType;


    // Start is called before the first frame update
    void Start()
    {
        

    }


    void OnCollisionEnter(Collision coll)
    {
        Vector3 dir = EffectPos.transform.position;

        if (coll.collider.CompareTag("Player") == true)
        {
            Instantiate(ItemEffect, dir, Quaternion.identity);
            //�浹�� ���� ������Ʈ ����
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

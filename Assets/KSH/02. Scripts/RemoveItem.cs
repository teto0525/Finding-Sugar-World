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
            //�浹�� ���� ������Ʈ ����
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

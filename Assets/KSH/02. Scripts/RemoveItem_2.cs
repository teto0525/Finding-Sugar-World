using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveItem_2 : MonoBehaviour
{
    public GameObject ItemEffect;

    // Start is called before the first frame update
    void Start()
    {
    }


    void OnCollisionEnter(Collision coll)
    {
      
        if (coll.collider.CompareTag("Player") == true)
        {
            ContactPoint cp = coll.GetContact(0);
            Quaternion rot = Quaternion.LookRotation(-cp.normal);

            GameObject effect = Instantiate(ItemEffect, cp.point, rot);
            Destroy(gameObject);
            Destroy(effect, 1.0f);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}

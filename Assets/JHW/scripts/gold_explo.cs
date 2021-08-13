using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gold_explo : MonoBehaviour
{
    public GameObject ExploEFT;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (GetComponent<PlayerCtrl>().goldExplo==true)
        {
        Destroy(gameObject);
        GameObject explo = Instantiate(ExploEFT);
        explo.transform.position = transform.position;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeMove_Main : MonoBehaviour
{

    // ���콺 ȸ�� ������ ��
    float rotSpeed = 1.0f;
    RaycastHit hit;

    // Start is called before the first frame update
    private Animator anim;


    void Start()
    {
      
    }

    void SetAnimation()
    {
        Vector3 mousePos = Input.mousePosition;

        // ���� ���콺 �������� StartButton�̸�
        if (Input.GetMouseButtonDown(0))
       {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                anim.SetBool("Welcome", true);
            }
            else
            {
                anim.SetBool("Welcome", false);
            }
       }
    }

    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X");

        transform.Rotate(Vector3.up * rotSpeed * MouseX);
    }

}

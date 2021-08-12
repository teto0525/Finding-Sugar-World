using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
	public float switchDelay = 0.5f;
	public GameObject[] weapon;

	// ���� �ٲ� ����Ʈ ȿ��
	public GameObject effectPos;
	public GameObject chEffect;

	private int index = 0;
	private bool isSwitching = false;
	//�����
	AudioSource audioSource;
	public AudioSource SWaudio;//����ġ����
	public AudioSource ATaudio;//����
	public AudioSource TPaudio;//�ڷ���Ʈ
	public AudioSource Heartaudio;//��Ʈ����





	void Start()
	{
		InitializeWeapon();
	}

	private void InitializeWeapon()
	{
		for (int i = 0; i < weapon.Length; i++)
		{
			weapon[1].SetActive(false);
		}
		weapon[0].SetActive(true);
		index = 0;
	}
	void ChangeEffect()
    {
		if(isSwitching == true)
        {
			Vector3 dir = effectPos.transform.position;
			Instantiate(chEffect, dir, Quaternion.identity);
			SWaudio = gameObject.GetComponent<AudioSource>(); //����ġ���� �����
			SWaudio.Play();
		}
    }

	public IEnumerator SwitchDelay()
	{
		isSwitching = true;
		ChangeEffect();

		yield return new WaitForSeconds(switchDelay);

		SwitchWeapons();
		isSwitching = false;
	}

	private void SwitchWeapons()
	{
		//for (int i = 0; i < weapon.Length; i++)
		//{
		//	weapon[i].SetActive(false);
		//}

		int newIdex = index + 1;
		newIdex %= weapon.Length;

		weapon[index].SetActive(false);

		weapon[newIdex].SetActive(true);

		index = newIdex;

		//�ʱ� ����� ���� �ڸ��� ��ġ
		//weapon[0].transform.position = weapon[newIndex].transform.position;
	}

}

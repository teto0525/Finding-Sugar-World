using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
	public float switchDelay = 0.5f;
	public GameObject[] weapon;

	// 무기 바뀔때 이펙트 효과
	public GameObject effectPos;
	public GameObject chEffect;

	private int index = 0;
	private bool isSwitching = false;
	//오디오
	AudioSource audioSource;
	public AudioSource SWaudio;//스위치웨폰
	public AudioSource ATaudio;//공격
	public AudioSource TPaudio;//텔레포트
	public AudioSource Heartaudio;//하트증가





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
			SWaudio = gameObject.GetComponent<AudioSource>(); //스위치웨폰 오디오
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

		//초기 무기와 같은 자리에 위치
		//weapon[0].transform.position = weapon[newIndex].transform.position;
	}

}

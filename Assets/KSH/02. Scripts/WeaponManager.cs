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

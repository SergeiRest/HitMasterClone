using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
	[SerializeField] private Weapon[] _weapons;

	public Weapon SelectWeapon()
	{
		int num = Random.Range(0, _weapons.Length);
		_weapons[num].gameObject.SetActive(true);
		return _weapons[num];
	}
}

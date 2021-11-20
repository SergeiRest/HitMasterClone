using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] private Bullet _bullet;

	public void Shot(Vector3 target)
	{
		var obj = Instantiate(_bullet, transform.position, Quaternion.identity);
		obj.Flight(target);
	}
}

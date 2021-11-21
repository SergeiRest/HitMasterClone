using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] private Bullet _bullet;
	[SerializeField] private ObjectPool _objectPool = null;
	private const string BULLETS_POOL = "Bullet";

	public void Shot(Vector3 target)
	{
		Bullet obj = _objectPool.GetBullet(BULLETS_POOL);
		obj.transform.position = transform.position;
		obj.transform.SetParent(_objectPool.transform);
		obj.ObjectPool = _objectPool;
		obj.gameObject.SetActive(true);
		obj.Flight(target);
	}
}

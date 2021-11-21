using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	[SerializeField] private Bullet _bullet;
	private Dictionary<string, Bullet> _prefabPool = new Dictionary<string, Bullet>();
	private Dictionary<string, Queue<Bullet>> _bulletPool = new Dictionary<string, Queue<Bullet>>();
	private void Awake()
	{
		_prefabPool.Add(_bullet.name, _bullet);
		_bulletPool.Add(_bullet.name, new Queue<Bullet>());
		Debug.Log(_prefabPool.Keys);
	}
	public Bullet GetBullet(string poolName)
	{
		if(_bulletPool[poolName].Count > 0)
		{
			return _bulletPool[poolName].Dequeue();
		}

		return Instantiate(_prefabPool[poolName]);
	}

	public void ReturnBullet(string poolName, Bullet bullet)
	{
		_bulletPool[poolName].Enqueue(bullet);
	}
}

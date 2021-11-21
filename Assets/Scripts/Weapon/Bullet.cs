using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private float _speed = 0.2f;
	public ObjectPool ObjectPool = null;
	public const string POOL_NAME = "Bullet";
	public async void Flight(Vector3 target) // Полёт пули
	{
		while(this.transform.position != target)
		{
			transform.position = Vector3.MoveTowards(transform.position, target, _speed);
			await Task.Delay(1);
		}
		gameObject.SetActive(false);
		ObjectPool.ReturnBullet(POOL_NAME, this);
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.GetComponentInParent(typeof(Enemy)))
		{
			var en = other.GetComponentInParent<Enemy>();
			en.TakeDamage();
		}
	}
}

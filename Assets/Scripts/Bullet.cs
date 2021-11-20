using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private float _speed = 0.2f;

	public async void Shoot(Vector3 shotPoint)
	{
		while(this.transform.position != shotPoint)
		{
			transform.position = Vector3.MoveTowards(transform.position, shotPoint, _speed);
			await Task.Delay(1);
		}
		
	}
}

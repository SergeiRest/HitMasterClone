using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private float _speed = 0.2f;

	public async void Flight(Vector3 target) // Полёт пули
	{
		while(this.transform.position != target)
		{
			transform.position = Vector3.MoveTowards(transform.position, target, _speed);
			await Task.Delay(1);
		}
		
	}
}

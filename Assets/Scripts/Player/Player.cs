using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private Bullet _bullet;
	[SerializeField] private Movement _movementObject;
	private Camera _camera;

	private void Start()
	{
		_camera = Camera.main;
	}
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			switch (_movementObject.StateMachine.GetPlayerState())
			{
				case (PlayerStates.Idle):
					_movementObject.StartMove();
					break;
				case (PlayerStates.Running):
					Debug.Log("Бежит");
					break;
				case (PlayerStates.Shooting):
					RaycastHit ray;
					if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out ray))
					{
						Debug.Log(ray.transform.position);
						var obj = Instantiate(_bullet, _movementObject.transform.position, Quaternion.identity, transform.parent);
						obj.Shoot(ray.transform.position);
					}
					break;
			}
		}
	}
}

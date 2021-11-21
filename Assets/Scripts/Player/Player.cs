using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private Weapon _weapon;
	[SerializeField] private Movement _movementObject;

	public Movement MoveObject
	{
		get
		{
			return _movementObject;
		}
	}
	private void Awake()
	{
		_movementObject.Check += CheckWaypoint;
	}

	private void Update()
	{
		//RaycastHit rd;
		//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		//if (Physics.Raycast(ray, out rd))
		//{
		//	Debug.DrawLine(_movementObject.transform.position, rd.transform.position);
		//}

		if (Input.GetKeyDown(KeyCode.Mouse0))
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
					if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out ray))
					{
						Debug.DrawLine(_movementObject.transform.position, ray.transform.position);
						_weapon.Shot(ray.transform.position);
					}
					break;
			}
		}
	}

	private void CheckWaypoint(Waypoint current)
	{
		if (current.EnemiesPool.GetEnemiesLength() > 0)
			current.Init(this);
	}
}

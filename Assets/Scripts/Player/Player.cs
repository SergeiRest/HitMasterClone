using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private Weapon _weapon;
	[SerializeField] private Movement _movementObject;

	
	private void Update()
	{
		RaycastHit rd;
		if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out rd))
		{
			Debug.DrawLine(_movementObject.transform.position, rd.transform.position);
		}
		
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
					if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out ray))
					{
						Debug.DrawLine(_movementObject.transform.position, ray.transform.position);
						_weapon.Shot(ray.transform.position);
					}
					break;
			}
		}
	}
}

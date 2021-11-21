using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private Movement _movementObject;
	[SerializeField] private PlayerAnims _animations;
	[SerializeField] private Level _level;
	[SerializeField] private WeaponSelector _selector;
	private Weapon _weapon;
	private PlayerStatesBehaviour _stateMachine = new PlayerStatesBehaviour();

	public PlayerStatesBehaviour StateMachine
	{
		get
		{
			return _stateMachine;
		}
	}

	private void Awake()
	{
		_movementObject.Finished += _level.Reload;
		_movementObject.Check += CheckWaypoint;
	}

	private void Start()
	{
		_weapon = _selector.SelectWeapon();
		_stateMachine.Init();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			switch (_stateMachine.GetPlayerState())
			{
				case (PlayerStates.Idle):
					_movementObject.StartMove();
					_stateMachine.RunningState();
					_animations.SetRunAnimation();
					break;
				case (PlayerStates.Running):
					Debug.Log("Бежит");
					break;
				case (PlayerStates.Shooting):
					Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					RaycastHit pos;
					Vector3 shotPosition;
					if (Physics.Raycast(ray, out pos))
					{
						shotPosition = new Vector3(pos.point.x, pos.point.y, pos.point.z);
						_weapon.Shot(shotPosition);
					}
					break;
			}
		}
	}

	private void CheckWaypoint(Waypoint current)
	{
		_animations.SetIdleAnimation();
		if (current.EnemiesPool.GetEnemiesLength() == 0)
		{
			_stateMachine.IdleState();	
		}
		else
		{
			current.Init(this);
			_stateMachine.ShootingState();
			Debug.Log(current.EnemiesPool.GetEnemiesLength());
		}
			
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
	private Player _player;
	public EnemiesPool EnemiesPool;

	public void Init(Player player)
	{
		_player = player;
		Enable();
	}

	private void TryReleasePlayer()
	{
		if (EnemiesPool.GetEnemiesLength() == 0)
		{			
			_player.StateMachine.IdleState();
			Disable();
		}
	}

	private void Enable()
	{
		EnemiesPool.EnemyDeadBehaviour += TryReleasePlayer;
		Debug.Log("Делегат подключен");
	}

	private void Disable()
	{
		EnemiesPool.EnemyDeadBehaviour -= TryReleasePlayer;
		Debug.Log("Делегат отключен");
	}
}

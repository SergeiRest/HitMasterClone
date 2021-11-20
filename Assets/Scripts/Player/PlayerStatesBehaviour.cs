using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStates { Running, Shooting, Idle }
public class PlayerStatesBehaviour
{
	private IPlayerState _currentState;
	private PlayerStates _playerState;

	public void Init()
	{
		_playerState = PlayerStates.Idle;
		Debug.Log(_playerState);
	}

	public void ChangeState(PlayerStates state)
	{
		_playerState = state;
	}

	public void IdleState()
	{
		_currentState = new PlayerIdleState();
		_currentState.Execute(this);
	}

	public void RunningState()
	{
		_currentState = new PlayerRunningState();
		_currentState.Execute(this);
	}

	public PlayerStates GetPlayerState()
	{
		return _playerState;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IPlayerState
{
	public void Execute(PlayerStatesBehaviour state)
	{
		state.ChangeState(PlayerStates.Idle);
	}
}

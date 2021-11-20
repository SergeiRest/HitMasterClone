using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : IPlayerState
{
	public void Execute(PlayerStatesBehaviour state)
	{
		state.ChangeState(PlayerStates.Running);
	}
}

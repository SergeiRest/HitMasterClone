using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootState : IPlayerState
{
	public void Execute(PlayerStatesBehaviour state)
	{
		state.ChangeState(PlayerStates.Shooting);
	}
}

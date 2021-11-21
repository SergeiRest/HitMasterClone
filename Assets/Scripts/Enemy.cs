using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStates {ALive, Dead }
public class Enemy : MonoBehaviour
{
	[SerializeField] private EnemiesPool _curentPool;
	private EnemyStates _states = EnemyStates.ALive;
	public void TakeDamage()
	{
		if(_states == EnemyStates.ALive)
		{
			_states = EnemyStates.Dead;
			_curentPool.Remove(this);
		}
	}
}

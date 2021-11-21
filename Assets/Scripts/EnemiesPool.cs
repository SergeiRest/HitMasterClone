using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesPool : MonoBehaviour
{
	[SerializeField] private List<Enemy> _livingEnemies;
	public delegate void EnemyDead();
	public EnemyDead EnemyDeadBehaviour;

	public int GetEnemiesLength()
	{
		return _livingEnemies.Count;
	}

	public void Remove(Enemy enemy)
	{
		_livingEnemies.Remove(enemy);
		EnemyDeadBehaviour?.Invoke();
	}
}

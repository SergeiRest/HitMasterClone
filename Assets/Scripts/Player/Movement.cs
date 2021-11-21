﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Movement : MonoBehaviour
{
	[SerializeField] private Transform[] _waypoints;
	private NavMeshAgent _agent;
	private int _currentPoint = 0;
	private PlayerStatesBehaviour _stateMachine = new PlayerStatesBehaviour();
	private Camera _camera;

	public delegate void PointCheching(Waypoint point);
	public PointCheching Check;

	public PlayerStatesBehaviour StateMachine
	{
		get { return _stateMachine; }
	}


    private void Start()
    {
		_camera = Camera.main;
		_agent = GetComponent<NavMeshAgent>();
		this.transform.position = _waypoints[_currentPoint].position;
		_stateMachine.Init();
    }

	private void Update()
	{
		_camera.transform.position = this.transform.position - new Vector3(0, -2, 5);
	}

	public void StartMove()
	{
		StartCoroutine(Moving());
	}


	private IEnumerator Moving()
	{
		_stateMachine.RunningState();
		_currentPoint++;
		_agent.SetDestination(_waypoints[_currentPoint].position);
		yield return null;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out Waypoint point))
		{
			Debug.Log("Точка достигнута");
			_stateMachine.ShootingState();
			Check?.Invoke(point);
		}

		if (_currentPoint == _waypoints.Length - 1)
			Debug.Log("Финиш");
	}
}

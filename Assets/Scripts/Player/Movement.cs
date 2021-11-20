using System.Collections;
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
    void Start()
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

	private void OnMouseDown()
	{
		switch (_stateMachine.GetPlayerState())
		{
			case (PlayerStates.Idle):
				StartCoroutine(Move());
				break;
			case (PlayerStates.Running):
				Debug.Log("Бежит");
				break;
		}
	}

	private IEnumerator Move()
	{
		_stateMachine.RunningState();
		_currentPoint++;
		_agent.SetDestination(_waypoints[_currentPoint].position);
		yield return null;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Waypoint")
		{
			Debug.Log("Точка достигнута");
			_stateMachine.IdleState();
		}

		if (_currentPoint == _waypoints.Length - 1)
			Debug.Log("Финиш");
	}
}

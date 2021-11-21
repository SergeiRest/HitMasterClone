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
	private Camera _camera;

	public delegate void PointCheching(Waypoint point); // Делегат на проверку вейпоинта
	public PointCheching Check;

	public delegate void LevelFinished();
	public LevelFinished Finished;

    private void Start()
    {
		_camera = Camera.main;
		_camera.transform.rotation = Quaternion.Euler(new Vector3(20, 0, 0));
		_agent = GetComponent<NavMeshAgent>();
		transform.position = _waypoints[_currentPoint].position + new Vector3(0, 3, 0);
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
		_currentPoint++;
		_agent.SetDestination(_waypoints[_currentPoint].position);
		yield return null;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out Waypoint point))
		{
			Debug.Log($"Точка достигнута {point.gameObject.name}");
			Check?.Invoke(point);
		}

		if (_currentPoint == _waypoints.Length - 1)
		{
			Debug.Log("Финиш");
			Finished?.Invoke();
		}			
	}
}

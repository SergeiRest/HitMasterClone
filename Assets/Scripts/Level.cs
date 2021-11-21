using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
	private int _buildIndex;

	private void Start()
	{
		_buildIndex = SceneManager.GetActiveScene().buildIndex;
	}

	public void Reload()
	{
		Debug.Log("Абоба");
		SceneManager.LoadScene(_buildIndex);
	}
}

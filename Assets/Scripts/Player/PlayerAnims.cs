using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Animator))]
public class PlayerAnims : MonoBehaviour
{
	private const string RUN_ANIMATION = "Run";
	private const string IDLE_ANIMATION = "Idle";
	private Animator _animator;

	private void Start()
	{
		_animator = GetComponent<Animator>();
		SetIdleAnimation();
	}

	public void SetRunAnimation()
	{
		_animator.SetFloat(RUN_ANIMATION, 0.4f);
		_animator.SetFloat(IDLE_ANIMATION, 0);
	}

	public void SetIdleAnimation()
	{
		_animator.SetFloat(IDLE_ANIMATION, 1);
		_animator.SetFloat(RUN_ANIMATION, 0);
	}
}

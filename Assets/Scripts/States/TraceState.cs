using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TraceState<T> : IState where T : Monster
{
	[SerializeField] float moveSpeed;
	private Transform playerTransform;
	public void Enter()
	{
		playerTransform = GameObject.FindWithTag("Player").transform.parent;
	}

	public void Exit()
	{
		// Vector2 dir = (playerTransform.position - owner)
	}

	public void Update()
	{
		
	}
}

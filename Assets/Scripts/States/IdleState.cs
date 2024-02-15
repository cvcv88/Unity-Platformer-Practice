using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class IdleState<T> : IState where T : Monster
{
    [SerializeField] T Owner;
    public float findRange;

    private Transform playerTransform;

    public void Enter()
    {
        Debug.Log("Idle Enter");
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    public void Update()
    {
		Debug.Log("Idle Update");
        if(Vector2.Distance(playerTransform.position, Owner.transform.position) < findRange)
        {
            // fsm.ChangeState(State.Trace);
        }
	}

    public void Exit()
    {
		Debug.Log("Idle Exit");
	}
}
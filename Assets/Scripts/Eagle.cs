using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : Monster
{
	public Vector3 startPos;
	public enum State{Idle, Trace, Return, Die }

	[Header("FSM")]
	private StateMachine<State, Eagle> fsm;

	[SerializeField] IdleState<Eagle> idleState;
	[SerializeField] IdleState<Eagle> traceState;

	private void Awake()
	{
		fsm = new StateMachine<State, Eagle>();

		fsm.AddState(State.Idle, idleState);
		fsm.AddState(State.Trace, traceState);
		// fsm.AddState(State.Return, returnState);

		fsm.SetInitState(State.Idle);

		startPos = transform.position;
	}

	private void Update()
	{
		fsm.Update();

	}
}

public class Orc : Monster
{
	public enum State { Idle, Trace, Flee, Die, Hit}
	StateMachine<State, Orc> fsm;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<TState, TOwner> where TOwner : Monster
{
	// [SerializeField] TOwner owner;
	private Dictionary<TState, IState> states = new Dictionary<TState, IState>();
	private IState curState; // 현재 상태 갖고 있기

	public void Update() // 현재 상태 업데이트
	{
		curState.Update();
	}
	public void SetInitState(TState type) // 초기 상태 지정해주기
	{
		curState = states[type];
		curState.Enter();
	}
	public void ChangeState(TState type) // 상태 전환
	{
		curState.Exit(); // curState 현재 상태 탈출
		curState = states[type];
		curState.Enter(); // nextState 다음 상태 진입하기
	}

	public void AddState(TState type, IState state)
	{
		states.Add(type, state);
	}
}

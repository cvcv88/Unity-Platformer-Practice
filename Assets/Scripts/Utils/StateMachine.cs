using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<TState, TOwner> where TOwner : Monster
{
	// [SerializeField] TOwner owner;
	private Dictionary<TState, IState> states = new Dictionary<TState, IState>();
	private IState curState; // ���� ���� ���� �ֱ�

	public void Update() // ���� ���� ������Ʈ
	{
		curState.Update();
	}
	public void SetInitState(TState type) // �ʱ� ���� �������ֱ�
	{
		curState = states[type];
		curState.Enter();
	}
	public void ChangeState(TState type) // ���� ��ȯ
	{
		curState.Exit(); // curState ���� ���� Ż��
		curState = states[type];
		curState.Enter(); // nextState ���� ���� �����ϱ�
	}

	public void AddState(TState type, IState state)
	{
		states.Add(type, state);
	}
}

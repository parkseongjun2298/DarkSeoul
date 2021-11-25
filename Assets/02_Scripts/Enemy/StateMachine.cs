using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine <T>
{
    private T Owner;
    private FSM_State<T> CurrentState;
    private FSM_State<T> PreviouseState;

    public void Awake()
    {
        CurrentState = null;
        PreviouseState = null;
    }

    public void ChangeState(FSM_State<T> _NewState)
    {
        if (_NewState == CurrentState)
        {
            return;
        }

        PreviouseState = CurrentState;

        if (CurrentState != null)
        {
            CurrentState.ExitState(Owner);
        }

        CurrentState = _NewState;

        if (CurrentState != null)
        {
            CurrentState.EnterState(Owner);
        }
    }

    public void Initial_Setting(T _Owner, FSM_State<T> _InitialState)
    {
        Owner = _Owner;
        ChangeState(_InitialState);
    }

    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.UpdateState(Owner);
        }
    }

    public void StateRevert()
    {
        if (PreviouseState != null)
        {
            ChangeState(PreviouseState);
        }
    }
}

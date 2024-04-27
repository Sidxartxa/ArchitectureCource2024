using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlingState : GroundedState
{
    public IdlingState(IStateSwitcher stateSwitcher, StateMachineData stateMachineData, Character character) : base(stateSwitcher, stateMachineData, character)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Data.Speed = 0;

        CharacterView.StartIdling();
    }

    public override void Exit()
    {
        base.Exit();
        CharacterView.StopIdling();
    }

    public override void Update()
    {
        base.Update();
        if (IsHorisontalInputZero())
            return;

        StateSwitcher.SwitchState<RunningState>();

    }
}

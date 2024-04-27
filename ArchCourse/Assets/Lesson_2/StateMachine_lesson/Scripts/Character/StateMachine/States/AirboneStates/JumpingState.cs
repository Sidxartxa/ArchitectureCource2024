using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : AirboneState
{
    private JumpingStateConfig _config;

    public JumpingState(IStateSwitcher stateSwitcher, StateMachineData stateMachineData, Character character) : base(stateSwitcher, stateMachineData, character)
    {
        _config = character.CharacterConfig.AirbornStateConfig.JumpingStateConfig;
    }

    public override void Enter()
    {
        base.Enter();
        CharacterView.StartJumping();
        Data.YVelocity = _config.StartYVelocity;
    }
    public override void Exit()
    {
        base.Exit();
        CharacterView.StopJumping();
    }

    public override void Update()
    {
        base.Update();

        if (Data.YVelocity < 0)
        {
            StateSwitcher.SwitchState<FallingState>();
        }
    }
}

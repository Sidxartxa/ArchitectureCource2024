using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirboneState : MovementState
{

    private readonly AirbornStateConfig _config;
    

    public AirboneState(IStateSwitcher stateSwitcher, StateMachineData stateMachineData, Character character) : base(stateSwitcher, stateMachineData, character)
    {
        _config = character.CharacterConfig.AirbornStateConfig;
    }

    public override void Enter()
    {
        base.Enter();
        CharacterView.StartAirbone();
        Data.Speed = _config.Speed;
    }

    public override void Exit()
    {
        base.Exit();
        CharacterView.StopAirbone();
    }
    public override void Update()
    {
        base.Update();
     Data.YVelocity -= _config.BaseGravity * Time.deltaTime;
    }

}

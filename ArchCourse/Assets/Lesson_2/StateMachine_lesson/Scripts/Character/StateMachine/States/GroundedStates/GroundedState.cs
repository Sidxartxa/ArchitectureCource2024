using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GroundedState : MovementState
{
    private readonly GroundChecker _groundChecker;

    public GroundedState(IStateSwitcher stateSwitcher, StateMachineData stateMachineData, Character character) : base(stateSwitcher, stateMachineData, character)
    {
        _groundChecker = character.GroundChecker;
    }

    public override void Enter()
    {
        base.Enter();
        CharacterView.StartGrounded();
    }

    public override void Exit()
    {
        base.Exit();
        CharacterView.StopGrounded();
    }

    public override void Update()
    {
        base.Update();
        if (_groundChecker.IsTouches)
        return;
        
            StateSwitcher.SwitchState<FallingState>();
        
    }

    protected override void AddInputActionsCallback()
    {
        base.AddInputActionsCallback();
        PlayerInput.Movement.Jump.started += OnJumpKeyPressed;
        Debug.Log("Jump callback added");
    }

    protected override void RemoveInputActionsCallback() 
    {  
        base.RemoveInputActionsCallback(); 
        PlayerInput.Movement.Jump.started -= OnJumpKeyPressed;
        Debug.Log("Jump callback removed");
    }


    private void OnJumpKeyPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
        StateSwitcher.SwitchState<JumpingState>();
    }
}

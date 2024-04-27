public class FallingState : AirboneState
{
    private readonly GroundChecker _groundChecker;

    public FallingState(IStateSwitcher stateSwitcher, StateMachineData stateMachineData, Character character) : base(stateSwitcher, stateMachineData, character)
    {
        _groundChecker = character.GroundChecker;

    }

    public override void Enter()
    {
        base.Enter();
        CharacterView.StartFalling();
    }
    public override void Exit()
    {
        base.Exit();
        CharacterView.StopFalling();
    }

    public override void Update()
    {
        base.Update();

        if (_groundChecker.IsTouches)
        {
            Data.YVelocity = 0;

            if (IsHorisontalInputZero())
            {
                StateSwitcher.SwitchState<IdlingState>();
            }
            else
            {
                StateSwitcher.SwitchState<RunningState>();
            }
            
        }
    }
}

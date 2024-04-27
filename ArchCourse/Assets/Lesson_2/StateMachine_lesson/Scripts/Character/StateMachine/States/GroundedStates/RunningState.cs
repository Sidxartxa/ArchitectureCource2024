public class RunningState : GroundedState
{

    private readonly RunningStateConfig  _config;

    public RunningState(IStateSwitcher stateSwitcher, StateMachineData stateMachineData, Character character) : base(stateSwitcher, stateMachineData, character)
    => _config = character.CharacterConfig.RunningStateConfig;

    public override void Enter()
    {
        base.Enter();
        Data.Speed = _config.Speed;

        CharacterView.StartRunning();
    }

    public override void Exit()
    {
        base.Exit();
        CharacterView.StopRunning();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorisontalInputZero())
        {
            StateSwitcher.SwitchState<IdlingState>();
        }
    }

}

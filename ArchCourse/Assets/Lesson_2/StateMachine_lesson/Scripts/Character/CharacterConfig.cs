using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private RunningStateConfig _runningStateConfig;
    [SerializeField] private AirbornStateConfig _airbornStateConfig;
    //[SerializeField] private JumpingStateConfig _jumpingStateConfig;

    public RunningStateConfig RunningStateConfig => _runningStateConfig;
    public AirbornStateConfig AirbornStateConfig => _airbornStateConfig;
    //public JumpingStateConfig JumpingStateConfig => _jumpingStateConfig;
}

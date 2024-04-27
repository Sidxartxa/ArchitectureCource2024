using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AirbornStateConfig
{
    [SerializeField] private JumpingStateConfig _jumpingStateConfig ;
    [SerializeField, Range(0, 10)] private float _speed;

    public JumpingStateConfig JumpingStateConfig => _jumpingStateConfig;

    public float Speed => _speed;
    public float BaseGravity 
        
        => 2f* _jumpingStateConfig.MaxHeight/ (_jumpingStateConfig.TimeToReachMaxHeight*_jumpingStateConfig.TimeToReachMaxHeight);




}

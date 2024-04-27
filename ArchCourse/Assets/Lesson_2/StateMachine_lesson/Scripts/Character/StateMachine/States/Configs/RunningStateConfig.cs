using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RunningStateConfig

{
    [field: SerializeField, Range(0,10)] public float Speed { get; private set; }
}


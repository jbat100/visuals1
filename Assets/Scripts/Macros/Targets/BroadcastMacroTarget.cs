using System;
using System.Collections.Generic;
using UnityEngine;

public class BroadcastMacroTarget : MacroTarget
{
    [SerializeField] private List<MacroTarget> _targets;

    private void Broadcast(Action<MacroTarget> action)
    {
        foreach (MacroTarget target in _targets)
        {
            action(target);
        }
    }
    
    public override void SetFloat(float value)
    {
        Broadcast(target => SetFloat(value));
    }

    public override void SetColor(Color value)
    {
        Broadcast(target => SetColor(value));
    }
    
    public override void SetVector3(Vector3 value)
    {
        Broadcast(target => SetVector3(value));
    }
    
    public override void SetVector4(Vector4 value)
    {
        Broadcast(target => SetVector4(value));
    }
}

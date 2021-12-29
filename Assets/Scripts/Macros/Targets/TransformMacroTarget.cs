using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMacroTarget : MacroTarget
{
    [SerializeField] private Transform _target;

    public Transform Target => _target;

    protected virtual void Awake()
    {
        if (!_target)
        {
            _target = transform;
        }
    }
}

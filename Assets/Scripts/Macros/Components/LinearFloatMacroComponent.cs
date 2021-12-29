using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class LinearFloatMacroComponent : LinearMacroComponent
{

    [SerializeField] private float _start;
    [SerializeField] private float _end;

    protected override void Apply(float value, MacroTarget target)
    {
        base.Apply(value, target);
        Debug.Log($"{this} {nameof(Apply)} {value} to {target}");
        float result = Mathf.Lerp(_start, _end, value);
        target.SetFloat(result);
    }
}
